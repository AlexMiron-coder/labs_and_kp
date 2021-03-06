#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include "../data.h"

void writer(info_pc *stru)
{
    int size = sizeof(info_pc);
    if(!stru)
    {
        perror("Database is empty");
        return;
    }
    FILE *base = fopen(__NAME__, "w");
    if(!base)
    {
        perror("Can't open the file");
        return;
    }

    while(stru->next)
    {
        fwrite(stru, size, 1, base);
        stru = stru->next;
    }
    stru->next = NULL;
    fwrite(stru, size, 1, base);
    fclose(base);
    return;
}