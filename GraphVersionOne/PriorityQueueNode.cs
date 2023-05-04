using System;
namespace GraphVersionOne;

public class PriorityQueueNode<TElement, TPriority>
{
    public TElement Element { get; set; }
    public TPriority Priority { get; set; }

    public PriorityQueueNode(TElement Element, TPriority Priority)
    {
        this.Element = Element;
        this.Priority = Priority;
    }
}
