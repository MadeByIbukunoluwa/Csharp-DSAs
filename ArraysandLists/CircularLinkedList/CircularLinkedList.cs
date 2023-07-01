// we will create CircularLinkedlist aas a class that extends LinkedList
// Also the implementation of the GetEnumerator method, which uses the CircularLinkedListEnumerator class.
// By creating it, you will be able to indefinitely iterate through all the elements of the circular- linked list,
// using the foreach loop.


// error in code of book, page 86

//https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=net-7.0

using System.Collections;

public class CircularLinkedList<T> : LinkedList<T> {
    public new IEnumerator<T> GetEnumerator()
    {
        return new CircularLinkedListEnumerator<T>(this);
    }
}


public class CircularLinkedListEnumerator<T> : IEnumerator<T>
{
    private LinkedListNode<T> _current;
    public T Current => _current.Value;
    object IEnumerator.Current => Current;

    public CircularLinkedListEnumerator(LinkedList<T> list)
    {
        _current = list.First;
    }
    public bool MoveNext()
    {
        if (_current == null)
        {
            return false;
        }
        _current = _current.Next ?? _current.List.First;
        return true;
    }
    public void Reset()
    {
        _current = _current.List.First;
    }
    public void Dispose() { } 
}

