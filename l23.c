//29 вариант - найти число листьев в дереве
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <malloc.h>

typedef struct tree 
{
    int key;
    struct tree *left;
    struct tree *right;
} Node;

Node *create(int value){
    Node *tmp = (Node *)malloc(sizeof(Node));
    tmp->key = value;
    tmp->left = NULL;
    tmp->right = NULL;
    return tmp;
}

void add(Node *tmp, int value){
    if(value > (*tmp).key && (*tmp).right){
        add((*tmp).right, value);
        return;
    }
    if(value < (*tmp).key && (*tmp).left){
        add((*tmp).left, value);
        return;
    }
    if(value > (*tmp).key && !(*tmp).right){
        (*tmp).right = (Node *)malloc(sizeof(Node));
        if((tmp->right) == NULL){
            printf("Недостаточно памяти\n");
            return;
        }
        (*(*tmp).right).left = NULL;
        (*(*tmp).right).right = NULL;
        (*(*tmp).right).key = value;
        return;
    }
    if(value < (*tmp).key && !(*tmp).left){
        (*tmp).left = (Node *)malloc(sizeof(Node));
        if((tmp->left) == NULL){
            printf("Недостаточно памяти\n");
            return;
        }
        (*(*tmp).left).left = NULL;
        (*(*tmp).left).right = NULL;
        (*(*tmp).left).key = value;
        return;
    }
}

/*void find_max(Node *tmp){
    if (tmp == NULL){
        exit(4);
    }
    if(tmp->right){
        return find_max(tmp->right);
    }
    return tmp;
}*/

Node *delete_tree(Node *tmp){
    free(tmp);
    printf("Дерево удалено\n");
    tmp = NULL;
    return tmp;
}

void delete_node(Node *tmp, Node *tmp2, int delete_value){
    if(!tmp){
        printf("Нечего удалять\n");
        return;
    }
    else{
        if(delete_value > (*tmp).key && (*tmp).right){
            delete_node((*tmp).right, tmp, (*tmp).key);
            return;
        }
        if(delete_value < (*tmp).key && (*tmp).left){
            delete_node((*tmp).left, tmp, delete_value);
            return;
        }
        if(delete_value > (*tmp).key && !(*tmp).right){
            printf("Ты глупый или что-то?\n");
            return;
        }
        if(delete_value < (*tmp).key && !(*tmp).left){
            printf("Ты глупый или что-то?\n");
            return;
        }
        if(delete_value == (*tmp).key){
            if((*tmp).left || (*tmp).right){
                if(tmp->left){
                    tmp->key = tmp->left->key;
                    if(!tmp->left->left && !tmp->left->right){
                        free(tmp->left);
                        tmp->left = NULL;
                        return;
                    }
                    delete_node(tmp->left,tmp ,tmp->left->key);
                    return;
                }
                if(tmp->right){
                    tmp->key = tmp->right->key;
                    if(!tmp->right->left && !tmp->right->right){
                        free(tmp->right);
                        tmp->right = NULL;
                        return;
                    }
                    delete_node(tmp->right, tmp, tmp->right->key);
                    return;
                }
            }
            if((*tmp).left && (*tmp).right){
                Node *per1, *per2;
                if(tmp->left->right){
                    per1 = (*tmp).left;
                    while((*per1).right){
                        per2 = per1;
                        per1 = (*per1).right;
                    }
                    (*tmp).key = (*per1).key;
                    delete_node(per1, per2, (*per1).key);
                    return;
                }
                if(tmp->right->left){
                    per1 = (*tmp).right;
                    while((*per1).left){
                        per2 = per1;
                        per1 = (*per1).left;
                    }
                    (*tmp).key = (*per1).key;
                    delete_node(per1, per2, (*per1).key);
                    return;
                }
            }
            if(tmp->key > tmp2->key){
                tmp2->right = NULL;
            }
            else{
                tmp2->left = NULL;
            }
            free(tmp);
            return;
        }
    }
}

void print_tree(Node *tmp, int c){
    if(!tmp){
        printf("Дерево пустое\n");
        return;
    }
    int i = c;
    if(tmp->right){
        print_tree(tmp->right, c+1);
    }
    printf("%d", i);
    while(i > 0){
        printf("%s", "--");
        i -= 1;
    }
    printf("%d\n", tmp->key);
    i -= 1;
    if(tmp->left){
        print_tree(tmp->left, c + 1);
    }
}

/*void print_tree(Node *tmp){
    if (tmp == NULL){
        return;
    }
    if (tmp->key){
        printf("%d ", tmp->key);
    }
    print_tree(tmp->left);
    print_tree(tmp->right);
}*/

int list_count(Node *tmp)
{
    int result;
    if (tmp == NULL)
    {
        result = 0;
    }
    else if ((tmp->left == NULL) && (tmp->right==NULL))
    {
        result =  1;
    }
       
    else
    {
        result = list_count(tmp->left) + list_count(tmp->right);
    }
    return result ;
}

int menu(void){
    printf("1. Добавление узла\n");
    printf("2. Удаление узла\n");
    printf("3. Текстовая визуализация дерева\n");
    printf("4. Вычисление значения функции от дерева.\n");
    printf("5. Удаление дерева\n");
    int a;
    scanf("%d", &a);
    return a;
}

int main(){
    Node *root = NULL;
    int k = 0;
    while(k != 5)
    {
        k = menu();
        switch (k)
        {
            case 1:
            {
                int value;
                printf("Ведите число для добавления в дерево или создания дерева: \n");
                scanf("%d", &value);
                //int value = val;
                if(!root){
                    root = create(value);
                }
                else{
                    add(root, value);
                }
                printf("\n");
            }
            break;

            case 2:
            {
                int value;
                printf("Введите узел для удаления \n");
                scanf("%d", &value);
                if(root){
                    if(!root->left && !root->right && value == root->key){
                        root = delete_tree(root);
                    }
                    else{
                        if(!root->left && !root->right && value != root->key){
                            printf("Нет такого узла\n");
                        }
                        else{
                            delete_node(root, root, value);
                        }
                    }
                    delete_node(root, root, value);
                }
                else{
                    printf("NNN");
                }
                delete_node(root, root, value);
            }
            break;

            case 3:
            {
                getchar();
                print_tree(root, 0);
                printf("\n");
            }
            break;

            case 4:
            {
                int k = 0;
                k = list_count(root);
                printf("%d\n", k);
            }

            case 5:
            {

                break;
            }
        }

    }
    printf("Завершение работы\n");
    return 0;
}