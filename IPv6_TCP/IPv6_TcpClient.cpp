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
	hints.ai_family = AF_UNSPEC;     // IPv4/IPv6���Ή�
	hints.ai_socktype = SOCK_STREAM;
	// service�̓|�[�g�ԍ��łȂ���΂Ȃ�Ȃ��BAI_NUMERICSERV ���w�肵�Ȃ���΁A
	// 'pop'�Ȃǂł��悢�B
	hints.ai_flags = AI_NUMERICSERV;  

	err = getaddrinfo((const char *)argv[1], PORT, &hints, &res);
		if (err != 0) {
			printf("getaddrinfo(): %s\n", gai_strerror(err));
		return -1;
	}

	for (ai = res; ai; ai = ai->ai_next){
		// �ŏ��Ɍ������� IPv6 �A�h���X�Ń\�P�b�g���쐬
		// ������ if ���O���΁AIPv4 IPv6 �̂ǂ���ł��ʐM�ł���
		if(ai->ai_family == AF_INET6){
			sockfd = socket(ai->ai_family, ai->ai_socktype, ai->ai_protocol);
			if (sockfd < 0)
				return -1;
			break;
		}
	}
	
	// IPv6 �A�h���X��������Ȃ������ꍇ
	if(ai == NULL){
		printf("�w�肳�ꂽ�A�h���X��������܂���ł���\n");
		return -1;
	}
	
	if(connect(sockfd, (struct sockaddr *)ai->ai_addr, ai->ai_addrlen) == SOCKET_ERROR){
		printf("connect Error...\n");
		return -1;
	}
	
	memset(buf, 0, BUFSIZE);
	printf("���M�f�[�^����͂��Ă������� : ");
	gets(buf);
	
	int len;
	len = send(sockfd, buf, strlen(buf) + 1, 0);
	if(len < 0){
		printf("���M�Ɏ��s���܂���\n");
	}
	else{
		printf("���M�ɐ������܂��� ( %d bytes )\n", len);
	}
	
	closesocket(sockfd);
	
	freeaddrinfo(res);
	WSACleanup();
}
