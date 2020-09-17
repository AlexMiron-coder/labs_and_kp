
#include "stdio.h"
#include "stdlib.h"

#include "data.h"

void fileReader(keys *p_k, element *allwords, int *counter)
{
    FILE * file;
    file = fopen ("text.txt","r");
    fseek(file, 0L, SEEK_SET);
    while (fscanf(file, "%f %s", &p_k[*counter].primary_key, allwords[*counter].word) != EOF) {
        printf("%f %s \n", p_k[*counter].primary_key, allwords[*counter].word);
        ++(*counter);
    }
}

void bubblesort(keys *p_k, element *allwords, int *counter) {
    for (int  k = 0; k < (*counter); ++k) { 
        for(int i = 0; i < (*counter) - 1; ++i) {
            if(p_k[i].primary_key >= p_k[i + 1].primary_key) {
                char a[15];
                char b[15];
                for (int j = 0; j < sizeof(allwords[i].word) / sizeof(allwords[i].word[0]); j++) {
                    a[j] = allwords[i].word[j];
                }
                for (int j = 0; j < sizeof(allwords[i + 1].word) / sizeof(allwords[i + 1].word[0]); j++) {
                    b[j] = allwords[i + 1].word[j];
                }
                for (int j = 0; j < sizeof(allwords[i].word) / sizeof(allwords[i].word[0]); j++) {
                    allwords[i + 1].word[j] = a[j];
                }
                for (int j = 0; j < sizeof(allwords[i + 1].word) / sizeof(allwords[i + 1].word[0]); j++) {
                    allwords[i].word[j] = b[j];
                }

                float tmp = p_k[i].primary_key;
                p_k[i].primary_key = p_k[i + 1].primary_key;
                p_k[i + 1].primary_key = tmp;
            }
        }
    }
}

void ShekerSort(keys *p_k, element *allwords, int *counter){ 
    int left = 0;
    int right = counter - 1;
    int flag = 1;
    while ((left < right) && flag > 0){
        flag = 0;
        for (int i = left; i < right; i++) {
            if (p_k[i].primary_key > p_k[i + 1].primary_key) {
                float t = p_k[i].primary_key;
                p_k[i].primary_key = p_k[i+1].primary_key;
                p_k[i+1].primary_key = t;
                flag = 1;
            }
        }
        right--;
        for (int i = right; i > left; i--) {
            if (p_k[i-1].primary_key > p_k[i].primary_key) {

                float t = p_k[i].primary_key;
                p_k[i].primary_key = p_k[i-1].primary_key;
                p_k[i-1].primary_key = t;
                flag = 1;
            }
        }
        left++;

    }
}