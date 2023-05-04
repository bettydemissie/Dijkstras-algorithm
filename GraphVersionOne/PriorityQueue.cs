﻿using System;

namespace GraphVersionOne;

//public class PriorityQueue
//{
//    //priority queue is a type of linked list
//    private LinkedList<T> queue;

//    public PriorityQueue()
//    {
//        queue = new LinkedList<T>();
//    }

//    public void Enqueue(Station station, int distance)
//    {
//        PriorityQueueNode newNode = new PriorityQueueNode(station, distance);

//        if (queue.isEmpty() || distance <= queue.getHead().getData().index)
//        {
//            queue.AddFirst(newNode);
//        }
//        else
//        {
//            ListNode<T> current = queue.getHead();

//            while (current.getNext() != null && current.getNext().getData().index < distance)
//            {
//                current = current.getNext();
//            }

//            PriorityQueueNode newCurrent = new PriorityQueueNode(current);

//            queue.insertAfter(newNode, newCurrent);
//        }
//    }

//    public PriorityQueueNode Dequeue()
//    {
//        if (queue.isEmpty())
//        {
//            throw new InvalidOperationException("Queue is empty.");
//        }

//        PriorityQueueNode result = queue.getHead().getData();
//        queue.removeAtHead();
//        return result;
//    }

//    public bool IsEmpty()
//    {
//        return queue.isEmpty();
//    }

//    public void PrintQueue()
//    {

//        queue.printList();
//    }
//}

public class PriorityQueue<TElement, TPriority>
{
    private LinkedList<PriorityQueueNode<TElement, TPriority>> queue;
    private Comparison<TPriority> comparison;

    public PriorityQueue(Comparison<TPriority> comparison = null)
    {
        queue = new LinkedList<PriorityQueueNode<TElement, TPriority>>();
        this.comparison = comparison ?? DefaultComparison;
    }

    public void Enqueue(TElement element, TPriority priority)
    {
        PriorityQueueNode<TElement, TPriority> newNode = new PriorityQueueNode<TElement, TPriority>(element, priority);

        if (queue.IsEmpty() || comparison(priority, queue.First().Value.Priority) <= 0)
        {
            queue.AddFirst(newNode);
        }
        else
        {
            ListNode<PriorityQueueNode<TElement, TPriority>> current = queue.First();

            while (current.Next != null && comparison(current.Next.Value.Priority, priority) < 0)
            {
                current = current.Next;
            }

            queue.InsertAfter(newNode, current.Value);
        }
    }

    public PriorityQueueNode<TElement, TPriority> Dequeue()
    {
        if (queue.IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        PriorityQueueNode<TElement, TPriority> result = queue.First().Value;
        queue.RemoveFirst();
        return result;
    }

    public int Count()
    {
        return queue.length;
    }

    public bool IsEmpty()
    {
        return queue.IsEmpty();
    }

    public void PrintQueue()
    {
        queue.PrintList();
    }

    private static int DefaultComparison(TPriority x, TPriority y)
    {
        if (x is IComparable<TPriority> comparable)
        {
            return comparable.CompareTo(y);
        }

        throw new InvalidOperationException("No valid comparer found for type TPriority.");
    }
}

