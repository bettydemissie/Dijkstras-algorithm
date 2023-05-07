using System;

namespace GraphVersionOne;

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

