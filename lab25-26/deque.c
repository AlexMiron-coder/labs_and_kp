#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>

#include "deque.h"


int* push_back(int add, int *deque, int *size){
    *size += 1;
    int *tmp = NULL;

    tmp = (int *)realloc(deque, *size * (sizeof(int)));
    if(!tmp){
        printf("ERROR\n");
        *size -= 1;
    }
    else{
        deque = tmp;
        deque[*size-1] = add;
    }
    return deque;
}

int* push_front(int add, int *deque, int *size){
    *size += 1;
    int *tmp = NULL;

    tmp = (int *)realloc(deque, *size * (sizeof(int)));
    if(!tmp){
        printf("ERROR\n");
        *size -= 1;
    }
    else{
        deque = tmp;
        for(int i = *size - 1; i > 0; i--){
          deque[i] = deque[i-1];
        }
        deque[0] = add;
    }
    return deque;
}

int* pop_front(int *deque, int *size){
    if(*size == 0){
        printf("\n Deque is empty\n");
    }
    else if(*size == 1){
        free(deque);
        *size = 0;
    }
    else{
        
        for(int i = 0; i < *size - 1; i++){
            deque[i] = deque[i+1];
        }
        *size -= 1;
        deque = (int *)realloc(deque, *size*(sizeof(int)));
    }
    return deque;
}

int* pop_back(int *deque, int *size){
    if(*size == 0){
        printf("\n Deque is empty\n");
    }
    else if(*size == 1){
        free(deque);
        *size = 0;
    }
    else{
        *size -= 1;
        deque = (int *)realloc(deque, *size*(sizeof(int)));
    }
    return deque;
}

void output(int *deque, int size){
    for(int i = 0; i < size; i++){
        printf("%d""%s", deque[i], " ");
    }
    printf("\n");
}
