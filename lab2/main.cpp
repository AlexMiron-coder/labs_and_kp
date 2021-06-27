#include <iostream>
#include <cstdio>
#include "TBTree.hpp"
#include "TItem.hpp"



int main() {
    TBTree bTree;
    // нужно создать TItem и его вносить в дерево
    TItem elem{};
    short size = 0;
    char k[KEY_SIZE + 1] = {'\0'};
    unsigned long long value;
    //Node* search;
    while ((scanf("%s", elem.key)) != EOF) {
        switch (elem.key[0]) {
            case '+':
                scanf("%s %llu", elem.key, &elem.value);
                for (short i = 0; i < KEY_SIZE; i++) {
                    if (elem.key[i] >= 'A' and elem.key[i] <= 'Z') {
                        elem.key[i] = elem.key[i] - 'A' + 'a';
                    }
                    if (elem.key[i] == '\0') {
                        elem.keySize = i;
                        break;
                    }
                }
                //elem.keySize = size;
                if (bTree.Search(elem)) {
                    printf("Exist\n");
                } else {
                    bTree.Insert(elem);
                    printf("OK\n");
                }
                break;
            case '-':
                scanf("%s", elem.key);
                for (short i = 0; i < KEY_SIZE; i++) {
                    if (elem.key[i] >= 'A' and elem.key[i] <= 'Z') {
                        elem.key[i] = elem.key[i] - 'A' + 'a';
                    }
                    if (elem.key[i] == '\0') {
                        elem.keySize = i;
                        break;
                    }
                }
                if (bTree.Search(elem)) {
                    bTree.BTreeDelete(elem);
                    printf("OK\n");
                } else {
                    printf("NoSuchWord\n");
                }
                break;
            case '!':
                printf("!\n");
                break;
            default:
                printf("default\n");
                break;
        }
        elem.clear();
    }
    /*while ((scanf("%s", k)) != EOF) {
        //TItem elem{};
        switch (k[0]) {
            case '+':
                scanf("%s %llu",k, &value);
                //printf("считали: %s %llu\n", k, value);
                for (short  i = 0; i < KEY_SIZE; i++) {
                    if (k[i] != '\0') {
                        elem.key[i] = k[i];
                        size = i + 1;
                    }
                }
                elem.keySize = size;
                elem.value = value;
                printf("считали: %s %llu key.sise = %d\n", elem.key, elem.value, elem.keySize);
                if (bTree.Search(elem)) {
                    printf("Exist\n");
                } else {
                    bTree.Insert(elem);
                    printf("OK\n");
                }
                //bTree.Insert(elem);
                //bTree.print();
                break;
            case '-':
                printf("-\n");
                break;
            case '!':
                printf("!\n");
                break;
            default:
                printf("new word\n");
                break;
        }
    }*/
    bTree.Print(0);
    //bTree.Erase();
    //bTree.~TBTree();
    return 0;
}

/*
+ word 34
+ fdfgdfg 325
+ ffhdh 325
+ idplp 78
+ you 1
+ flag 335
+ sfafcuc 34
+ root 123
+ zzz 15
+ word 34
 */