using System;
namespace GraphVersionOne;

public class PriorityQueueNode
{
    public Object node { get; set; }
    public int index { get; set; }

    public PriorityQueueNode(Object node, int index)
    {
        this.node = node;
        this.index = index;
    }

    public PriorityQueueNode(Object node)
    {
        this.node = node;
        this.index = index;
    }
}

