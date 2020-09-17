#ifndef _data_h_
#define _data_h_

typedef struct {
        char word[15];//слово
} element;

typedef struct {
        float primary_key;
} keys;

void fileReader(keys *p_k, element *allwords, int *counter);

void bubblesort(keys *p_k, element *allwords, int *counter);

void ShekerSort(keys *p_k, element *allwords, int *counter);

#endif 
