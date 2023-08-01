

##Graphs


What is a graph , a graph is a data structure that consists of nodes also called vertices
and edges , each edge connects two nodes , it does not require any specific rules
regarding connections between nodes 

A graph can contain self loops. Each is an edge that connects a given node
with itself
there are graphs with undirected edges , bidirectional edges , they indicate whether
it is possible to travel between nodes in both directions , such edges are presented
graphically as straight lines
when a graph contains undirected edges , it is called an undirected graph
if you want to indicated direction you can use directed edges , it can be named a
directed graph

We can also specify weights (also referred to as costs) for particular edges to
indicate the cost of traveling between nodes
weights can be assigned to both undirected and directed edges, if weights are provided,
an edge is named a weighted edge and the whole graph a weighted graph , if no weights
are provided, unweighted edges are used in a graph that can be called an
unweighted graph

Graphs are commonly used to solve algorithmic problems and have numerous real world
applications

nodes can represent contacts , and edges can represnt relationships between people
With the usage of the graph data structure you can easily check whether they have a common
contact

- searching for the shortest path

## How do we represent graphs in the memory of a coomputer
- adjacency list
- adjacency matrix

### Adjacency List
    -  extends the data of a node by specifying the list of its neighbors
    - thus you can easily get all neighbours of a given node just by iterating
    through the adjacency list of a given node , such solution is efficent, because you
    only store the data of adjacent edges

### Adjacency matrix
    - Another approach to graph representation is the adjacency matrix , which uses two dimensional
     array to show which nodes are connected by edges , the matrix contains the same number of rows and columns,
     which is equal to the number of nodes . The main idea is to store information about a particular edge in an element
     at a given row and column in the matrix. The index of the row and column depends on the nodes connected with the edge 

     To start, let's analyze the basic scenario of an undirected and unweighted graph. In such a case, the adjacency matrix
     may store only Boolean values. The true value placed in the element at i row and j column indicates that there is a
     connection between a node with an index equal to i and the node with index j.

## Graph Traversal
that is, visiting all of the nodes in some particular order. Of course, the afore mentioned problem can be solved in various ways,
such as using depth-first search (DFS) or breadth-first search (BFS), it is strictly connected with
the task of searching for a given node in the graph

## Depth First Search (DFS)
Depth first search is a traversal algorithm were you visit a current node , check if any of the neighbours
are visited , then visit the neighbour that is not visited , repeat for that next node, until
you have traversed all the nodes in the graph.
The algorithm tries to go as deep as possible nd then goes back to find the next unvisited neighbour
that can be traversed 

## Breadth first Search
in BFS , we visit all the neighbours of th current node before we go to the next one and then
proceed to the next level of nodes , until all the nodes in the graph have been traversed 



## Prims Algorithm
th additonal indicators next to the graph represent the minimum weight necessary to reach a node
from any of its neighbours . By default, the starting node has such a value set to zeo while all others
are set to inifinity
