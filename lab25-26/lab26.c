#include <stdio.h>
#include <stdlib.h>

#include "deque.h"
#include "sort.h"

int menu(void){
    int ans;
    printf("\n 1. Push_front deque1");
    printf("\n 2. Push_back deque1");
    printf("\n 3. Pop_front deque1");
    printf("\n 4. Pop_back deque1");
    printf("\n 5. Push_front deque2");
    printf("\n 6. Push_back deque2");
    printf("\n 7. Pop_front deque2");
    printf("\n 8. Pop_back deque2");
    printf("\n 9. Output deque1");
    printf("\n 10. Output deque2");
    printf("\n 11. Sort");
    printf("\n 12. EXIT\n");
    scanf("%d", &ans);
    return ans;
}

int main(){
    int size_of_deq1 = 0;
    int size_of_deq2 = 0;
    int *deque1 = NULL;
    int *deque2 = NULL;
    //deque1 = (int *)malloc(sizeof(int));
    //deque2 = (int *)malloc(sizeof(int));
    int k = 0;
    while(k != 12){
        k = menu();
        switch(k)
        {
            case 1:
            {
                getchar();
                printf("Enter a number: ");
                int val;
                scanf("%d", &val);
                deque1 = push_front(val, deque1, &size_of_deq1);
                printf("\n");
            }
            break;

            case 2:
            {
                getchar();
                printf("Enter a number: ");
                int val;
                scanf("%d", &val);
                deque1 = push_back(val, deque1, &size_of_deq1);
                printf("\n");
            }
            break;

            case 3:
            {
                getchar();
                //int out = pop_front(deque1, &size_of_deq1);
                deque1 = pop_front(deque1, &size_of_deq1);
                printf("\n");
            }
            break;

            case 4:
            {
                getchar();
                //int out = pop_back(deque1, &size_of_deq1);
                deque1 = pop_back(deque1, &size_of_deq1);
                printf("\n");
            }
            break;

            case 5:
            {
                getchar();
                printf("Enter a number: ");
                int val;
                scanf("%d", &val);
                deque2 = push_front(val, deque2, &size_of_deq2);
                printf("\n");
            }
            break;

            case 6:
            {
                getchar();
                printf("Enter a number: ");
                int val;
                scanf("%d", &val);
                deque2 = push_back(val, deque2, &size_of_deq2);
                printf("\n");
            }
            break;

            case 7:
            {
                getchar();
                //int out = pop_front(deque2, &size_of_deq2);
                deque2 = pop_front(deque2, &size_of_deq2);
                printf("\n");
            }
            break;

            case 8:
            {
                getchar();
                //int out = pop_back(deque2, &size_of_deq2);
                deque2 = pop_back(deque2, &size_of_deq2);
                printf("\n");
            }break;

            case 9:
            {
                getchar();
                printf("\n Deque: ");
                output(deque1, size_of_deq1);
            }
            break;

            case 10:
            {
                getchar();
                printf("\nDeque: ");
                output(deque2, size_of_deq2);
            }
            break;

            case 11:
            {
                int* deque3 = NULL;
                deque3 = merge(deque1, deque2, &size_of_deq1, &size_of_deq2);
                output(deque3, size_of_deq1 + size_of_deq2);
                int size = size_of_deq1 + size_of_deq2;
                //MergeSort(deque3, 0, size);
                deque3 = Sort(deque1, deque2, size_of_deq1, size_of_deq2);
                //check(deque3, deque1, deque2, size, &size_of_deq1, &size_of_deq2);
                output(deque3, size);
            }
            break;

            case 12:
            {
                break;
            }
        }
    }
}
