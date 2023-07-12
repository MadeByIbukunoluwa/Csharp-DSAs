// This class represents the whole tree

//A tree consists of multiple nodes , including one root , the root does not contain a parent node
//while all other nodes do.

//The c# based implementation of a basic tree requires you declare two classes
// one representing a single node and a whole tree


public class Tree<T>
{
    public TreeNode<T> Root { get; set; }
}


// the clas only contians one property - Root . We can use this property
//to get access to the root node then you can use its Children property
//to obtain data of other nodes located in the tree.