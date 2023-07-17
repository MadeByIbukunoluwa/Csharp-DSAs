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

