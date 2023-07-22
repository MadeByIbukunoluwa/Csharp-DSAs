
public class Edge<T>
{
    // represents nodes adjacent to the edge 
    public Node<T> From { get; set; }
    public Node<T> To { get; set; }

    // weight of the edge
    public int Weight { get; set; }

    public override string ToString()
    {
        return $"Edge: {From.Data} -> {To.Data},weight: {Weight}";
    }
}
