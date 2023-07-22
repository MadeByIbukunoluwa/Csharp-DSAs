
using System;
using System.Xml.Linq;

namespace Graphs
{
    public class graph
    {
        public static void Main(string[] args)
        {

            // undirected and  unweighted graph
            Graph<int> graph = new Graph<int>(false, false);
            // added nodes the the graph 
            Node<int> n1 = graph.AddNode(1);
            Node<int> n2 = graph.AddNode(2);
            Node<int> n3 = graph.AddNode(3);
            Node<int> n4 = graph.AddNode(4);
            Node<int> n5 = graph.AddNode(5);
            Node<int> n6 = graph.AddNode(6);
            Node<int> n7 = graph.AddNode(7);
            Node<int> n8 = graph.AddNode(8);

            //added edges between the nodes
            graph.AddEdge(n1, n2);
            graph.AddEdge(n1, n3);
            graph.AddEdge(n2, n4);
            graph.AddEdge(n3, n4);
            graph.AddEdge(n4, n5);
            graph.AddEdge(n5, n6);
            graph.AddEdge(n5, n7);
            graph.AddEdge(n5, n8);
            graph.AddEdge(n6, n7);
            graph.AddEdge(n7, n8);

            // weighted and directed graph

            Graph<int> graph1 = new Graph<int>(true, true);

            Node<int> node1 = graph1.AddNode(1);
            Node<int> node2 = graph1.AddNode(2);
            Node<int> node3 = graph1.AddNode(3);
            Node<int> node4 = graph1.AddNode(4);
            Node<int> node5 = graph1.AddNode(5);
            Node<int> node6 = graph1.AddNode(6);
            Node<int> node7 = graph1.AddNode(7);
            Node<int> node8 = graph1.AddNode(8);

            // There are eight nodes confirmed 
            //Console.WriteLine(graph1.Nodes.Count);

            //Traversal
            // Depth First Search
            graph1.AddEdge(node1, node2, 9);
            graph1.AddEdge(node8, node5, 3);
            graph1.AddEdge(node2, node1, 3);
            graph1.AddEdge(node2, node4, 18);
            graph1.AddEdge(node3, node4, 12);
            graph1.AddEdge(node4, node2, 2);
            graph1.AddEdge(node4, node8, 8);
            graph1.AddEdge(node5, node4, 9);
            graph1.AddEdge(node5, node6, 2);
            graph1.AddEdge(node5, node7, 5);
            graph1.AddEdge(node5, node8, 3);
            graph1.AddEdge(node6, node7, 1);
            graph1.AddEdge(node7, node5, 4);
            graph1.AddEdge(node7, node8, 6);
            graph1.AddEdge(node8, node5, 3);

            //There are 2 edges confirmed
            Console.WriteLine(graph1.GetEdges().Count);

            List<Node<int>> dfsNodes = graph1.DFS();
            // The mistake i made that made me spend a few minutes debugging
            // was that i did not add edges between the nodes, so its like the nodes of the graph were
            //floating in space (if we visualize it)
            //Thats why when we always ran the code for DFS , we got only this as the output
            //Node with index 0 : 1, neighbours: 0
            //Console.WriteLine(dfsNodes.Count);
            // we are iterating through elements of the list to print some basic
            //information about each node 
            dfsNodes.ForEach(n => Console.WriteLine(n));
            Console.ReadLine();
        }
    }
}


