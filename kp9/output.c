#include "stdio.h"
#include "stdlib.h"

#include "data.h"

void outtext(keys *p_k, element *allwords, int *counter) {
    for(int i = 0 ; i < (*counter) ; ++i) {
        printf("%f %s \n", p_k[i].primary_key, allwords[i].word);
    }
}

int checksim(keys *p_k, int* count) {
    int flag = 0;
    for(int i = 0; i < (*count); ++i) {
        if(p_k[i].primary_key < p_k[i + 1].primary_key) {
            flag++;
        }
    }
    if(flag == (*count) || flag == 0) {
        return 0;
    }
    return 1;
}

int random_keys(keys *k_p, const int n){
    for(int i = 0; i < n ; ++i){
        k_p[i].primary_key = rand() % 100;
    }

}

int binarysearch(float key, keys *k_p, const int n)
{
    printf("Here!\n");
    int low = 0, high = n - 1;
    while (low <= high) {
        int middle = (low + high) / 2;
        float cmp = (key > k_p[middle].primary_key) ? 1 : (key == k_p[middle].primary_key) ? 0 : -1 ;
        if (cmp < 0)
            high = middle - 1;
        else if (cmp > 0)
            low = middle + 1;
        else 
            return middle;
    }
    return -1;
}

int main() {
    printf("Start: \n");
    element allwords[12];
    keys keys[12];
    int counter = 0;
    printf("1. Прочесть таблицу из фалйа и вывести на экран\n");
    printf("2. Искать по ключу\n");
    printf("3. Напечатать таблицу\n");
    printf("4. Отсортировать таблицу\n");
    printf("5. Случайные ключи\n");
    printf("6. Выход\n");
    int flag = 0;
    float try = 0;
    while (flag != 6)
    {
        printf("Выбор функции:\n");
        scanf("%d", &flag);
        switch (flag) {
        case 1:
            fileReader(keys, allwords, &counter);
            break;
        case 2:
            printf("Введите искомое число: ");
            scanf("%f" , &try);
            int k = binarysearch(try, keys, counter);
            if(k != -1) {
                printf("Такоe число есть!\n");
                printf("%f   %s\n",keys[k].primary_key, allwords[k].word);
            } else {
                printf("Такого числа нет!\n");
            }
            break;
        case 3:
            if(counter != 0){
                outtext(keys, allwords, &counter);
            } else {
                printf("Нет данных!\n");
            }
            break;
        case 4:
            if(counter != 0){
                bubblesort(keys, allwords, &counter);
                ShekerSort(keys, allwords, &counter);
            } else {
                printf("Нет данных!\n");
            }
            break;
        case 5:
            if(counter != 0){
                random_keys(keys, counter);
            } else {
                printf("Нет данных!\n");
            }
            break;
        case 6:
            break;
        default:
            printf("\nОшибка!\n");
            break;
        }
    }
    printf("Done\n");
}