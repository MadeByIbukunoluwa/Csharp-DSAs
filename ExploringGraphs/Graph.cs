using Priority_Queue;

public class Graph<T>
{
    // these two fields indicate whether the edges are directed and weighted 
    private bool _isDirected = false;
    private bool _isWeighted = false;
    // Nodes - stores a lost of nodes existing in the graph
    public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

    // the values of the private fields _isDirected and _isWeighted is set
    // according to the values of the parameters passed to the constructor 
    public Graph(bool isDirected, bool isWeighted)
    {
        _isDirected = isDirected;
        _isWeighted = isWeighted;
    }
    //This is an indexer , and indexer allows an instance of a class or struct
    // to be indexed as an array
    public Edge<T> this[int from, int to]
    {
        get
        {
            Node<T> nodeFrom = Nodes[to];
            Node<T> nodeTo = Nodes[to];
            int i = nodeFrom.Neighbors.IndexOf(nodeTo);
            if (i >= 0)
            {
                Edge<T> edge = new Edge<T>()
                {
                    From = nodeFrom,
                    To = nodeTo,
                    Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
                };
                return edge;
            }
            return null;
        }
    }

    public Node<T> AddNode(T value)
    {
        Node<T> node = new Node<T> { Data = value };
        Nodes.Add(node);
        UpdateIndices();
        return node;
    }
    //The method takes one parameter, namely an instance of the node that should be removed.
    //First, you remove it from the collection of nodes. Then, you update the indices of the
    //remaining nodes. At the end, you iterate through all nodes in the graph to remove all
    //edges that are connected with the node that has been removed.
    public void RemoveNode(Node<T> nodeToRemove)
    {
        Nodes.Remove(nodeToRemove);
        UpdateIndices();
        foreach (Node<T> node in Nodes)
        {
            RemoveEdge(node, nodeToRemove);
        }
    }
    // The AddEdge function takes three parameters , namely , the two nodes
    //connected by the edge from and to and the weight of the connection
    public void AddEdge(Node<T> from, Node<T> to, int weight = 0)
    {
        if (_isWeighted)
        {
            from.Weights.Add(weight);
        }
        if (_isDirected)
        {
            to.Neighbors.Add(from);

            if (_isWeighted)
            {
                to.Weights.Add(weight);
            }
        }
    }

    public void RemoveEdge(Node<T> from, Node<T> to)
    {
        int index = from.Neighbors.FindIndex(n => n == to);
        if (index >= 0)
        {
            from.Neighbors.RemoveAt(index);
            if (_isWeighted)
            {
                from.Weights.RemoveAt(index);
            }
        }
    }

    public List<Edge<T>> GetEdges()
    {
        List<Edge<T>> edges = new List<Edge<T>>();

        foreach (Node<T> from in Nodes)
        {
            for (int i = 0; i < from.Neighbors.Count; i++)
            {
                Edge<T> edge = new Edge<T>()
                {
                    From = from,
                    To = from.Neighbors[i],
                    Weight = i < from.Weights.Count ? from.Weights[i] : 0
                };
                edges.Add(edge);
            }
        }
        return edges;
    }

    private void UpdateIndices()
    {
        int i = 0;
        Nodes.ForEach(n => n.Index = i++);
    }

    public List<Node<T>> DFS()
    {
        bool[] isVisited = new bool[Nodes.Count];
        List<Node<T>> result = new List<Node<T>>();
        DFS(isVisited, Nodes[0], result);
        return result;
    }

    private void DFS(bool[] isVisited, Node<T> node, List<Node<T>> result)
    {
        // add the node to the list of visited(traversed) nodes 
        result.Add(node);
        //update the element in the isVisited array with true indicated that
        // it has been visited 
        isVisited[node.Index] = true;
        // iterate through the neighbours of the current node
        foreach (Node<T> neighbor in node.Neighbors)
        {
            // only visit the neighbour nodes that have not been visited
            if (!isVisited[neighbor.Index])
            {
                DFS(isVisited, neighbor, result);
            }
        }
    }
    public List<Node<T>> BFS()
    {
        return BFS(Nodes[0]);
    }
    public List<Node<T>> BFS(Node<T> node)
    {
        bool[] isVisited = new bool[Nodes.Count];

        isVisited[node.Index] = true;
        // list for storing the traversed nodes 
        List<Node<T>> result = new List<Node<T>>();
        //queue for storing nodes that should be visited in the following iterations
        Queue<Node<T>> queue = new Queue<Node<T>>();

        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            // Get the first node from the queue
            Node<T> next = queue.Dequeue();
            //Add it to the list of visited nodes 
            result.Add(next);

            // iterate through the neighbours of the nodes 
            foreach (Node<T> neighbour in next.Neighbors)
            {
                // check if the node is not visited 
                if (!isVisited[neighbour.Index])
                {
                    // mark it as visited, then add it to the queue
                    isVisited[neighbour.Index] = true;
                    queue.Enqueue(neighbour);
                }
            }
        }
        return result;
    }
    public List<Edge<T>> MinimumSpanningTreeKruskal()
    {
        //a list of edges are gotten by the getEdges method
        List<Edge<T>> edges = GetEdges();

        foreach (Edge<T> edge in edges)
        {
            Console.WriteLine(edge);
        }
        // the edges are sorted in ascending order
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        // a new queue is created and the edges are enqueued
        Queue<Edge<T>> queue = new Queue<Edge<T>>(edges);

        // an array with data of subsets is created 
        Subset<T>[] subsets = new Subset<T>[Nodes.Count];

        //by default,each node is added to a separate subset, its why the
        //number of elemnts in the subsets array is equal to the number of nodes
        // the subsets are used to check whether an addition of an edge to the MST
        //causes the creation of a cycle 
        for (int i = 0; i < Nodes.Count; i++)
        {
            subsets[i] = new Subset<T>() { Parent = Nodes[i] };
        }
        List<Edge<T>> result = new List<Edge<T>>();
        while (result.Count < Nodes.Count - 1)
        {
            Edge<T> edge = queue.Dequeue();
            Node<T> from = GetRoot(subsets, edge.From);
            Node<T> to = GetRoot(subsets, edge.To);
            if (from != to)
            {
                result.Add(edge);
                Union(subsets, from, to);
            }
        }
        return result;
    }
    public List<Edge<T>> MinimumSpanningTreePrim()
    {
        int[] previous = new int[Nodes.Count];
        previous[0] = -1;
        int[] minWeight = new int[Nodes.Count];
        Fill(minWeight, int.MaxValue);
        minWeight[0] = 0;
        bool[] isInMST = new bool[Nodes.Count];
        Fill(isInMST, false);
        for (int i = 0; i < Nodes.Count - 1; i++)
        {
            int minWeightIndex = GetMinimumWeightIndex(minWeight, isInMST);
            isInMST[minWeightIndex] = true;

            for (int j = 0; j < Nodes.Count; j++)
            {
                Edge<T> edge = this[minWeightIndex, j];
                int weight = edge != null ? edge.Weight : -1;
                if (edge != null && !isInMST[j] && weight < minWeight[j])
                {
                    previous[j] = minWeightIndex;
                    minWeight[j] = weight;
                }
            }
        }
        List<Edge<T>> result = new List<Edge<T>>();
        for (int i = 1; i < Nodes.Count; i++)
        {
            Edge<T> edge = this[previous[i], i];
            result.Add(edge);
        }
        return result;
    }

    private Node<T> GetRoot(Subset<T>[] subsets, Node<T> node)
    {
        if (subsets[node.Index].Parent != node)
        {
            subsets[node.Index].Parent = GetRoot(
                  subsets, subsets[node.Index].Parent
            );
        }
        return subsets[node.Index].Parent;
    }

    //performs the union operation (by a rank) of two sets 

    private void Union(Subset<T>[] subsets, Node<T> a, Node<T> b)
    {
        if (subsets[a.Index].Rank > subsets[b.Index].Rank)
        {
            subsets[b.Index].Parent = a;
        } else if (subsets[a.Index].Rank < subsets[b.Index].Rank)
        {
            subsets[a.Index].Parent = b;
        }
        else
        {
            subsets[b.Index].Parent = a;
            subsets[a.Index].Rank++;
        }
    }
    // This methods just finds the index of a node which is not located in the MST and can be
    // reached with the minimum cost 
    private int GetMinimumWeightIndex(int[] weights, bool[] isInMST)
    {
        int minValue = int.MaxValue;
        int minIndex = 0;

        for (int i = 0; i < Nodes.Count; i++)
        {
            if (!isInMST[i] && weights[i] < minValue)
            {
                minValue = weights[i];
                minIndex = i;
            }
        }
        return minIndex;
    }
    private void Fill<Q>(Q[] array, Q value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }
    public int[] Color()
    {
        int[] colors = new int[Nodes.Count];
        Fill(colors, -1);
        colors[0] = 0;
        bool[] availability = new bool[Nodes.Count];
        for (int i = 1; i < Nodes.Count; i++)
        {
            Fill(availability, true);
            int colorIndex = 0;
            foreach (Node<T> neighbor in Nodes[i].Neighbors)
            {
                colorIndex = colors[neighbor.Index];
                if (colorIndex >= 0)
                {
                    availability[colorIndex] = false;
                }
            }
            colorIndex = 0;
            for (int j = 0; j < availability.Length; j++)
            {
                if (availability[j])
                {
                    colorIndex = j;
                    break;
                }
            }
            colors[i] = colorIndex;
        }
        return colors;
    }
    // i added an array of colors
    public String[] ListOfColors = new String[]{"Green","Red","Blue","Yellow","Orange","Brown","Pink","Indigo","Violet","Purple",};

    public List<Edge<T>> GetShortestPathDijkstra(Node<T> source, Node<T> target)
    {
        int[] previous = new int[Nodes.Count];
        Fill(previous, -1);
        int[] distances = new int[Nodes.Count];
        Fill(distances, int.MaxValue);
        distances[source.Index] = 0;
        SimplePriorityQueue<Node<T>> nodes = new SimplePriorityQueue<Node<T>>();
        for (int i = 0; i < Nodes.Count; i++)
        {
            nodes.Enqueue(Nodes[i], distances[i]);
        }
        while (nodes.Count != 0)
        {
            Node<T> node = nodes.Dequeue();
            for (int i = 0; i < node.Neighbors.Count; i++)
            {
                Node<T> neighbor = node.Neighbors[i];
                int weight = i < node.Weights.Count ? node.Weights.Count : 0;
                int weightTotal = distances[node.Index] + weight;

                if (distances[neighbor.Index] > weightTotal)
                {
                    distances[neighbor.Index] = weightTotal;
                    previous[neighbor.Index] = node.Index;
                    nodes.UpdatePriority(neighbor, distances[neighbor.Index]);
                }
            }
        }
        List<int> indices = new List<int>();
        int index = target.Index;
        while(index >= 0)
        {
            indices.Add(index);
            index = previous[index];
        }
        indices.Reverse();
        List<Edge<T>> result = new List<Edge<T>>();
        for (int i = 0; i < indices.Count - 1; i++)
        {
            Edge<T> edge = this[indices[i], indices[i + 1]];
            result.Add(edge);
        }
        return result;
    }
}

