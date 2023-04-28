using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class PriorityQueue
    {
        //priority queue is a type of linked list
        private LinkedList queue;

        public PriorityQueue()
        {
            queue = new LinkedList();
        }

        public void Enqueue(Station station, int distance)
        {
            PriorityQueueNode newNode = new PriorityQueueNode(station, distance);

            if (queue.isEmpty() || distance <= queue.getHead().getData().index)
            {
                queue.insertAtHead(newNode);
            }
            else
            {
                ListNode current = queue.getHead();

                while (current.getNext() != null && current.getNext().getData().index < distance)
                {
                    current = current.getNext();
                }

                PriorityQueueNode newCurrent = new PriorityQueueNode(current);

                queue.insertAfter(newNode, newCurrent);
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

        public bool IsEmpty()
        {
            return queue.isEmpty();
        }

        public void PrintQueue()
        {
            
            queue.printList();
        }
    }

}

