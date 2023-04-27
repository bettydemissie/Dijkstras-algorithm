using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp3
{
    //public class PriorityQueue
    //{
    //    //creates a new linked list instance for priority queue
    //    private LinkedList queue = new LinkedList();


    //    public void Enqueue(Station station, int distance)
    //    {
    //        ListNode newNode = new ListNode(station, distance);

    //        //turn head of the queue into a PQNode
    //        //compare the listnode at the head of queue's node distance to current distance of


    //        if (queue.isEmpty() || distance <= queue.getHead().distance)
    //        {
    //            //cross check in LinkedList implementation that this method is present
    //            queue.insertAtHead(newNode);
    //        }
    //        else
    //        {
    //            ListNode current = queue.getHead();

    //            //cross check in LinkedList implementation that this method is present
    //            while (current.getNext() != null && current.getNext().distance < distance)
    //            {
    //                current = current.getNext();
    //            }

    //            //cross check in LinkedList implementation that this method is present
    //            //current.insertAfter(newNode, current);
    //            queue.insertAfter(newNode, current);

    //        }
    //    }

    //    public Station Dequeue()
    //    {
    //        if (queue.isEmpty())
    //        {
    //            throw new Exception("Priority queue is empty");
    //        }
    //        else
    //        {
    //            //cross check in LinkedList implementation that this method is present
    //            Station station = queue.getHead().station;

    //            //cross check in LinkedList implementation that this method is present
    //            queue.deleteHead();

    //            return station;
    //        }

    //    }

    //    public bool IsEmpty()
    //    {
    //        return queue.isEmpty();
    //    }

    //    public void PrintQueue()
    //    {
    //        //cross check in LinkedList implementation that this method is present
    //        queue.printList();
    //    }
    //}


    public class PriorityQueue
    {
        private LinkedList queue;

        public PriorityQueue()
        {
            queue = new LinkedList();
        }

        public void Enqueue(Station station, int distance)
        {
            PriorityQueueNode newNode = new PriorityQueueNode(station, distance);

            if (queue.isEmpty() || distance <= queue.getHead().getData().distance)
            {
                queue.insertAtHead(newNode);
            }
            else
            {
                ListNode current = queue.getHead();

                while (current.getNext() != null && current.getNext().getData().distance < distance)
                {
                    current = current.getNext();
                }

                queue.insertAfter(newNode, current);
            }
        }

        public PriorityQueueNode Dequeue()
        {
            if (queue.isEmpty())
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            PriorityQueueNode result = queue.getHead().getData();
            queue.removeAtHead();
            return result;
        }
    }

}

