#include <stdio.h>
#include <io.h>
#include <process.h>
#include <windows.h>

#define R (0)
#define W (1)

#define BUFSIZE 4096

int main(void)
{
	int pOut[2], pIn[2];
	int pOldOut, pOldIn;
	int len;
	char buf[BUFSIZE + 1];
	
	if(_pipe(pOut, BUFSIZE, 0) < 0 || _pipe(pIn, BUFSIZE, 0) < 0){
		printf("パイプ作成エラー\n");
		return 1;
	}
	
	pOldIn = _dup(0);
	_dup2(pIn[R], 0);
	
	pOldOut = _dup(1);
	_dup2(pOut[W], 1);
	
	_write(pOldOut, "OK", 3);

	if(_spawnlp(_P_NOWAIT, "cmd", "cmd", NULL) < 0){
		printf("exec エラー\n");
	}
	
	_write(pIn[W], "dir\r\n", 5);
	Sleep(500);
	_write(pIn[W], "exit\r\n", 6);
	Sleep(500);
	_flushall();
	
	_dup2(pOldIn, 0);
	_dup2(pOldOut, 1);

	do{
		len = _read(pOut[R], buf, BUFSIZE);
		buf[len] = '\0';
		printf("%s\n", buf);
		printf("***%d***\n", len);
	}while(len >= BUFSIZE);

	_close(pOut[R]);
	_close(pOut[W]);
	_close(pIn[R]);
	_close(pIn[W]);

	return 0;
}
