

// This class represents a tree in the node 

public class TreeNode<T>
{
    public T Data { get; set; }
    public TreeNode<T> Parent { get; set; }
    public List<TreeNode<T>> Children {get; set;}


    // the GetHeight method returns the hieght of the node, which is
    // a while loop that iterates through the Parents of the nodes and increments
    // the height variable until there is no more Parent element, the root is reached 
    public int GetHeight ()
    {
        int height = 1;
        TreeNode<T> current = this;
        while (current.Parent != null )
        {
            height++;
            current = current.Parent;
        }
        return height;
    }
}

