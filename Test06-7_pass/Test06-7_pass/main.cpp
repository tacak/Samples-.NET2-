#include <stdio.h>
#include <malloc.h>
#include <ctype.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>


#define BACKSPACE 0x8
#define ENTER     0xD

void GetPassword(char strPwd[], int max)
{
	char c;
	int idx = 0, i;

	do{
		c = getch();
		if(isalnum(c)){
			strPwd[idx < max ? idx++ : max] = c;
		}
		else if(c == BACKSPACE){
			idx <= 0 ? idx = 0 : idx--;
		}
		rewind(stdin);
	}while(c != ENTER);
	strPwd[idx] = '\0';
}

fpos_t GetFileLength(char *Path)
{
	fpos_t size = 0;

	FILE *fin = fopen(Path, "rb");
	if(fin == NULL){
		return -1;
	}

	fseek(fin, 0, SEEK_END); 
	fgetpos(fin, &size); 

	fclose(fin);

	return size;
}

int LineBufferCopy(char *orig, int origSize, char *buf, int IndexClearFlg)
{
	static int idx = 0;
	int i;

	if(IndexClearFlg != 0){
		idx = 0;
	}

	if(idx >= origSize){
		return -1;
	}

	for(i = 0; idx < origSize && (orig[idx] != '\r' && orig[idx] != '\n'); i++, idx++){
		*(buf + i) = *(orig + idx);
	}
	*(buf + i) = '\0';
	
	while(idx < origSize && (orig[idx] == '\r' || orig[idx] == '\n')){
		idx++;
	}
	
	return 0;
}

int ReadPasswordFile(FILE *fin, char *buf)
{
	int readSize;
	int i;

	do{
		readSize = fread(buf, 1, 512, fin);
		for(i = 0; i < readSize; i++){
			buf[i] ^= 107;
		}
	}while(readSize >= 512);
	
	return 0;
}

int WritePasswordFile(char *UserName, char *Password)
{
	FILE *fout;
	char buf[512];
	int i;

	if((fout = fopen("passwd", "ab")) == NULL){
		return 1;
	}

	sprintf(buf, "%s:%s\n", UserName, Password);

	for(i = 0; buf[i]; i++){
		buf[i] ^= 107;
	}
	
	fwrite(buf, 1, i, fout);
	
	fclose(fout);
	
	return 0;
}

int CheckAndWritePasswordFile(char *UserName, char *Password)
{
	char *PwdFile = "passwd";
	FILE *fin;
	fpos_t fSize;
	char UserPass[512];
	char *buf, *p;
	int ExsistFlg;
	
	fSize = GetFileLength(PwdFile);
	if(fSize < 0){
		printf("ユーザを追加しました。\n");
		WritePasswordFile(UserName, Password);
		return 0;
	}
	
	buf = (char *)malloc(fSize);
	if(buf == NULL){
		printf("メモリが確保できませんでした。\n");
		return 0;
	}
	
	fin = fopen(PwdFile, "rb");
	ReadPasswordFile(fin, buf);
	fclose(fin);

	system("move /Y passwd _passwd > NUL");
	
	ExsistFlg = 0;
	while(LineBufferCopy(buf, fSize, UserPass, 0) >= 0){
		if((p = strchr(UserPass, ':')) == NULL){
			continue;
		}
		*p = '\0';
		if(strcmp(UserPass, UserName) == 0){
			printf("既に登録済みのユーザのため、パスワードを上書きしました。\n");
			WritePasswordFile(UserName, Password);
			ExsistFlg = 1;
		}
		else{
			WritePasswordFile(UserPass, p + 1);
		}
	}
	
	if(!ExsistFlg){
		printf("ユーザを追加しました。\n");
		WritePasswordFile(UserName, Password);
	}

	free(buf);
	return 0;
}

int main(void)
{
	char UserName[128];
	char Password[128];
	char buf[512];
	
	printf("UserName : ");
	gets(UserName);
	printf("Password : ");
	GetPassword(Password, 127);
	
	printf("\n\n");
	CheckAndWritePasswordFile(UserName, Password);
	
	return 0;
}
