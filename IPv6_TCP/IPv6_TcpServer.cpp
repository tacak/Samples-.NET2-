#include <stdio.h>
#include <winsock2.h>
#include <ws2tcpip.h>

#pragma comment(lib, "ws2_32.lib")

int tcp_bind(const char* service);

#define PORT "12345"
#define BUFSIZE 256

void main(void)
{
	WSADATA data;
	WSAStartup(MAKEWORD(2,2), &data);
	
	int sockfd;
	char buf[BUFSIZE];

	sockfd = tcp_bind(PORT);
	if (sockfd < 0) {
		printf("tcp_bind Error...\n");
		exit(1);
	}
	
	if(listen(sockfd, 10) == SOCKET_ERROR){
		printf("listen Error...\n");
		exit(1);
	}

	int cs;
	struct sockaddr_storage sa;  // sockaddr_in 型ではない。
	while (1) {
		int len = sizeof(sa);  // クライアントの情報を得る場合

		printf("接続待ち...\n");
		cs = accept(sockfd, (struct sockaddr *)&sa, &len);
		if(cs < 0){
			printf("accept Error...\n");
			exit(1);
		}
		printf("接続がありました\n");

		printf("受信待ち...\n");
		memset(buf, 0, BUFSIZE);
		int datalen = recv(cs, buf, BUFSIZE, 0);
		if(datalen < 0){
			printf("recv Error...\n");
		}
		else{
			printf("受信データ : %s\n", buf);
		}
		closesocket(cs);
	}
	
	closesocket(sockfd);
	WSACleanup();
}

// 戻り値 <0   エラー
//        >=0  listenしているソケット
int tcp_bind(const char* service) // サービス名 or ポート番号（の文字列）
{
	int err;
	struct addrinfo hints;
	struct addrinfo* res = NULL;
	struct addrinfo* ai;
	int sockfd;

	memset(&hints, 0, sizeof(hints));
	hints.ai_family = AF_INET6;    // AF_INET6は、IPv4/IPv6両方を受け付ける。
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_flags = AI_PASSIVE;   // bind()する場合は指定する。

    // node = NULLのとき、INADDR_ANY, IN6ADDR_ANY_INIT に相当。
	err = getaddrinfo(NULL, service, &hints, &res);
	if (err != 0) {
		printf("getaddrinfo Error: %s\n", gai_strerror(err));
		return -1;
	}

	ai = res;

	sockfd = socket(ai->ai_family, ai->ai_socktype, ai->ai_protocol);
	if (sockfd < 0){
		printf("socket Error...\n");
		return -1;
	}

	int on = 1;
	if (setsockopt(sockfd, SOL_SOCKET, SO_REUSEADDR, (const char *)&on, sizeof(on)) < 0){
		printf("setsockopt Error...\n");
		return -1;
	}

	if (bind(sockfd, ai->ai_addr, ai->ai_addrlen) < 0){
		printf("bind Error...\n");
		return -1;
	}

	freeaddrinfo(res);

	return sockfd;
}