using System;
using System.Xml.Linq;

namespace GraphVersionOne;

public class LinkedList<T>
{
    public ListNode<T> head;
    public int length = 0;
    public ListNode<T> tail;
    private Logger logger;

    public LinkedList()
    {
        head = null;
        tail = null;
        logger = new Logger();
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

    public ListNode<T> Find(Func<T, bool> predicate)
    {
        ListNode<T> current = head;
        while (current != null)
        {
            if (predicate(current.Value))
            {
                return current;
            }
            current = current.Next;
        }
        return null;
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
            logger.Log("List is empty");
        }
        else
        {
            ListNode<T> current = head;

            Console.WriteLine("Items in the list are:");

            while (current != null)
            {
                logger.Log(current.Value.ToString());
                current = current.Next;
            }
        }
    }
}

