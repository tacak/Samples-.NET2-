//�o�^�ł���o�b�`�̍ő吔�� 96 �܂łł�

#include <stdio.h>
#include <stdlib.h>

int main(void)
{
	char f1[512], f2[512];
	int cnt, i;

	printf("�������̓��� ---> ");
	gets(f1);
	cnt = atoi(f1);
	
	if(cnt > 48){
		printf("�o�^�ł���o�b�`�̍ő吔�𒴂��܂��B96 �܂�\n");
		return 1;
	}

	for(i = cnt; i < cnt << 1; i++){
		sprintf(f1, "batch%d.aup", i);
		sprintf(f2, "batch%d_.aup", i - cnt);

		printf("��1���� : %s -> %s\n", f1, f2);
		if(rename(f1, f2) != 0){
			printf("���l�[���G���[ 1\n");
			return 1;
		}
	}

	for(i = cnt; i > 0; i--){
		sprintf(f1, "batch%d_.aup", i - 1);
		sprintf(f2, "batch%d.aup", i * 2 - 1);

		printf("��2���� : %s -> %s\n", f1, f2);
		if(rename(f1, f2) != 0){
			printf("���l�[���G���[ 2\n");
			return 1;
		}

		sprintf(f1, "batch%d.aup", i - 1);
		sprintf(f2, "batch%d.aup", (i - 1) * 2);
		
		printf("��3���� : %s -> %s\n", f1, f2);
		if(rename(f1, f2) != 0){
			printf("���l�[���G���[ 3\n");
			return 1;
		}
	}
	printf("�����I��\n");

	return 0;
}