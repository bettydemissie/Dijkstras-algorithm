using System;
using System.Xml.Linq;

namespace GraphVersionOne;

//public class LinkedList<T>
//{
//    public ListNode<T> head;
//    public int length = 0;
//    public ListNode<T> tail;

//    public LinkedList()
//    {
//        head = null;
//        tail = null;
//    }

//    public bool isEmpty()
//    {
//        return head == null;
//    }

//    public Object deleteHead()
//    {
//        //if list is not empty
//        if (!isEmpty())
//        {
//            //delete head by setting head to the current position
//            //so it can be rewritten

//            //create variable to store old head in order to return it
//            ListNode<T> oldFirst = new ListNode<T>();
//            oldFirst = head;

//            //set a getter for the next node
//            ListNode<T> next = head.getNext();

//            //assign the first to the next
//            head = next;

//            length--;

//            //return old head
//            return oldFirst.getData();

//        }
//        else
//            return null;
//    }

//    public ListNode<T> getHead()
//    {
//        if (isEmpty())
//        {
//            throw new InvalidOperationException("List is empty.");
//        }
//        return head;
//    }

//    public ListNode<T> getTail()
//    {
//        if (isEmpty())
//        {
//            throw new InvalidOperationException("List is empty.");
//        }
//        return tail;
//    }

//    public void AddFirst(PriorityQueueNode node)
//    {
//        ListNode<T> newNode = new ListNode<T>(node);

//        if (isEmpty())
//        {
//            head = newNode;
//            tail = newNode;
//            length++;
//        }
//        else
//        {
//            newNode.next = head;
//            head = newNode;
//            length++;
//        }
//    }


//    public void insertAfter(PriorityQueueNode node, PriorityQueueNode afterNode)
//    {
//        ListNode<T> newNode = new ListNode<T>(node);
//        ListNode<T> afterListNode = findItem(afterNode);

//        if (afterListNode == null)
//        {
//            throw new ArgumentException("Previous node not found.");
//        }

//        ListNode<T> nextNode = afterListNode.next;
//        afterListNode.next = newNode;
//        newNode.next = nextNode;

//        if (nextNode == null)
//        {
//            tail = newNode;
//            length++;
//        }
//    }

//    public void AddLast(PriorityQueueNode node)
//    {
//        ListNode<T> newNode = new ListNode<T>(node);

//        if (isEmpty())
//        {
//            head = newNode;
//            tail = newNode;
//            length++;
//        }
//        else
//        {
//            tail.next = newNode;
//            tail = newNode;
//            length++;
//        }
//    }

//    public void removeAtHead()
//    {
//        if (isEmpty())
//        {
//            throw new InvalidOperationException("List is empty.");
//        }

//        head = head.next;

//        if (head == null)
//        {
//            tail = null;
//            length--;
//        }
//    }

//    public void removeAfter(ListNode<T> prevNode)
//    {
//        if (prevNode == null)
//        {
//            throw new ArgumentException("Previous node cannot be null.");
//        }

//        ListNode<T> currentNode = prevNode.next;

//        if (currentNode == null)
//        {
//            throw new InvalidOperationException("No next node to remove.");
//        }

//        prevNode.next = currentNode.next;

//        if (currentNode.next == null)
//        {
//            tail = prevNode;
//            length--;
//        }
//    }

//    public ListNode<T> ElementAt(int index)
//    {
//        int currentIndex = 0;
//        ListNode<T> current = head;

//        while (current != null)
//        {
//            if (currentIndex == index)
//            {
//                return current;
//            }

//            current = current.getNext();
//            currentIndex++;
//        }

//        return null; // Return null if the index is out of range
//    }

//    public int Count()
//    {
//        return length;
//    }

//    public ListNode<T> FindItem(PriorityQueueNode node)
//    {
//        ListNode<T> current = head;

//        while (current != null)
//        {
//            if (current.data == node)
//            {
//                return current;
//            }

//            current = current.next;
//        }

//        return null;
//    }

//    public ListNode<T> First()
//    {
//        return head;
//    }

//    public ListNode<T> Last()
//    {
//        return tail;
//    }

//    public void PrintList()
//    {
//        if (head == null)
//        {
//            Console.WriteLine("List is empty");
//        }
//        else
//        {
//            ListNode<T> current = new ListNode<T>();

//            current = head;

//            Console.WriteLine("Items in the list are:");

//            while (current != null)   // not at end of the list
//            {
//                Console.WriteLine(current.getData().ToString());
//                current = current.getNext();
//            }
//        }
//    }
//}

public class LinkedList<T>
{
    public ListNode<T> head;
    public int length = 0;
    public ListNode<T> tail;

    public LinkedList()
    {
        head = null;
        tail = null;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    public object DeleteHead()
    {
        if (!IsEmpty())
        {
            ListNode<T> oldFirst = head;
            ListNode<T> next = head.Next;
            head = next;
            length--;
            return oldFirst.Value;
        }
        else
        {
            return null;
        }
    }

    public ListNode<T> First()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("List is empty.");
        }
        return head;
    }

    public ListNode<T> Last()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("List is empty.");
        }
        return tail;
    }

    public void AddFirst(T node)
    {
        ListNode<T> newNode = new ListNode<T>(node);

        if (IsEmpty())
        {
            head = newNode;
            tail = newNode;
            length++;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
            length++;
        }
    }

    public void InsertAfter(T node, T afterNode)
    {
        ListNode<T> newNode = new ListNode<T>(node);
        ListNode<T> afterListNode = FindItem(afterNode);

        if (afterListNode == null)
        {
            throw new ArgumentException("Previous node not found.");
        }

        ListNode<T> nextNode = afterListNode.Next;
        afterListNode.Next = newNode;
        newNode.Next = nextNode;

        if (nextNode == null)
        {
            tail = newNode;
            length++;
        }
    }

    public void AddLast(T node)
    {
        ListNode<T> newNode = new ListNode<T>(node);

        if (IsEmpty())
        {
            head = newNode;
            tail = newNode;
            length++;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            length++;
        }
    }

    public void RemoveFirst()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("List is empty.");
        }

        head = head.Next;

        if (head == null)
        {
            tail = null;
            length--;
        }
    }

    public void RemoveAfter(ListNode<T> prevNode)
    {
        if (prevNode == null)
        {
            throw new ArgumentException("Previous node cannot be null.");
        }

        ListNode<T> currentNode = prevNode.Next;

        if (currentNode == null)
        {
            throw new InvalidOperationException("No next node to remove.");
        }

        prevNode.Next = currentNode.Next;

        if (currentNode.Next == null)
        {
            tail = prevNode;
            length--;
        }
    }

    public ListNode<T> ElementAt(int index)
    {
        int currentIndex = 0;
        ListNode<T> current = head;

        while (current != null)
        {
            if (currentIndex == index)
            {
                return current;
            }

            current = current.Next;
            currentIndex++;
        }

        return null;
    }

    public int Count()
    {
        return length;
    }

    public ListNode<T> FindItem(T node)
    {
        ListNode<T> current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, node))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    public void PrintList()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
        }
        else
        {
            ListNode<T> current = head;

            Console.WriteLine("Items in the list are:");

            while (current != null)
            {
                Console.WriteLine(current.Value.ToString());
                current = current.Next;
            }
        }
    }

}

