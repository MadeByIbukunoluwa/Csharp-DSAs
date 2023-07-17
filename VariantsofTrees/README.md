## Binary trees

Each node in a abasic tree can contain any number of children . however in a binary tree each node can only
contain not more than two children , for this reason the child nodes are referred to as the left child
or the right child

## Iterating through the nodes of a binary tree
How can you specify the order of nodes during traversal of a tree ?
There are three common approaches
Pre-order , in-order and post-order

Pre-order
Iterating with a pre-irder approach , we first visit the root node, then the left child, and the right child
then its left child (the whole left subtree using the pre-order approach recursively), and finally its
right child (the right subtree in a similar way).

Height of the tree - maximum number of steps to travel from any leaf node to the root


## Binary Search Tree
A binary search tree is a more restricted version of a binary tree , where there are
rules guiding the relationship between nodes in the tree 
- Value of all nodes in its left subtree must be smaller than its right value
- Value of all nodes in right subtree must be greater than its left value


because to lookup a value in a BST requires that you go through the nodes in the tree
the shape of the tree surely has impact on the lookup performance

it is much better to have a fat tree with limited height than a skinny tree with bigger height
In the worst case, when each node contains only one child, the search time is even linear.
However, in the ideal BST, the lookup time is the O(log n) operation.

## AVL trees
variants of self balancing trees , which keeps the tree balanced all the time while adding and removing
nodes, the performance of the lookup time depends on the shape of the tree , in the case of improper organization
of nodes, the process of seaching for a value can be O(n), with a correctly arranged tree,the performance can be
significantly improved to O(log n)

what is an AVL tree? How does it work? What rules should be taken into account while using this data structure?

An AVL is a tree where the height of the left subtree and right subtrees cannot differ more than one , it is
a binary search tree , the important role is performed by rotations , used to fix incorrect arrangements of nodes

Performance of AVL tree - in the worst and best case scenarios of insertion , removal and lookup everything is O(logn)
there is a significant improvment in the worst case scenarios in comparsion with the binary tree 

Simple test to make BST unbalanced - just add ordered numbers to create a long and skinny tree

## Red Black trees

A red black tree also known as RBT is another variant of slef balancing binary trees
It requires that the standard BST rules must be obeyed
Each node must be red or black , thus you need to add additional data for a node that stores a color

All nodes with values cannot be leaf nodes. For this reason, the NIL pseudo- nodes should be used as leaves
in the tree, while all other nodes are internal ones. Moreover, all NIL pseudo-nodes must be black.
If a node is red, both its children must be black.
For any node, the number of black nodes on the route to a descendant leaf (that is, the NIL pseudo-node) must be the same.


Similarly to AVL trees, RBTs also must maintain the rules after adding or removing a node. In this case, the process of
restoring the RBT properties is even more complicated, because it involves both recoloring and rotations


it is also worth noting the performance. In both average and worst-case scenarios, insertion, removal, and lookup
are O(log n) operations, so they are the same as in the case of the AVL trees and much better in worst-case scenarios
in comparison with the BSTs.


## Binary Heaps 
A heap is another variant of a tree , which exists in two versions min-heap and max heap

   For min heap - the value fo each node must be greater or equal to the value of the parent node
   For max heap - the value of each node must be lesss than or equal to the value of its parent node
   that the root node always contains the smallest (in the min-heap) or the largest (in the max-heap) value.

   binary heaps must adhere to the binary tree rule where each node cannot contain more than two children
   levels of the tree must be fully filled except the last one
   which must be filled from left to right and can have some empty space on the right.

   The heap sort algorithm has O(n * log(n)) time complexity


## Binomial Heaps

   - consists of a set of binomial trees with different orders
   - The binomial trees with order 0 is just a single node
   - You can construct the tree with order n using two binomial trees with order n - 1

   How can we know how many binomial trees should be located in the binomial trees should
   be located in the binomial heap, as well as how many nodes should they contain ???

   The answer could be a bit surprising, because you need to prepare the binary
   representation of the number of nodes. As an example, let's create a binomial heap with 13 elements.
   The number 13 has the following binary representation: 1101, namely 1*2^0 + 0*2^1 + 1*2^2 + 1*2^3.

## Fibonacci heaps

A Fibonacci heap is an interesting variant of heaps, which in some ways is similar to a binomial heap.
First of all, it also consists of many trees, but there are no constraints regarding the shape of each tree,
so it is much more flexible than the binomial heap. Moreover, it is allowed to have more than one tree with
exactly the same shape in the heap.

One of the important assumptions is that each tree is a min-heap. Thus, the minimum value in the whole
Fibonacci heap is certainly a root node in one of the trees. Moreover, the presented data structure
supports performing various operations in the lazy way.