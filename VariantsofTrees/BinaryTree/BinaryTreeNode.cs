
public class BinaryTreeNode<T> : TreeNode<T>
{
    public BinaryTreeNode<T> Parent { get; set; }

    public BinaryTreeNode() => Children = new List<TreeNode<T>>() { null, null };

    public BinaryTreeNode<T> Left
    {
        get { return (BinaryTreeNode<T>)Children[0]; }
        set { Children[0] = value; }
    }
    public BinaryTreeNode<T> Right
    {
        get { return (BinaryTreeNode<T>)Children[1]; }
        set { Children[1] = value; }
    }
    public int GetHeight()
    {
        BinaryTreeNode<T> current = this;
        int height = 1;
        while (current.Parent != null)
        {
            height++;
            current = current.Parent;
        }
        return height;
    }
 }

