public class Node<T>
{
    public int Index { set; get; }

    public T Data { set; get; }

    // represents the adjacency list for each node
    public List<Node<T>> Neighbors { get; set; } = new List<Node<T>>();

    // Stores weights assigned to the adjacent edges , if a graph is unweighted,
    // the Weights list is empty
    public List<int> Weights { get; set; } = new List<int>();

    public override string ToString()
    {
        return $"Node with index {Index} : {Data}, neighbours: {Neighbors.Count}";
    }
}

