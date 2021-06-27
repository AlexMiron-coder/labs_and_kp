#ifndef LAB2_TVECTOR_HPP
#define LAB2_TVECTOR_HPP

const static int t = 4;
const static int MAX_SIZE = 2 * t - 1;

template <class T>
class TVector{
private:
    T* mData;
    int size;
    int maxSize;
public:
    TVector();
    TVector(int);
    short Size();
    short getMaxSize();
    void SetSize(int);
    T& operator [] (int);
    void Erase();
    void AddSize();
    void resize(int);
    void push_back(T&);
};

template <class T>
void TVector<T>::push_back(T& elem) {
    if (size == maxSize){
        maxSize = maxSize * 2;
        T* tmp = new T[maxSize];
        for (int i = 0; i < size; i++){
            tmp[i] = mData[i];
        }
        delete[] mData;
        mData = tmp;
    }
    size++;
    mData[size - 1] = elem;
}

template <class T>
void TVector<T>::resize(int n) { // for split childs
    if (n <= 2*t and size < n) { // size < n
        T* tmp = new T[n];
        for (int i = 0; i < size; i++) {
            tmp[i] = mData[i];
        }
        for (int i = size; i < n; i++) {
            tmp[i] = T();
        }
        delete[] mData;
        mData = tmp;
        maxSize = n;
    } else if (n <= 2*t and size > n) { // size > n
        T* tmp = new T[n];
        for (int i = 0; i < n; i++) {
            tmp[i] = mData[i];
        }
        delete[] mData;
        mData = tmp;
        size = size > n ? n : size;
        maxSize = n;
    }
}

template <class T>
void TVector<T>::AddSize() {
    //printf("\n\n resize function\n   size = %d\n   maxSize = %d\n", size, maxSize);
    if (size == maxSize) { // т.е. нет места в векторе -> resize
        maxSize = 2 * size > (2 * t - 1) ? (2 * t - 1) : 2 * size; // ограничение на 2t-1
        T* tmp = new T[maxSize];
        for (int i = 0; i < size; i++) {
            tmp[i] = mData[i];
        }
        for (int i = size; i < maxSize; i++) {
            tmp[i] = T();
        }
        delete[] mData;
        mData = tmp;
    }
}

template <class T>
TVector<T>::TVector () {
    size = 0;
    maxSize = 2;
    mData = new T[2];
}

template <class T>
TVector<T>::TVector (int n) {
    size = 0;
    maxSize = n;
    mData = new T[maxSize];
    for (int i = 0; i < maxSize; i++) {
        mData[i] = T();
    }
}

template <class T>
short TVector<T>::Size(){
    return size;
}

template <class T>
short TVector<T>::getMaxSize() {
    return maxSize;
}

template <class T>
void TVector<T>::SetSize(int n) {
    size = n;
}

template <class T>
T& TVector<T>::operator [] (int i) {
    return mData[i];
}

template <class T>
void TVector<T>::Erase() {
    //T* tmp = new T[0];
    if (mData != nullptr) {
        delete[] mData;
    }
    //delete[] mData;
    //mData = tmp;
    /*for (int i = 0; i < maxSize; i++) {
        mData[i] = nullptr;
    }*/
}

/*template <class T>
TVector<struct Node *> TVector<T>::operator = (TVector<T> &rhs) {
    mData = new T[rhs.Size()];
    for (short i = 0; i < rhs.Size(); i++) {
        mData[i] = rhs.mData[i];
    }
    *this;
}*/

#endif //LAB2_TVECTOR_HPP
