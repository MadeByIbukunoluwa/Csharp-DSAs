
// Every node in the BST as to be comparable hence the BinarySearchTree class has to
// implement the IComparable interface
public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable
{
    //lookup method
    public bool Contains(T data)
    {
        BinaryTreeNode<T> node = Root;
        while (node != null)
        {
            // the searched value is cmpared with the value of the current node 
            // if they are equal,the comparison returns 0 as a result 
            int result = data.CompareTo(node.Data);
            // if the result is zero , then the value we are searching for
            // is the current node we then return true
            if (result == 0)
            {
                return true;
            }
            // if the result is less than zero , which indicates that the data we are searching for
            // is not the same as the current node , we go down the the left subtree of the node
            else if (result < 0)
            {
                node = node.Left;
            }
            //Or we go down the the right subtree of the node
            else
             {
                node = node.Right;
            }
        }
        return false;
    }

    public void Add(T data)
    {
        BinaryTreeNode<T> parent = GetParentForNewNode(data);
        BinaryTreeNode<T> node = new BinaryTreeNode<T>()
        {
            Data = data,
            Parent = parent
        };
        if (parent == null)
        {
            Root = node;
        }
        else if (data.CompareTo(parent.Data) < 0)
        {
            parent.Left = node;
        }
        else
        {
            parent.Right = node;
        }

        Count++;
    }

    private BinaryTreeNode<T> GetParentForNewNode(T data)
    {
        BinaryTreeNode<T> current = Root;
        BinaryTreeNode<T> parent = null;


        while (current != null)
        {
            parent = current;
            int result = data.CompareTo(current.Data);
            if (result == 0)
            {
                throw new ArgumentException($"The node {data} already exists");
            }
            else if (result < 0)
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }
        }
        return parent;
    }
    public void Remove(T data)
    {
        Remove(Root, data);
    }
    private void Remove(BinaryTreeNode<T> node, T data)
    {
        if (node == null)
        {
            throw new ArgumentException($"The node {data} does not exist");
        }
        else if (data.CompareTo(node.Data) < 0)
        {
            Remove(node.Left, data);
        }
        else if (data.CompareTo(node.Data) > 0)
        {
            Remove(node.Right, data);
        }else
        {
            if (node.Left == null && node.Right == null)
            {
                ReplaceInParent(node, null);
                Count--;
            }
            else if (node.Right == null)
            {
                ReplaceInParent(node, node.Left);
                Count--;
            }
            else if (node.Left == null)
            {
                ReplaceInParent(node, node.Right);
            } else
            {
                BinaryTreeNode<T> successor = findMinimumInSubtree(node.Right);
                node.Data = successor.Data;
                Remove(successor, successor.Data);
            }
        }
    }
    private void ReplaceInParent(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
    {
        if (node.Parent != null)
        {
            if (node.Parent.Left == node) 
            {
                node.Parent.Left = newNode;
            }
            else 
            {
                node.Parent.Right = newNode;
            }
        }
        else
        {
            Root = newNode;
        }
        if(newNode != null)
        {
            newNode.Parent = node.Parent;
        }
    }

    // we iterate through the left nodes of the tree , as we know, the rule
    // in the BST is the left node is lesser in value than the right value

    private BinaryTreeNode<T> findMinimumInSubtree (BinaryTreeNode<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }


}