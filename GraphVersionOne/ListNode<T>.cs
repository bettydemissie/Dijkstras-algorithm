using System;
using static OfficeOpenXml.ExcelErrorValue;

namespace GraphVersionOne;

//public class ListNode<T>
//{
//    public T value { get; set; }
//    public PriorityQueueNode data;
//    public ListNode<T> next;

//    public ListNode(T value, PriorityQueueNode data, ListNode<T> next)
//    {
//        this.value = value;
//        this.data = data;
//        this.next = next;
//    }

//    public ListNode(PriorityQueueNode data)
//    {
//        this.value = value;
//        this.data = data;
//        next = null;
//    }

//    public ListNode(T value)
//    {
//        this.value = value;
//        this.next = null;
//    }

//    public ListNode()
//    {
//        this.value = value;
//        data = null;
//        next = null;
//    }

//    public PriorityQueueNode getData()
//    {
//        return data;
//    }

//    public void setData(PriorityQueueNode data)
//    {
//        this.data = data;
//    }

//    public ListNode<T> getNext()
//    {
//        return next;
//    }

//    public void setNext(ListNode<T> next)
//    {
//        this.next = next;
//    }
//}

public class ListNode<T>
{
    public T Value { get; set; }
    public ListNode<T> Next { get; set; }

    public ListNode(T value, ListNode<T> next)
    {
        Value = value;
        Next = next;
    }

    public ListNode(T value)
    {
        Value = value;
        Next = null;
    }
}

