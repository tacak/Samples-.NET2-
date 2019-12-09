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
	struct sockaddr_storage sa;  // sockaddr_in �^�ł͂Ȃ��B
	while (1) {
		int len = sizeof(sa);  // �N���C�A���g�̏��𓾂�ꍇ

		printf("�ڑ��҂�...\n");
		cs = accept(sockfd, (struct sockaddr *)&sa, &len);
		if(cs < 0){
			printf("accept Error...\n");
			exit(1);
		}
		printf("�ڑ�������܂���\n");

		printf("��M�҂�...\n");
		memset(buf, 0, BUFSIZE);
		int datalen = recv(cs, buf, BUFSIZE, 0);
		if(datalen < 0){
			printf("recv Error...\n");
		}
		else{
			printf("��M�f�[�^ : %s\n", buf);
		}
		closesocket(cs);
	}
	
	closesocket(sockfd);
	WSACleanup();
}

// �߂�l <0   �G���[
//        >=0  listen���Ă���\�P�b�g
int tcp_bind(const char* service) // �T�[�r�X�� or �|�[�g�ԍ��i�̕�����j
{
	int err;
	struct addrinfo hints;
	struct addrinfo* res = NULL;
	struct addrinfo* ai;
	int sockfd;

	memset(&hints, 0, sizeof(hints));
	hints.ai_family = AF_INET6;    // AF_INET6�́AIPv4/IPv6�������󂯕t����B
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_flags = AI_PASSIVE;   // bind()����ꍇ�͎w�肷��B

    // node = NULL�̂Ƃ��AINADDR_ANY, IN6ADDR_ANY_INIT �ɑ����B
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