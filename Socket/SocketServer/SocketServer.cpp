#include <stdio.h>
#include <winsock2.h>
#include <MSTcpIp.h>

#pragma comment(lib, "ws2_32.lib")

int main(void)
{
	WSADATA wsaData;
	SOCKET sock, srvSock;
	struct sockaddr_in addr;
	struct sockaddr_in client;
	int len;

		BOOL bOptVal = TRUE;
	int bOptLen = sizeof(BOOL);
	int iOptVal;
	int iOptLen = sizeof(int);

	WSAStartup(MAKEWORD(2,0), &wsaData);

	srvSock = WSASocket(AF_INET, SOCK_STREAM, IPPROTO_TCP, NULL, 0, WSA_FLAG_OVERLAPPED);
	if (srvSock == INVALID_SOCKET) {
		printf("socket failed\n");
		return 1;
	}

	if (getsockopt(srvSock, SOL_SOCKET, SO_KEEPALIVE, (char*)&iOptVal, &iOptLen) != SOCKET_ERROR){
		printf("SO_KEEPALIVE Value: %ld\n", iOptVal);
	}

	if (setsockopt(srvSock, SOL_SOCKET, SO_KEEPALIVE, (char*)&bOptVal, bOptLen) != SOCKET_ERROR){
		printf("Set SO_KEEPALIVE: ON\n");
	}

	if (getsockopt(srvSock, SOL_SOCKET, SO_KEEPALIVE, (char*)&iOptVal, &iOptLen) != SOCKET_ERROR){
		printf("SO_KEEPALIVE Value: %ld\n", iOptVal);
	}

	DWORD dwBytes,dwError = 0L ;
	tcp_keepalive sKA_Settings = {0}, sReturned = {0} ;

	sKA_Settings.onoff = TRUE ;
	sKA_Settings.keepalivetime = 5000 ; // Keep Alive in 5.5 sec.
	sKA_Settings.keepaliveinterval = 1000 ; // Resend if No-Reply

	if (WSAIoctl(srvSock, SIO_KEEPALIVE_VALS, &sKA_Settings, sizeof(sKA_Settings), &sReturned, sizeof(sReturned), &dwBytes,NULL, NULL) != 0){
		dwError = WSAGetLastError() ;
		return 0;
	}

	addr.sin_family = AF_INET;
	addr.sin_port = htons(12345);
	addr.sin_addr.S_un.S_addr = INADDR_ANY;

	bind(srvSock, (struct sockaddr *)&addr, sizeof(addr));

	listen(srvSock, 5);

	while (1) {
		len = sizeof(client);
		sock = accept(srvSock, (struct sockaddr *)&client, &len);
		//send(sock, "HELLO", 6, 0);

		//closesocket(sock);
	}

	WSACleanup();

	return 0;
}
