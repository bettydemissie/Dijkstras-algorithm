using System;
namespace ConsoleApp3
{
    public class ListNode
    {
        public PriorityQueueNode data;
        public ListNode next;

        public ListNode(PriorityQueueNode data, ListNode next)
        {
            this.data = data;
            this.next = next;
        }

        public ListNode(PriorityQueueNode data)
        {
            this.data = data;
            next = null;
        }

        public ListNode()
        {
            data = null;
            next = null;
        }

        public PriorityQueueNode getData()
        {
            return data;
        }

        public void setData(PriorityQueueNode data)
        {
            this.data = data;
        }

        public ListNode getNext()
        {
            return next;
        }

        public void setNext(ListNode next)
        {
            this.next = next;
        }
    }
}

