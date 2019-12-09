#include <stdio.h>
#include <winsock2.h>
#include <ws2tcpip.h>

#pragma comment(lib, "ws2_32.lib")

#define PORT "12345"
#define BUFSIZE 256

int main(int argc, char *argv[])
{
	if(argc != 2){
		printf("Usage: %s [IPv6_Address]\n", argv[0]);
		return -1;
	}

	WSADATA data;
	WSAStartup(MAKEWORD(2,2), &data);

	int sockfd;
	char buf[BUFSIZE];
	int err;
	struct addrinfo hints;
	struct addrinfo* res = NULL;
	struct addrinfo* ai;

	memset(&hints, 0, sizeof(hints));
	hints.ai_family = AF_UNSPEC;     // IPv4/IPv6両対応
	hints.ai_socktype = SOCK_STREAM;
	// serviceはポート番号でなければならない。AI_NUMERICSERV を指定しなければ、
	// 'pop'などでもよい。
	hints.ai_flags = AI_NUMERICSERV;  

	err = getaddrinfo((const char *)argv[1], PORT, &hints, &res);
		if (err != 0) {
			printf("getaddrinfo(): %s\n", gai_strerror(err));
		return -1;
	}

	for (ai = res; ai; ai = ai->ai_next){
		// 最初に見つかった IPv6 アドレスでソケットを作成
		// ここの if を外せば、IPv4 IPv6 のどちらでも通信できる
		if(ai->ai_family == AF_INET6){
			sockfd = socket(ai->ai_family, ai->ai_socktype, ai->ai_protocol);
			if (sockfd < 0)
				return -1;
			break;
		}
	}
	
	// IPv6 アドレスが見つからなかった場合
	if(ai == NULL){
		printf("指定されたアドレスが見つかりませんでした\n");
		return -1;
	}
	
	if(connect(sockfd, (struct sockaddr *)ai->ai_addr, ai->ai_addrlen) == SOCKET_ERROR){
		printf("connect Error...\n");
		return -1;
	}
	
	memset(buf, 0, BUFSIZE);
	printf("送信データを入力してください : ");
	gets(buf);
	
	int len;
	len = send(sockfd, buf, strlen(buf) + 1, 0);
	if(len < 0){
		printf("送信に失敗しました\n");
	}
	else{
		printf("送信に成功しました ( %d bytes )\n", len);
	}
	
	closesocket(sockfd);
	
	freeaddrinfo(res);
	WSACleanup();
}
