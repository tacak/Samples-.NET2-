//登録できるバッチの最大数は 96 個までです

#include <stdio.h>
#include <stdlib.h>

int main(void)
{
	char f1[512], f2[512];
	int cnt, i;

	printf("処理数の入力 ---> ");
	gets(f1);
	cnt = atoi(f1);
	
	if(cnt > 48){
		printf("登録できるバッチの最大数を超えます。96 個まで\n");
		return 1;
	}

	for(i = cnt; i < cnt << 1; i++){
		sprintf(f1, "batch%d.aup", i);
		sprintf(f2, "batch%d_.aup", i - cnt);

		printf("第1処理 : %s -> %s\n", f1, f2);
		if(rename(f1, f2) != 0){
			printf("リネームエラー 1\n");
			return 1;
		}
	}

	for(i = cnt; i > 0; i--){
		sprintf(f1, "batch%d_.aup", i - 1);
		sprintf(f2, "batch%d.aup", i * 2 - 1);

		printf("第2処理 : %s -> %s\n", f1, f2);
		if(rename(f1, f2) != 0){
			printf("リネームエラー 2\n");
			return 1;
		}

		sprintf(f1, "batch%d.aup", i - 1);
		sprintf(f2, "batch%d.aup", (i - 1) * 2);
		
		printf("第3処理 : %s -> %s\n", f1, f2);
		if(rename(f1, f2) != 0){
			printf("リネームエラー 3\n");
			return 1;
		}
	}
	printf("処理終了\n");

	return 0;
}