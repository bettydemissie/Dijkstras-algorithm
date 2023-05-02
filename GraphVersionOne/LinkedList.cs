using System;
using System.Xml.Linq;

namespace ConsoleApp3
{
    public class LinkedList
    {
        public ListNode head;
        public int length = 0;
        public ListNode tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public Object deleteHead()
        {
            //if list is not empty
            if (!isEmpty())
            {
                //delete head by setting head to the current position
                //so it can be rewritten

                //create variable to store old head in order to return it
                ListNode oldFirst = new ListNode();
                oldFirst = head;

                //set a getter for the next node
                ListNode next = head.getNext();

                //assign the first to the next
                head = next;

                length--;

                //return old head
                return oldFirst.getData();

            }
            else
                return null;
        }

        public ListNode getHead()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("List is empty.");
            }
            return head;
        }

        public ListNode getTail()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("List is empty.");
            }
            return tail;
        }

        public void AddFirst(PriorityQueueNode node)
        {
            ListNode newNode = new ListNode(node);

            if (isEmpty())
            {
                head = newNode;
                tail = newNode;
                length++;
            }
            else
            {
                newNode.next = head;
                head = newNode;
                length++;
            }
        }


        public void insertAfter(PriorityQueueNode node, PriorityQueueNode afterNode)
        {
            ListNode newNode = new ListNode(node);
            ListNode afterListNode = findItem(afterNode);

            if (afterListNode == null)
            {
                throw new ArgumentException("Previous node not found.");
            }

            ListNode nextNode = afterListNode.next;
            afterListNode.next = newNode;
            newNode.next = nextNode;

            if (nextNode == null)
            {
                tail = newNode;
                length++;
            }
        }

        public void AddLast(PriorityQueueNode node)
        {
            ListNode newNode = new ListNode(node);

            if (isEmpty())
            {
                head = newNode;
                tail = newNode;
                length++;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
                length++;
            }
        }

        public void removeAtHead()
        {
            if (isEmpty())
            {
                throw new InvalidOperationException("List is empty.");
            }

            head = head.next;

            if (head == null)
            {
                tail = null;
                length--;
            }
        }

        public void removeAfter(ListNode prevNode)
        {
            if (prevNode == null)
            {
                throw new ArgumentException("Previous node cannot be null.");
            }

            ListNode currentNode = prevNode.next;

            if (currentNode == null)
            {
                throw new InvalidOperationException("No next node to remove.");
            }

            prevNode.next = currentNode.next;

            if (currentNode.next == null)
            {
                tail = prevNode;
                length--;
            }
        }

        public ListNode ElementAt(int index)
        {
            int currentIndex = 0;
            ListNode current = head;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current;
                }

                current = current.getNext();
                currentIndex++;
            }

            return null; // Return null if the index is out of range
        }

        public int Count()
        {
            return length;
        }

        public ListNode findItem(PriorityQueueNode node)
        {
            ListNode current = head;

            while (current != null)
            {
                if (current.data == node)
                {
                    return current;
                }

                current = current.next;
            }

            return null;
        }


        public void printList()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                ListNode current = new ListNode();

                current = head;

                Console.WriteLine("Items in the list are:");

                while (current != null)   // not at end of the list
                {
                    Console.WriteLine(current.getData().ToString());
                    current = current.getNext();
                }
            }
        }
    }
}
