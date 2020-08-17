// (2 * (1 + 3)) = (2 * 1) + (2 * 3)
//

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

#include "symbol.h"
#include "stack.h"
#include "tree.h"
#include "function.h"

void unmult(TN *root_l, TN *root_r, TN *Root){
    if(root_l && root_r){
        if(root_l->t.data.op == OP_PLUS){
            Root->t.data.op = OP_PLUS;
            
            root_r->l = (TN *)malloc(sizeof(TN));
            root_r->r = (TN *)malloc(sizeof(TN));
            
            float a = root_r->t.data.number;
            root_l->t.data.op = OP_MULT;
            float b = root_l->r->t.data.number;
            
            Root->r->t.type = symb_OP;
            Root->r->r->t.type = symb_NUMBER;
            Root->r->l->t.type = symb_NUMBER;
            Root->r->t.data.op = OP_MULT;
            
            Root->r->l->t.data.number = b;
            Root->r->r->t.data.number = a;
            Root->l->r->t.data.number = a;
        }

        if(root_r->t.data.op == OP_PLUS){
            Root->t.data.op = OP_PLUS;

            root_l->r = (TN *)malloc(sizeof(TN));
            root_l->l = (TN *)malloc(sizeof(TN));

            float a = root_l->t.data.number;
            root_r->t.data.op = OP_MULT;
            float b = root_r->l->t.data.number;

            Root->l->t.type = symb_OP;
            Root->l->r->t.type = symb_NUMBER;
            Root->l->l->t.type = symb_NUMBER;
            Root->l->t.data.op = OP_MULT;

            Root->l->l->t.data.number = a;
            Root->l->r->t.data.number = b;
            Root->r->l->t.data.number = a;

        }
    }
}

void func(TN *root){
    if(root->l != NULL){
        func(root->l);
    }
    if(root->r != NULL){
        func(root->r);
    }
    if(root->t.data.op == OP_MULT){
        //root->t.data.op = OP_PLUS;
        unmult(root->l, root->r, root);
    }

}