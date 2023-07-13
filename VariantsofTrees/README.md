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
