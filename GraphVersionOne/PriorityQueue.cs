using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class PriorityQueue
    {
        //creates a new linked list instance for priority queue
        private LinkedList queue = new LinkedList();

        public void Enqueue(Station station, int distance)
        {
            PriorityQueueNode newNode = new PriorityQueueNode(station, distance);

            if (queue.IsEmpty() || distance <= queue.GetHead().Distance)
            {
                //cross check in LinkedList implementation that this method is present
                queue.InsertAtHead(newNode);
            }
            else
            {
                LinkedListNode current = queue.GetHead();

                //cross check in LinkedList implementation that this method is present
                while (current.Next != null && current.Next.Data.Distance < distance)
                {
                    current = current.Next;
                }

                //cross check in LinkedList implementation that this method is present
                current.InsertAfter(newNode);
            }
        }

        public Station Dequeue()
        {
            if (queue.IsEmpty())
            {
                throw new Exception("Priority queue is empty");
            }

            //cross check in LinkedList implementation that this method is present
            Station station = queue.GetHead().Data.Station;

            //cross check in LinkedList implementation that this method is present
            queue.DeleteHead();

            return station;
        }

        public bool IsEmpty()
        {
            return queue.IsEmpty();
        }

        public void PrintQueue()
        {
            //cross check in LinkedList implementation that this method is present
            queue.PrintList();
        }
    }

}

