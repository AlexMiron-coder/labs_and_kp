#ifndef LAB2_TBTREE_HPP
#define LAB2_TBTREE_HPP

#include "TItem.hpp"
#include "TVector.hpp"


struct Node {
    bool leaf;
    int n;
    TVector<TItem> thisNode;
    TVector<Node*> children;
    Node() : thisNode(1), children(2){
        leaf = true;
        n = 0;
    }
    //Node();
};


/*Node::Node() {
    thisNode = new TVector<TItem>(1);
    childs = new TVector<Node *>(2);
    leaf = true;
    n = 0;
}*/

class TBTree {
private:
    Node* root; // корень
public:
    TBTree();
    ~TBTree();
    void Create ();
    void Insert (TItem &);
    void BTreeInsert (Node* &, TItem &);
    void BTreeSplitChildren (Node* &, int);
    void Erase();
    void Delete(Node* &);
    bool Empty();
    void Print(int);
    void vecPrint(Node* &, int);
    Node* getRoot();
    Node* BTreeSearch(Node* &, Node* &, TItem &, int &);
    Node* FindParent(Node* &, Node* &, TItem &);
    bool Search(TItem &);
    void BTreeDelete(TItem &);
    void DeleteFromNode(Node* &, TItem &, int);
    void DeleteLeaf(Node* &, Node* &, TItem &, int);
    void repair(Node* &, Node* &, int);
    void remove (Node* &, Node* &, TItem &, int);
    void leftConcatination(Node* &, Node* &);
};

Node * TBTree::getRoot() {
    return root;
}

bool TBTree::Search(TItem& k) {
    Node* search;
    int index;
    Node* parent = root;
    search = BTreeSearch(root, parent, k, index);
    if (search != nullptr) {
        return true;
    }
    return false;
}

Node* TBTree::FindParent(Node *&x,Node *&parent, TItem &k) {
    if (root == nullptr) {
        return nullptr;
    }
    short i = 0;
    while (i < x->n and k > x->thisNode[i]) {
        i++;
    }
    if (i < x->n and k == x->thisNode[i]) {
        return x;
    } else if(x->leaf) {
        return nullptr;
    }
    else {
        parent = x; //
        return FindParent(x->children[i], parent, k); // +x -parent
    }
}

Node * TBTree::BTreeSearch(Node *&x,Node *&parent, TItem &k, int &index) {
    if (root == nullptr) {
        return nullptr;
    }
    short i = 0;
    while (i < x->n and k > x->thisNode[i]) {
        i++;
    }
    if (i < x->n and k == x->thisNode[i]) {
        index = i;
        return x;
    } else if(x->leaf) {
        return nullptr;
    }
    else {
        parent = x; //
        return BTreeSearch(x->children[i], parent, k, index); // +x -parent
    }
}

void TBTree::Print(int tab) {
    if (root->leaf) {
        for (int i = 0; i < root->n; i++) {
            printf("%s ", root->thisNode[i].key);
        }
        printf("\n");
    }
    else {
        vecPrint(root, tab);
    }
}

void TBTree::vecPrint(Node *&x, int tab) {
    if (x->children[0] != nullptr) {
        for (int i = x->children.Size() - 1; i >= 0; i--){ // >= 0
            vecPrint(x->children[i], tab + 1);
        }
    }
    for (int i = 0; i < tab; i++) {
        printf("\t");
    }
    printf("size: %d :", x->thisNode.Size());
    for (int i = 0; i < x->thisNode.Size(); i++) {
        printf("%s ", x->thisNode[i].key);
    }
    printf("\n");
}

bool TBTree::Empty() {
    if (root == nullptr) {
        return true;
    }
    return false;
}

void TBTree::Erase() {
    //Delete(root);
    root->children.Erase();
    root->thisNode.Erase();
    if (root != nullptr){
        delete root;
    }
}

void TBTree::Delete(Node* &node) {
    Node* cur = node;
    if (cur->children[0] == nullptr) {
        node = cur->children[1];
        cur->children[1] = nullptr;
    }
    delete cur;
}

TBTree::TBTree() {
    root = nullptr;
    //Node* x = new Node;
    //x->leaf = true;
    //x->n = 0;
    //root = x;
    //delete x;
}

TBTree::~TBTree() {
    //root->childs.Erase();
    //root->thisNode.Erase();
    /*printf("maxSize = %d\n", root->childs.getMaxSize());
    for (short i = 0; i < root->childs.getMaxSize(); i++) {
        delete root->childs[i];
    }
    root = nullptr;*/
    delete root;
}

void TBTree::Create() {
    root = new Node;
    root->children[0] = nullptr;
    root->children[1] = nullptr;
}

void TBTree::Insert(TItem &k) {
    /*if (root == nullptr) {
        root = new Node;
        root->thisNode[0] = k;
        root->childs[0] = nullptr;
        root->childs[1] = nullptr;
        printf("root is a nullptr\nTree created!\n");
    }*/ //  не удалять, так это правильно работает

    if (root == nullptr) {
        Create(); // создаем корень
    }
    Node* r = root;
    if (r->n == 2 * t - 1) {
        Node* s = new Node;
        root = s;
        s->leaf = false;
        s->thisNode.SetSize(0);
        s->children[0] = r;
        s->children.SetSize(1);
        BTreeSplitChildren(s, 0);
        BTreeInsert(s, k);
        //s = nullptr;
    } else {
        BTreeInsert(r, k);
    }
}

void TBTree::BTreeInsert(Node *&x, TItem &k) {
    int i = x->n;
    if (x->leaf) { // работает
        x->thisNode.AddSize(); //  увеличить длину вектора

        while (i >= 1 and k < x->thisNode[i - 1]) {
            x->thisNode[i] = x->thisNode[i - 1];
            i--;
        }
        x->thisNode[i] = k;
        x->n++;
        x->thisNode.SetSize(x->n);
    } else { // пока не работает (мб работает)
        while (i >= 1 and k < x->thisNode[i - 1]) {
            i--;
        }
        if (x->children[i]->n == 2 * t - 1) {
            BTreeSplitChildren(x, i);
            if (k > x->thisNode[i]) {
                i++;
            }
        }
        BTreeInsert(x->children[i], k);
    }
}

void TBTree::BTreeSplitChildren(Node *&x, int i) {
    //printf("In split childs\n");
    Node* z = new Node;
    Node* y = x->children[i];
    z->leaf = y->leaf;
    z->thisNode.resize(t - 1); //
    z->n = t - 1;
    for (int j = 0; j < t - 1; j++) {
        z->thisNode.push_back(y->thisNode[j + t]); // z[j] = y[j+t]
    }
    if (!y->leaf) {
        z->children.resize(t);
        for (int j = 0; j < t; j++) {
            z->children[j] = y->children[j + t];
        }
        z->children.SetSize(t);
        y->children.resize(t);
    }
    TItem mediana = y->thisNode[t - 1];
    y->thisNode.resize(t - 1);
    y->n = t - 1;
    //x->children.AddSze();
    x->children.resize(x->children.Size() + 1);
    for (int j = x->children.Size(); j > i + 1; j--) { // (для случая когда разбиение узла, который находится где-то в центре)
        x->children[j] = x->children[j - 1];
    }
    x->children[i + 1] = z;
    x->children.SetSize(x->children.Size() + 1);
    x->thisNode.AddSize();
    for (int j = x->n; j > i; j--) {
        x->thisNode[j] = x->thisNode[j - 1];
    }
    x->thisNode[i] = mediana;
    x->n++;
    x->thisNode.SetSize(x->n);
}

void TBTree::BTreeDelete(TItem &k) {
    Node* x;
    Node* parent = root;
    int index;
    x = BTreeSearch(root, parent, k, index); // узел в котором удаляемый элемент и его индекс
    printf("parent[parent->n - 1].key = %s\n", parent->thisNode[parent->n - 1].key);
    if (x->leaf) {
        if (x->n > (t - 1)) {
            DeleteFromNode(x, k, index);
        } else {
            DeleteLeaf(x, parent, k, index);
        }
    } else {
        remove(x, parent, k, index);
    }
}

void TBTree::DeleteFromNode(Node *&x, TItem &k, int index) {
    if (k == x->thisNode[index]) {
        for (int j = index; j < x->n - 1; j++) {
            x->thisNode[j] = x->thisNode[j + 1];
        }
        x->thisNode.resize(x->n - 1);
        x->n--;
    }
}

void TBTree::DeleteLeaf(Node *&x, Node *&parent, TItem &k, int index) {
    if (x == root and x->n == 1) {
        DeleteFromNode(x, k, index);
        root->thisNode.Erase();
        root->children.Erase();
        delete root;
        root = nullptr;
        return;
    }
    if (x == root) {
        DeleteFromNode(x, k, index);
        return;
    }
    if (x->n > (t - 1)) { // mb useless
        DeleteFromNode(x, k, index);
        return;
    }
    int positionSon = -1;
    for (int j = 0; j < parent->n + 1; j++) {
        if (parent->children[j] == x) {
            positionSon = j; // позиция узла по отношению к родителю
            break;
        }
    }
    printf("parent->n = %d, parent[parent->n].key %s, positionSon = %d, x->n = %d, index = %d", parent->n, parent->thisNode[parent->n - 1].key, positionSon, x->n, index);
    if (positionSon == 0) {
        if (parent->children[positionSon + 1]->n > (t - 1)) { // у правого брата ключей > t - 1
            TItem k1 = parent->children[positionSon + 1]->thisNode[0]; // минимальный ключ правого брата
            TItem k2 = parent->thisNode[positionSon]; // ключ родителя, который больше чем удаляемый но меньше, чем k1
            x->thisNode.AddSize(); // добавили k2 в узел в котором нужно что-то удалить
            x->thisNode[x->n] = k2;
            x->thisNode.SetSize(x->n + 1);
            x->n++; //
            DeleteFromNode(x, k, index); // удаляем нужный элемент
            DeleteFromNode(parent->children[positionSon + 1], k1, 0); // удаляем k1 из правого брата
            parent->thisNode[positionSon] = k1; // на место k2 в parent ставим k1
        } else { // если у правого брата не больше t - 1 ключей
            DeleteFromNode(x, k, index);
            if (x->n <= (t - 2)) {
                repair(x, parent, positionSon);
            }
        }
    } else {
        if (positionSon == parent->n) { // если последний сын
            if (parent->children[positionSon - 1]->n > (t - 1)) { // если у левого брата последнего сына > t - 1 keys
                TItem k1 = parent->children[positionSon - 1]->thisNode[parent->children[positionSon - 1]->n - 1]; // максимальный элемент левого брата
                TItem k2 = parent->thisNode[positionSon - 1]; // ключ родителя, который меньше, чем удаляемый, но больше, чем k1
                /*x->thisNode.AddSize(); // добавили k2 в узел, в котором нах-ся удаляемый элемент
                x->thisNode[x->n] = k2;
                x->thisNode.SetSize(x->n + 1);
                x->n++;*/
                DeleteFromNode(x, k, index); // удаляем нужный элемент
                x->thisNode.AddSize();
                for (int i = x->n; i > 0; i--) { // добавили k2 в ластового сына
                    x->thisNode[i] = x->thisNode[i - 1];
                }
                x->thisNode[0] = k2;
                x->thisNode.SetSize(x->n + 1);
                x->n++;//
                DeleteFromNode(parent->children[positionSon - 1], k1, parent->children[positionSon - 1]->n - 1); // удаляем k1 из левого брата
                parent->thisNode[positionSon - 1] = k1; // на место k2 ставим k1
            } else { // мб не робит
                DeleteFromNode(x, k, index);
                if (x->n <= (t - 2)) {
                    repair(x, parent, positionSon);
                }
            }
        } else { // когда не по краям, то есть слева и справа есть братья
            if (parent->children[positionSon + 1]->n > (t - 1)) { // если у правого ключей > t - 1
                TItem k1 = parent->children[positionSon + 1]->thisNode[0]; // минимальный ключ правого брата
                TItem k2 = parent->thisNode[positionSon]; // ключ родителя который больше удаляемого и меньше k1
                x->thisNode.push_back(k2); // заносим k2 в узел в котором удаляем элемент
                x->n++;
                DeleteFromNode(x, k, index); // удаляем нужный ключ
                parent->thisNode[positionSon] = k1;
                // удаляем из правого брата его минимальный элемент, то есть первый
                DeleteFromNode(parent->children[positionSon + 1], parent->children[positionSon + 1]->thisNode[0], 0);
            } else if (parent->children[positionSon - 1]->n > (t - 1)) {
                TItem k1 = parent->children[positionSon - 1]->thisNode[parent->children[positionSon - 1]->n - 1]; // максимальный ключ левого брата
                TItem k2 = parent->thisNode[positionSon - 1]; // ключ родятеля, который меньше удаляемого, но больше чем k1
                DeleteFromNode(x, k, index); // удаляем нужный ключ
                x->thisNode.AddSize(); // добавляем k2 в узел в котором удалил ключ
                for (int i = x->n; i > 0; i--) {
                    x->thisNode[i] = x->thisNode[i - 1];
                }
                x->thisNode[0] = k2;
                x->thisNode.SetSize(x->n + 1);
                x->n++; //
                parent->thisNode[positionSon - 1] = k1;
                parent->children[positionSon - 1]->thisNode.resize(parent->children[positionSon - 1]->n - 1);
            } else { // справа и слева нет братьев у которых > t-1 ключей
                DeleteFromNode(x, k, index);
                if (x->n <= (t - 2)) {
                    repair(x, parent, positionSon);
                }
            }
        }
    }
}

void TBTree::repair(Node *&x, Node *&parent, int positionSon) {
    if (x == root and x->n == 0) { // пока хз, так как не чекал
        if (root->children[0] != nullptr) {
            Node* s = root->children[0];
            root->children[1]->thisNode.Erase();
            root->children[1]->children.Erase();
            delete root->children[1];
            root->thisNode.Erase();
            root->children.Erase();
            delete root;
            root = s;
            root->children.resize(2);
        } else {
            delete root;
            root = nullptr; // mb not used
        }
        return;
    }

    if (positionSon == 0) { // если самый левый узел
        x->thisNode.AddSize(); // добавляем в левого сына левый элемент родителя
        x->thisNode[x->n] = parent->thisNode[positionSon];
        x->thisNode.SetSize(x->n + 1);
        x->n++; //
        leftConcatination(x, parent->children[positionSon + 1]); // объединение двух узлов
        //DeleteFromNode(parent, parent->thisNode[positionSon], positionSon); // удаляем первый элемент parent, так как он уже в первом сыне
        /*for (int i = positionSon + 1; i < parent->n; i++) {
            parent->children[i] = parent->children[i + 1];
        }*/
        //DeleteFromNode(parent, parent->thisNode[positionSon], positionSon); // удаляем первый элемент parent, так как он уже в первом сыне
        if (parent->children.Size() > 2) { // parent->children.Size() - 1
            parent->children[positionSon + 1]->thisNode.Erase();
            parent->children[positionSon + 1]->children.Erase();
            delete parent->children[positionSon + 1];
            for (int i = positionSon + 1; i < parent->n; i++) {
                parent->children[i] = parent->children[i + 1];
            }
            parent->children.resize(parent->children.Size() - 1);
        } //
        DeleteFromNode(parent, parent->thisNode[positionSon], positionSon);
        //parent->children.resize(parent->children.Size() - 1);
        if (x->n == 2 * t){
            printf("2*t situation\n");
        } else {
            if (parent->n <= 0 and parent == root) {
                repair(parent, parent, positionSon);
            } else if (parent->n <= t - 2){
                Node* grandParent = root;
                grandParent = FindParent(root, grandParent, parent->thisNode[0]);
                printf("grandParent[0] = %s\n", grandParent->thisNode[0].key);
            }
        }
    } else if (positionSon == parent->n) { // если самый правый (т.е. последний) узел
        x->thisNode.AddSize(); // добавляем в последнего сына правый элемент родителя
        for (int i = x->n + 1; i > 0; i--) {
            x->thisNode[i] = x->thisNode[i - 1];
        }
        x->thisNode[0] = parent->thisNode[positionSon - 1];
        x->thisNode.SetSize(x->n + 1);
        x->n++; //
        leftConcatination(parent->children[positionSon - 1], x); // сливаем два узла
        DeleteFromNode(parent, parent->thisNode[positionSon - 1], positionSon - 1); // удаляем элемент из родителя, так как он уже в сыне
        //delete parent->children[positionSon];
        if (parent->children.Size() > 2) {
            parent->children[parent->children.Size() - 1]->thisNode.Erase();
            parent->children[parent->children.Size() - 1]->children.Erase();
            delete parent->children[parent->children.Size() - 1];
            parent->children.resize(parent->children.Size() - 1);
        }
        //parent->children.resize(parent->children.Size() - 1);
        if (parent->children[positionSon - 1]->n == 2 * t) {
            printf("second 2*t situation\n");
        } else {
            if (parent->n <= 0 and parent == root) {
                repair(parent, parent, positionSon);
            } else if (parent->n <= (t - 2)) {
                Node* curParent;
                int l;
                Node* par = BTreeSearch(root, curParent, parent->thisNode[0], l);
                repair(par, curParent, curParent->n - 1);
            }
        }
    } else { // справа и слева есть братья
        x->thisNode.push_back(parent->thisNode[positionSon]); // элемент родителя между текущим узлом и правым братом
        leftConcatination(x, parent->children[positionSon + 1]);
        parent->children[positionSon + 1]->thisNode.Erase();
        parent->children[positionSon + 1]->children.Erase();
        delete parent->children[positionSon + 1];
        for (int i = positionSon + 1; i < parent->n; i++) {
            parent->children[i] = parent->children[i + 1];
        }
        parent->children.resize(parent->children.Size() - 1);
        DeleteFromNode(parent, parent->thisNode[positionSon], positionSon); // удаляем из родителя
    }

}

void TBTree::leftConcatination(Node *&node, Node *&otherNode) {
    if (node == nullptr) return;
    for (int i = 0; i < otherNode->n; i++) {
        node->thisNode.push_back(otherNode->thisNode[i]); // добавляем к node элементы otherNode
        //node->children.push_back(otherNode->children[i]); // добавляем детей
    }
    if (node->children[0] != nullptr) {
        for (int i = 0; i < otherNode->n + 1; i++) {
            node->children.push_back(otherNode->children[i]);
        }
    }
    node->n = node->thisNode.Size();
}

void TBTree::remove (Node* &x, Node* &parent, TItem &k, int index) {
    int positionSon = -1;
    for (int j = 0; j < parent->n + 1; j++) {
        if (parent->children[j] == x) {
            positionSon = j; // позиция узла по отношению к родителю
            break;
        }
    }
    Node* tmp = x->children[index + 1];
    TItem k1 = x->thisNode[0];
    while (!tmp->leaf) tmp = tmp->children[0];
    if (tmp->n > (t - 1)) {
        k1 = tmp->thisNode[0];
        DeleteFromNode(tmp, k1, 0);
        x->thisNode[index] = k1;
    } else {
        tmp = x;
        tmp = tmp->children[index];
        k1 = tmp->thisNode[tmp->n - 1];
        while (!tmp->leaf) {
            tmp = tmp->children[tmp->n];
        }
        k1 = tmp->thisNode[tmp->n - 1];
        x->thisNode[index] = k1;
        if (tmp->n > (t - 1)) DeleteFromNode(tmp, k1, tmp->n - 1);
        else{
            printf("Перестройка!\n");
            DeleteLeaf(x, parent, k, index);
        }
    }
}

/*

+ g 1
+ h 2
+ i 3
+ j 4
+ k 5
+ l 6
+ m 7
+ t 8
+ v 9
+ w 10
+ x 11
+ n 12
+ o 13
+ p 14
+ q 15
+ r 16
+ rr 15
+ rs 345
+ rt 435
+ rtt 453
+ tu 34
+ u 3
+ uu 453
+ uv 3453
+ xx 3543
+ a 3123
+ b 1615
+ c 61
+ d 789
+ dd 1321
+ rss 111
+ rst 222
+ rts 611
+ rtss 1616
+ ab 12
+ vw 124
+ vwx 14
+ xy 122
+ xyy 123
+ rtsr 45
+ rtst 56
+ rtstt 65
+ rttt 89
+ xxx 21
+ xyx 653
+ xyxy 456
+ xz 78
+ tt 98
+ tut 986
+ tuu 104
+ ut 784
+ uuu 11
+ xyxx 132
+ xyxyy 45
+ xyyy 73
+ xzz 10
+ aa 45
+ ba 89
+ bc 102
+ ca 202
+ baa 45
+ bca 4615
+ baca 665
+ caba 103
+ dc 32
+ da 4
+ dca 5
+ daa 56
+ gg 15
+ ga 13
+ gh 65
+ ghi 131
+ hi 14
+ dab 15
+ db 16
+ dba 48
+ dca 789
+ xyzy 615
+ xyz 31
+ xyzz 654
+ xzy 46
+ xzx 54
+ xzxx 65
+ xzy 5
+ xzyx 654
+ xzyy 63
+ xzyx 21
+ xzyz 21
+ xzzz 654
+ xzyyy 32
+ xzyyx 651
+ xzyyxy 56
+ xzzy 20
+ aba 321
+ abb 32
+ abc 9
+ abd 98
+ abz 189
+ abe 615
+ abf 32
+ adg 321
+ abh 202
+ abi 321
+ abj 32
+ abk 5
+ abl 56
+ abm 654
+ abn 651
+ abo 516
+ abp 494
+ abq 48
+ abr 651
+ abs 651
+ abt 213
+ aca 651
+ acb 23
+ acc 516
+ acd 321
+ ace 65
+ acf 65
+ acg 65
+ ach 66
+ aci 654
+ acj 321
+ ack 98
+ acl 16
+ acm 654
+ acn 12
+ aco 1
+ acp 54
+ acq 65
+ acr 123
+ acs 56
+ act 45
+ acu 56
+ acv 56
+ acw 1
+ acx 5
+ acxa 549
+ acxb 651
+ acxd 321
+ acxc 98
+ dbaa 156
+ ade 145
+ adee 115
+ adef 56
+ adf 187
- adg
- dca
- i
- rttt
- uuu
- caba
- xzz
- xzyyx
- xzyyxy
- dc
- db
- dba
- dbaa
- dab
- bca
- c
- ca


 */


/*
+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ i 9
+ j 10
+ k 11
+ l 12
+ m 13
+ n 14
+ o 15
+ p 16
+ q 17
+ h 8


+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ i 9
+ j 10
+ k 11
+ m 12
+ n 13
+ o 14
+ p 15
+ q 16
+ l 17


+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
+ i 9
+ j 10
+ k 11
+ m 12
+ n 13
+ o 14
+ p 15
+ l 16



+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ i 8
+ j 9
+ k 10
+ l 11
+ m 12
+ n 13
+ o 14
+ p 15
+ h 16
+ r 17
- r


+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ i 8
+ j 9
+ k 10
+ l 11
+ m 12
+ n 13
+ o 14
+ p 15
+ h 16
+ r 17
- r
- h



+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ i 8
+ j 9
+ k 10
+ l 11
+ m 12
+ n 13
+ o 14
+ p 15
+ h 16
+ r 17
- r
- h
- f
- l
- k
- j
- g
- p
- o
- n



+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ g 6
+ i 7
+ m 8
+ n 9
+ o 10
+ p 11
+ q 12
+ j 13
+ k 14
+ l 15

+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ i 8
+ j 9
+ k 10
+ l 11
+ m 12
+ n 13
+ o 14
+ p 15
+ h 16
+ r 17
- r
- h
- f
- l
- k
- j
- g
- p
- o
- n
- c
- m
- i
- e
- d
- b
- a

+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
- a
- b
- c
- d
- e
- f
- g


+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
- h
- c
- g
- f
- e
- d
- b
- a

+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
- h
- g
- c
- f
- e
- d
- b
- a


+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
+ i 9
+ j 10
+ k 11
+ l 12
- l
- g
- c
- b
- a
- e
- f
- i
- j
- k
- h
- d

+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
+ i 9
+ j 10
+ k 11
+ l 12
+ m 13
+ n 14
+ o 15
+ p 16
- p
- k
- c
- a
- b
- m
- e
- g
- f
- i
- j
- n
- o
- d
- h
- l

+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
+ i 9
+ j 10
+ k 11
+ l 12
+ m 13
+ n 14
+ o 15
+ p 16
- p
- g
- c
- a
- b
- m
- e
- k
- f
- i
- j
- n
- o
- d
- h
- l

+ d 1
+ e 2
+ f 3
+ h 4
+ i 5
+ j 6
+ k 7
+ l 8
+ m 9
+ n 10
+ o 11
+ p 12
- p
- m
- o
- n
- l
- k
- j
- i
- h
- f
- e
- d


+ d 1
+ e 2
+ f 3
+ h 4
+ i 5
+ j 6
+ k 7
+ n 8
- n
- k
- j
- i
- h
- e
- f
- d

+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
+ i 9
+ j 10
+ k 11
+ l 12
+ m 13
+ n 14
+ o 15
+ p 16
- p
- g
- k
- j
- i
- m
- n
- o
- l
- a
- b
- c
- d
- e
- f
- h

+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
+ i 9
+ j 10
+ k 11
+ l 12
+ m 13
+ n 14
+ o 15
+ p 16
- p
- c
- g
- f
- e
- m
- n
- o
- l
- k
- i
- j
- h
- d
- b
- a


+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
+ i 9
+ j 10
+ k 11
+ l 12
+ m 13
+ n 14
+ o 15
+ p 16
- p
- o
- n
- m
- l
- g
- k
- j
- i
- h
- f
- e
- d
- c
- b
- a

+ a 1
+ b 2
+ c 3
+ d 4
+ e 5
+ f 6
+ g 7
+ h 8
+ i 9
+ j 10
+ k 11
+ l 12
+ m 13
+ n 14
+ o 15
+ p 16
- p
- c
- f
- e
- g
- d
- i
- j
- k
- o
- m
- n
- l
- h
- b
- a

 */

#endif //LAB2_TBTREE_HPP
