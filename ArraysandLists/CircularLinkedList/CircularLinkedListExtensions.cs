using System.Collections;

//So, when you use the extension method, the generic type <T> is inferred from the type of the LinkedList<T>
//instance you are calling the method on. Therefore, the generic type parameter <T> is not throwing an error
//because it is correctly matching the type of the LinkedList<T>.

public static class CircularLinkedListExtensions
{
    public static LinkedListNode<T> Next<T>(this LinkedListNode<T> node)
    {
        if (node != null && node.List != null)
        {
            return node.Next ?? node.List.First;
        }
        return null;
    }

    public static LinkedListNode<T> Previous<T>(this LinkedListNode<T> node)
    {
        if (node != null && node.List != null)
        {
            return node.Previous ?? node.List.Last;
        }
        return null;
    }

}

