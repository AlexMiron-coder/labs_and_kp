#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>

#include "deque.h"


/*int *push_back(int add, int *deque, int count){
    if(!deque[count]){
        deque = (int *)realloc(deque, count*sizeof(int));
    }
    deque[count] = add;
    return deque;
}

int *push_back(int add, int *deque, int *count){
    if(!deque[*count]){
        deque = (int *)realloc(deque, *count*sizeof(int));
    }
    deque[*count] = add;
    return deque;
}

int *push_front(int add, int *deque, int count){
    if(!deque[count]){
        deque = (int *)realloc(deque, count*sizeof(int));
    }
    for(int i = count - 1; i > 0; i--) deque[i] = deque[i-1];
    deque[0] = add;
    return deque;
}

int *pop_back(int *deque, int count){
    deque[count] = 0;
    return deque;
}

int *pop_front(int *deque, int count){

}*/

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

/*int *push_front(int add, int *deque, int *size){
    *size += 1;
    if(!deque[*size]){
        deque = (int *)realloc(deque, *size * (sizeof(int)));
    }
    for(int i = *size - 1; i > 0; i--) deque[i] = deque[i-1];
    deque[0] = add;
}*/

int* pop_front(int *deque, int *size){
    if(*size == 0){
        printf("\n Deque is empty\n");
    }
    else if(*size == 1){
        //int out = deque[0];
        free(deque);
        *size = 0;
        //return out;
    }
    else{
        //int out = deque[0];
        for(int i = 0; i < *size - 1; i++){
            deque[i] = deque[i+1];
        }
        *size -= 1;
        deque = (int *)realloc(deque, *size*(sizeof(int)));
        //return out;
    }
    return deque;
}

int* pop_back(int *deque, int *size){
    if(*size == 0){
        ///int out = -100000;
        printf("\n Deque is empty\n");
        //return out;
    }
    else if(*size == 1){
        //int out = deque[0];
        free(deque);
        *size = 0;
        //return out;
    }
    else{
        //int out = deque[*size-1];
        *size -= 1;
        deque = (int *)realloc(deque, *size*(sizeof(int)));
        //return out;
    }
    return deque;
}

void output(int *deque, int size){
    for(int i = 0; i < size; i++){
        printf("%d""%s", deque[i], " ");
    }
    printf("\n");
}
