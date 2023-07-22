

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

    private void DFS (bool[] isVisited, Node<T> node,List<Node<T>> result)
    {
        // add the node to the list of visited(traversed) nodes 
        result.Add(node);
        //update the element in the isVisited array with true indicated that
        // it has been visited 
        isVisited[node.Index] = true;
        // iterate through the neighbours of the current node
        foreach(Node<T> neighbor in node.Neighbors)
        {
            // only visit the neighbour nodes that have not been visited
            if (!isVisited[neighbor.Index])
            {
                DFS(isVisited, neighbor, result);
            }
        }
    }

}

