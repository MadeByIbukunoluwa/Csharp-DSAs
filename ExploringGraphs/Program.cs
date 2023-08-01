
using System;
using System.Text;

namespace Graphs
{
    public class graph
    {
        public static void Main(string[] args)
        {

            // undirected and  unweighted graph
            //Graph<int> graph = new Graph<int>(false, false);
            //// added nodes the the graph 
            //Node<int> n1 = graph.AddNode(1);
            //Node<int> n2 = graph.AddNode(2);
            //Node<int> n3 = graph.AddNode(3);
            //Node<int> n4 = graph.AddNode(4);
            //Node<int> n5 = graph.AddNode(5);
            //Node<int> n6 = graph.AddNode(6);
            //Node<int> n7 = graph.AddNode(7);
            //Node<int> n8 = graph.AddNode(8);

            //added edges between the nodes
            //graph.AddEdge(n1, n2);
            //graph.AddEdge(n1, n3);
            //graph.AddEdge(n2, n4);
            //graph.AddEdge(n3, n4);
            //graph.AddEdge(n4, n5);
            //graph.AddEdge(n5, n6);
            //graph.AddEdge(n5, n7);
            //graph.AddEdge(n5, n8);
            //graph.AddEdge(n6, n7);
            //graph.AddEdge(n7, n8);

            // weighted and directed graph

            //Graph<int> graph1 = new Graph<int>(true, true);

            //Node<int> node1 = graph1.AddNode(1);
            //Node<int> node2 = graph1.AddNode(2);
            //Node<int> node3 = graph1.AddNode(3);
            //Node<int> node4 = graph1.AddNode(4);
            //Node<int> node5 = graph1.AddNode(5);
            //Node<int> node6 = graph1.AddNode(6);
            //Node<int> node7 = graph1.AddNode(7);
            //Node<int> node8 = graph1.AddNode(8);

            // There are eight nodes confirmed 
            //Console.WriteLine(graph1.Nodes.Count);

            //Traversal
            // Depth First Search
            //graph1.AddEdge(node1, node2, 9);
            //graph1.AddEdge(node8, node5, 3);
            //graph1.AddEdge(node2, node1, 3);
            //graph1.AddEdge(node2, node4, 18);
            //graph1.AddEdge(node3, node4, 12);
            //graph1.AddEdge(node4, node2, 2);
            //graph1.AddEdge(node4, node8, 8);
            //graph1.AddEdge(node5, node4, 9);
            //graph1.AddEdge(node5, node6, 2);
            //graph1.AddEdge(node5, node7, 5);
            //graph1.AddEdge(node5, node8, 3);
            //graph1.AddEdge(node6, node7, 1);
            //graph1.AddEdge(node7, node5, 4);
            //graph1.AddEdge(node7, node8, 6);
            //graph1.AddEdge(node8, node5, 3);

            //There are 2 edges confirmed 
            //Console.WriteLine(graph1.GetEdges().Count);

            //List<Node<int>> dfsNodes = graph1.DFS();
            // The mistake i made that made me spend a few minutes debugging
            // was that i did not add edges between the nodes, so its like the nodes of the graph were
            //floating in space (if we visualize it)
            //Thats why when we always ran the code for DFS , we got only this as the output
            //Node with index 0 : 1, neighbours: 0
            //Console.WriteLine(dfsNodes.Count);
            // we are iterating through elements of the list to print some basic
            //information about each node 
            //dfsNodes.ForEach(n => Console.WriteLine(n));

            //Breadth First Search
            //Graph<int> graph2 = new Graph<int>(true, true);
            //Node<int> n1 = graph2.AddNode(1);
            //Node<int> n2 = graph2.AddNode(2);
            //Node<int> n3 = graph2.AddNode(3);
            //Node<int> n4 = graph2.AddNode(4);
            //Node<int> n5 = graph2.AddNode(1);
            //Node<int> n6 = graph2.AddNode(6);
            //Node<int> n7 = graph2.AddNode(7);
            //Node<int> n8 = graph2.AddNode(8);

            //graph2.AddEdge(n1, n2, 9);
            //graph2.AddEdge(n8, n5, 3);
            //graph2.AddEdge(n2, n1, 3);
            //graph2.AddEdge(n2, n4, 18);
            //graph2.AddEdge(n3, n4, 12);
            //graph2.AddEdge(n4, n2, 2);
            //graph2.AddEdge(n4, n8, 8);
            //graph2.AddEdge(n5, n4, 9);
            //graph2.AddEdge(n5, n6, 2);
            //graph2.AddEdge(n5, n7, 5);
            //graph2.AddEdge(n5, n8, 3);
            //graph2.AddEdge(n6, n7, 1);
            //graph2.AddEdge(n7, n5, 4);
            //graph2.AddEdge(n7, n8, 6);
            //graph2.AddEdge(n8, n5, 3);

            //List<Node<int>> bfsNodes = graph2.BFS();
            //bfsNodes.ForEach(n => Console.WriteLine(n));
            //Console.ReadLine();

            //Minimum Spanning Tree kruskal
            // when i make the graph directed it can count the edges
            // when i make it undirected it can't count edges 
            //Graph<int> graph3 = new Graph<int>(false, true);

            // There are 8 nodes confirmed
            //Console.WriteLine(graph3.Nodes.Count());
            //Node<int> node1 = graph3.AddNode(1);
            //Node<int> node2 = graph3.AddNode(2);
            //Node<int> node3 = graph3.AddNode(3);
            //Node<int> node4 = graph3.AddNode(4);
            //Node<int> node5 = graph3.AddNode(5);
            //Node<int> node6 = graph3.AddNode(6);
            //Node<int> node7 = graph3.AddNode(7);
            //Node<int> node8 = graph3.AddNode(8);

            //graph3.AddEdge(node1, node2, 3);
            //graph3.AddEdge(node1, node3, 5);
            //graph3.AddEdge(node2, node4, 4);
            //graph3.AddEdge(node3, node4, 12);
            //graph3.AddEdge(node4, node5, 9);
            //graph3.AddEdge(node5, node6, 4);
            //graph3.AddEdge(node5, node7, 5);
            //graph3.AddEdge(node6, node7, 6);
            //graph3.AddEdge(node5, node8, 1);
            //graph3.AddEdge(node4, node8, 8);
            //graph3.AddEdge(node7, node8, 20);

            //Console.WriteLine(graph3.GetEdges().Count());
            //List<Edge<int>> mstKruskal = graph3.MinimumSpanningTreeKruskal();
            //mstKruskal.ForEach(e => Console.WriteLine(e));
            //Console.ReadLine();

            //Prims Algorithm
            //List<Edge<int>> mstPrim = graph3.MinimumSpanningTreePrim();
            //mstPrim.ForEach(e => Console.WriteLine(e));

            //Telecommunication Cables

            //Coloring Graphs
            Graph<int> graph4 = new Graph<int>(true, true);
            Node<int> node1 = graph4.AddNode(1);
            Node<int> node2 = graph4.AddNode(2);
            Node<int> node3 = graph4.AddNode(3);
            Node<int> node4 = graph4.AddNode(4);
            Node<int> node5 = graph4.AddNode(5);
            Node<int> node6 = graph4.AddNode(6);
            Node<int> node7 = graph4.AddNode(7);
            Node<int> node8 = graph4.AddNode(8);

            graph4.AddEdge(node1, node2, 3);
            graph4.AddEdge(node1, node3, 5);
            graph4.AddEdge(node2, node4, 4);
            graph4.AddEdge(node3, node4, 12);
            graph4.AddEdge(node4, node5, 9);
            graph4.AddEdge(node5, node6, 4);
            graph4.AddEdge(node5, node7, 5);
            graph4.AddEdge(node6, node7, 6);
            graph4.AddEdge(node5, node8, 1);
            graph4.AddEdge(node4, node8, 8);
            graph4.AddEdge(node7, node8, 20);
            //only works when its directed 
            //int[] colors = graph4.Color();
            //String[] colorsList = graph4.ListOfColors;
            //Here, you create a new undirected and unweighted graph,
            //add nodes and edges, and call the Color method to perform
            //the node coloring. As a result, you receive an array with
            // strings of colors from the indices gotten for particular nodes
            //for (int i = 0; i < colors.Length; i++)
            //{
            //    Console.WriteLine($"Node {graph4.Nodes[i].Data} : {colorsList[colors[i]]}");
            //}
            //Console.ReadLine();
            //voivodeship
            //color nodes in the graph using the graph coloring algorithm
            //Graph<string> graphV = new Graph<string>(true, false);
            //Node<string> nodePK = graphV.AddNode("PK");
            //Node<string> nodeMA = graphV.AddNode("MA");
            //Node<string> nodeSL = graphV.AddNode("SL");
            //Node<string> nodeOP = graphV.AddNode("OP");
            //Node<string> nodeDS = graphV.AddNode("DS");
            //Node<string> nodeLB = graphV.AddNode("LB");
            //Node<string> nodeWP = graphV.AddNode("WP");
            //Node<string> nodeZP = graphV.AddNode("ZP");
            //Node<string> nodeKP = graphV.AddNode("KP");
            //Node<string> nodePM = graphV.AddNode("PM");
            //Node<string> nodeWM = graphV.AddNode("WM");
            //Node<string> nodeMZ = graphV.AddNode("MZ");
            //Node<string> nodePD = graphV.AddNode("PD");
            //Node<string> nodeLD = graphV.AddNode("LD");
            //Node<string> nodeSK = graphV.AddNode("SK");
            //Node<string> nodeLU = graphV.AddNode("LU");

            //graphV.AddEdge(nodePK,nodeLU);
            //graphV.AddEdge(nodeSK,nodePK);
            //graphV.AddEdge(nodeSK,nodeMA);
            //graphV.AddEdge(nodeSL,nodeMA);
            //graphV.AddEdge(nodeOP,nodeSL);
            //graphV.AddEdge(nodeDS,nodeOP);
            //graphV.AddEdge(nodeLB,nodeDS);
            //graphV.AddEdge(nodeWP,nodeDS);
            //graphV.AddEdge(nodeLB,nodeWP);
            //graphV.AddEdge(nodeWP,nodeOP);
            //graphV.AddEdge(nodeOP,nodeLD);
            //graphV.AddEdge(nodeWP,nodeLD);
            //graphV.AddEdge(nodeSK,nodeLD);
            //graphV.AddEdge(nodeSK,nodeMZ);
            //graphV.AddEdge(nodeLD,nodeWP);
            //graphV.AddEdge(nodeZP,nodePM);
            //graphV.AddEdge(nodePM,nodeKP);
            //graphV.AddEdge(nodeWP,nodeKP);
            //graphV.AddEdge(nodeWM,nodeKP);
            //graphV.AddEdge(nodeWM,nodeMZ);
            //graphV.AddEdge(nodeKP,nodeLD);
            //graphV.AddEdge(nodeLD,nodeSL);
            //graphV.AddEdge(nodeMZ,nodePD);

            //String[] colorsList = graph4.ListOfColors;
            //int[] colors = graphV.Color();
            //for (int i = 0; i < colors.Length; i++)
            //{
            //    Console.WriteLine($"{graphV.Nodes[i].Data}: {colorsList[colors[i]]}");
            //}
            //Shortest path Dijkstras algorithm

            //List<Edge<int>> shortestPath = graph4.GetShortestPathDijkstra(node1, node5);
            //shortestPath.ForEach(e => Console.WriteLine(e));
            //Game Map
            //finding shortest path in a game map
            string[] lines = new string[]
            {
                   "0011100000111110000011111",
                   "0011100000111110000011111",
                   "0011100000111110000011111",
                   "0000000000011100000011111",
                   "0000001110000000000011111",
                   "0001001110011100000011111",
                   "1111111111111110111111100",
                   "1111111111111110111111101",
                   "1111111111111110111111100",
                   "0000000000000000111111110",
                   "0000000000000000111111100",
                   "0001111111001100000001101",
                   "0001111111001100000001100",
                   "0001100000000000111111110",
                   "1111100000000000111111100",
                   "1111100011001100100010001",
                   "1111100011001100001000100"
            };
            bool[][] map = new bool[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                map[i] = lines[i]
                    .Select(c => int.Parse(c.ToString()) == 0)
                    .ToArray();
            }

            Graph<string> graph = new Graph<string>(false, true);
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j])
                    {
                        Node<string> from = graph.AddNode($"{i}-{j}");
                        if (i > 0 && map[i - 1][j])
                        {
                            Node<string> to = graph.Nodes.Find(
                                n => n.Data == $"{i - 1}-{j}");
                            graph.AddEdge(from, to, 1);
                        }
                        if (j > 0 && map[i][j - 1])
                        {
                            Node<string> to = graph.Nodes.Find(
                                n => n.Data == $"{i}-{j - 1}");
                            graph.AddEdge(from, to, 1);
                        }
                    }
                }
            }
            Node<string> source = graph.Nodes.Find(n => n.Data == "0-0");
            Node<string> target = graph.Nodes.Find(n => n.Data == "16-24");
            List<Edge<string>> path = graph.GetShortestPathDijkstra(
               source, target);
            Console.OutputEncoding = Encoding.UTF8;
            for (int row = 0; row < map.Length; row++)
            {
                for (int column = 0; column < map[row].Length; column++)
                {
                    ConsoleColor color = map[row][column]
                        ? ConsoleColor.Green : ConsoleColor.Red;
                    if (path.Any(e => e.From.Data == $"{row}-{column}"
                        || e.To.Data == $"{row}-{column}"))
                    {
                        color = ConsoleColor.White;
                    }
                    Console.ForegroundColor = color;
                    Console.Write("\u25cf ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
    
        }
    }
}


