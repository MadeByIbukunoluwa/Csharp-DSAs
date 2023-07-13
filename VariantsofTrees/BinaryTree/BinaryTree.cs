

public class BinaryTree<T>
{
    public BinaryTreeNode<T> Root { get; set; }
    public int Count { get; set; }

    private void TraversePreOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            result.Add(node);
            TraversePreOrder(node.Left, result);
            TraversePreOrder(node.Right, result);
        }
    }
    private void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            // call the TraverseInOrder method for the left child , add the current node to the list
            // of visited nodes , and start the in-order traversal for the right child 
            TraverseInOrder(node.Left, result);
            result.Add(node);
            TraverseInOrder(node.Right, result);
        }
    }
    private void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraversePostOrder(node.Left, result);
            TraversePostOrder(node.Right, result);
            result.Add(node);
        }
    }
    //public method for traversing the tree in various modes
    public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode)
    {
        List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>();
        switch (mode)
        {
            case TraversalEnum.PREORDER:
                TraversePreOrder(Root, nodes);
                break;
            case TraversalEnum.INORDER:
                TraverseInOrder(Root, nodes);
                break;
            case TraversalEnum.POSTORDER:
                TraversePostOrder(Root, nodes);
                break;
        }
        return nodes;
    }
    public int GetHeight()
    {
        int height = 0;
        foreach(BinaryTreeNode<T> node in Traverse(TraversalEnum.PREORDER))
        {
            height = Math.Max(height, node.GetHeight());
        }
        return height;
    }
    //The code just iterates through all nodes of the tree using the pre-order traversal,
    //reads the height for the current node (using the GetHeight method from the TreeNode class,
    //described earlier), and saves it as the maximum one, if it is larger than the current maximum value.
    //At the end, the calculated height is returned.
}
 
  