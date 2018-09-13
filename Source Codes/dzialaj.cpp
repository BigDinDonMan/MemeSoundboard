#include <stdio.h>
#include <windows.h>
#include <cstdlib>
#include <cstring>

int main(int argc, char** argv) {
	if (argc != 2) return 1;
	char* benin = argv[1];
	char* succ = (char*)calloc(strlen("otusznje.exe") + 1 + 2, sizeof(char));
	strcat(succ, "otusznje.exe ");
	strcat(succ, benin);
	STARTUPINFO si = {0};  si.cb = sizeof(STARTUPINFO);  PROCESS_INFORMATION  pi;
	CreateProcess(NULL, succ, NULL, NULL, FALSE, NULL, NULL, 0, &si, &pi);
	WaitForSingleObject(pi.hProcess, INFINITE);
	free(succ); 
	return 0;
}
