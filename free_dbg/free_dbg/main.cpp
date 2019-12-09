#include <stdio.h>
#include <malloc.h>
#include <string.h>

void main(void)
{
	char *p;
	p = (char *)malloc(10240);
	printf("%p\n", p);
	memset(p, 0x0, 10250);
	free(p);
}