#include <stdio.h>
#include <winsock2.h>
#include <MSTcpIp.h>

#pragma comment(lib, "ws2_32.lib")

int main(void)
{
	WSADATA wsaData;
	SOCKET sock;
	struct sockaddr_in server;
	char buf[32];
	char *deststr = "192.168.0.18";

	BOOL bOptVal = TRUE;
	int bOptLen = sizeof(BOOL);
	int iOptVal;
	int iOptLen = sizeof(int);

	WSAStartup(MAKEWORD(2,0), &wsaData);

	sock = socket(AF_INET, SOCK_STREAM, 0);
	if (sock == INVALID_SOCKET) {
		printf("socket failed\n");
		return 1;
	}
/*
	if (getsockopt(sock, SOL_SOCKET, SO_KEEPALIVE, (char*)&iOptVal, &iOptLen) != SOCKET_ERROR){
		printf("SO_KEEPALIVE Value: %ld\n", iOptVal);
	}

	if (setsockopt(sock, SOL_SOCKET, SO_KEEPALIVE, (char*)&bOptVal, bOptLen) != SOCKET_ERROR){
		printf("Set SO_KEEPALIVE: ON\n");
	}

	if (getsockopt(sock, SOL_SOCKET, SO_KEEPALIVE, (char*)&iOptVal, &iOptLen) != SOCKET_ERROR){
		printf("SO_KEEPALIVE Value: %ld\n", iOptVal);
	}

	DWORD dwBytes,dwError = 0L ;
	tcp_keepalive sKA_Settings = {0}, sReturned = {0} ;

	sKA_Settings.onoff = 1 ;
	sKA_Settings.keepalivetime = 3000 ; // Keep Alive in 5.5 sec.
	sKA_Settings.keepaliveinterval = 1000 ; // Resend if No-Reply

	if (WSAIoctl(sock, SIO_KEEPALIVE_VALS, &sKA_Settings, sizeof(sKA_Settings), &sReturned, sizeof(sReturned), &dwBytes,NULL, NULL) != 0){
		dwError = WSAGetLastError() ;
		return 0;
	}

	printf("SIO_KEEPALIVE_VALS set:\n");
    printf("   Keepalive Time     = %lu\n", sKA_Settings.keepalivetime);
    printf("   Keepalive Interval = %lu\n", sKA_Settings.keepaliveinterval);
*/
	server.sin_family = AF_INET;
	server.sin_port = htons(12345);
	server.sin_addr.S_un.S_addr = inet_addr(deststr);
	if (server.sin_addr.S_un.S_addr == 0xffffffff) {
		struct hostent *host;

		host = gethostbyname(deststr);
		if (host == NULL) {
			return 1;
		}
		server.sin_addr.S_un.S_addr =
		*(unsigned int *)host->h_addr_list[0];
	}

	connect(sock, (struct sockaddr *)&server, sizeof(server));

	getchar();
	/*
	memset(buf, 0, sizeof(buf));
	int n = recv(sock, buf, sizeof(buf), 0);

	printf("%d, %s\n", n, buf);

	closesocket(sock);
	*/
	WSACleanup();

	return 0;
}
