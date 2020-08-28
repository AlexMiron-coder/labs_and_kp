#ifndef DEQUE_H
#define DEQUE_H
#include <stdio.h>

int *push_front(int add, int *deque, int *size);

int *push_back(int add, int *deque, int *size);

int *pop_front(int *deque, int *size);

int *pop_back(int *deque, int *size);

void output(int *deque, int size);

#endif
