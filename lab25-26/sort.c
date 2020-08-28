#include <stdio.h>
#include <stdlib.h>

#include "deque.h"
#include "sort.h"

int* merge(int* deq1, int* deq2, int* size1, int* size2){
    int *deq3 = NULL;
    int m = *size1;
    int size3 = (*size1 + *size2);
    deq3 = (int *)realloc(deq3, size3*(sizeof(int)));
    for(int i = 0; i < size3; i++){
        if(i < m){
          deq3[i] = deq1[i];
        }
        else{
          deq3[i] = deq2[i - m];
        }
    }
    return deq3;
} // Слияние деков



void MergeSort(int* deque, int l, int r){
    if(l >= r) return;

    int m = (l + r)/2;
    MergeSort(deque, l, m);
    MergeSort(deque, m + 1, r);
    sort(deque, l, r, m);
}

void sort(int* deque, int l, int r, int m){
    int j = l;
    int k = m + 1;
    int count = r - l + 1;

    if(count <= 1) return;

    int* tmp = NULL;
    tmp = (int *)realloc(tmp, count*(sizeof(int)));

    for(int i = 0; i < count; ++i){
        if(j <= m && k <= r){
            if(deque[j] < deque[k]){
                tmp[i] = deque[j++];
            }
            else{
                tmp[i] = deque[k++];
            }
        }
        else{
            if(j <= m){
                tmp[i] = deque[j++];
            }
            else{
                tmp[i] = deque[k++];
            }
        }
    }

    j = 0;
    for(int i = l; i <= r; ++i){
        deque[i] = tmp[j++];
    }

}


int* Sort(int* dq1, int* dq2, int s1, int s2){
    int* dq3 = NULL;
    int s3 = s1 + s2;
    dq3 = (int *)realloc(dq3, s3 * (sizeof(int)));
    int i=0, j=0;
    for (int k = 0; k < s3; k++) {
        if (i > s1 - 1) {
          int a = dq2[j];
          dq3[k] = a;
          j++;
        }
        else if (j > s2 - 1) {
          int a = dq1[i];
          dq3[k] = a;
          i++;
        }
        else if (dq1[i] < dq2[j]) {
          int a = dq1[i];
          dq3[k] = a;
          i++;
        }
        else {
          int b = dq2[j];
          dq3[k] = b;
          j++;
        }
    }
    return dq3;
}
