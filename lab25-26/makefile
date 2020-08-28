CC = gcc
LD = gcc
CCFLAGS = -std=c99 -pedantic -Wall -g
LDFLAGS =
OBJ = lab26.o deque.c sort.c
.SUFFIXES: .c .o
lab26: $(OBJ)
	       $(LD) $(LDFLAGS) -o lab26 $(OBJ)
lab26.o: lab26.c
deque.o: deque.c
sort.o: sort.c
.c.o:
	    $(CC) $(CCFLAGS) -c $< -o $@
deque.c: deque.h
sort.c: sort.h
clean:
	     rm -f *.o prog
