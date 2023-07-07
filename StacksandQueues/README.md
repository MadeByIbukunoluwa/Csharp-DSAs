

Arrays and lists are random access data structures, stack and queues are limited access data structures

you cannot access every element from the data structure , the way of accessing elements from the data structure is strictly specified

For example, you can get only the first or the last element, but you cannot get the nth element from the data structure.
The popular representatives of limited access data structures are stacks and queues.

## Stack
- push , pop LIFO last in first out

## Tower of hanoi
The game requires three rods which you can put discs , each disc has a different size
at the beginning all discs are placed on the first rod forming a stack , ordered from smallest to biggest from top to bottom
The aim of the game is to move all the discs from the first rod (FROM) to the second one (TO). However, during the whole game,
you cannot place a bigger disc on a smaller one. Moreover, you can only move one disc at a time and, of course, you can only take a disc from the top of any rod

 Generally speaking, the number of moves can be calculated with the formula 2^n - 1,
 where n is the number of discs.

## Queue

 a queue is a data structure that operates on the first-in first-out principle
 just like a queue of people lined up , the first person on the list gets attended to
 then the next person , now referring to the data structure we can only add new elements at the beginning of the queue
 (the enqueue operation) and remove elements from the end of the queue (the dequeue operation )
It is worth mentioning that the Enqueue method is an O(1) operation, if the internal array does not need to be reallocated, or O(n) otherwise,
where n is the number of elements in the queue. Both Dequeue and Peek are O(1) operations.


internal is the default if no access modifier is specified

Struct members, including nested classes and structs, can be declared public , internal , or private .
Class members, including nested classes and structs, can be public , protected internal , protected ,
internal , private protected , or private

      
## Notes on Call center with multiple consultants
For the Call Center with multiple Consultants , we need to make sure that if there are

If there are more incoming calls than available consultants , a new call will be added to the queue
and will wait until there is a consultant who can answer the call  If there are too many consultants and few calls,
the consultants will wait for a call. To perform this task, you will create a few threads, which will access the queue.
Therefore, you need to use the thread-safe version of the queue using the ConcurrentQueue class.


## Priority Queue

We extend the concept of a queue by setting a priority for each element of the queue

priority an be specified by an integer value, but it depends on the implementation,

Whether smaller or higher values indicate higher priority

in this case, the dequeue method will return the element with the highest priority

the one with the highest priority will be added to the beginning of the queue

the one with the lowest priority will be placed at the end of the priority queue



