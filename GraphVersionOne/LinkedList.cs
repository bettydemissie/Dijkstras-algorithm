using System;
namespace ConsoleApp3
{
    //public class LinkedList
    //{
    //    protected ListNode head = null;   // points to the head of the list
    //    protected int length = 0;      // number of nodes in the list
    //    protected ListNode tail = null; // points to the tail of the list

    //    public LinkedList()
    //    {
    //        head = null;   // empty list
    //        length = 0;      // no nodes in the list
    //    }

    //    public bool isEmpty()
    //    {
    //        return (length == 0);       // or ( head == null )
    //    }

    //    public void insertAtHead(Object item)
    //    {
    //        ListNode newItem = new ListNode(item, head);  // .next ) ;

    //        head = newItem;

    //        length++;
    //    }

    //    public ListNode getHead()
    //    {
    //        //if (isEmpty())
    //        //{
    //        //    Console.WriteLine("No head");
    //        //}
    //        return head;
    //    }

    //    public Object deleteHead()
    //    {
    //        //if list is not empty
    //        if (!isEmpty())
    //        {
    //            //delete head by setting head to the current position
    //            //so it can be rewritten

    //            //create variable to store old head in order to return it
    //            ListNode oldFirst = new ListNode();
    //            oldFirst = head;

    //            //set a getter for the next node
    //            ListNode next = head.getNext();

    //            //assign the first to the next
    //            head = next;

    //            length--;

    //            //return old head
    //            return oldFirst.getItem();

    //        }
    //        else
    //            return null;
    //    }

    //    //implement
    //    //public void deleteItem (Object item)

    //    public void insertAtTail(Object item)
    //    {
    //        ListNode newList = new ListNode(item, tail);

    //        tail = newList;

    //        length++;
    //    }

    //    // *** HAS A BUG? - so use Equals not != in while ***
    //    private ListNode findItem(Object item)
    //    {
    //        if (!isEmpty())
    //        {
    //            ListNode current = new ListNode();

    //            current = head;

    //            while ((!(current.Equals(null))) && (!(item.Equals(current.getItem()))))
    //            {
    //                Console.WriteLine();
    //                Console.WriteLine("findItem: current.item = " + current.getItem().ToString());
    //                Console.WriteLine();

    //                current = current.getNext();
    //            }

    //            Console.WriteLine();
    //            Console.WriteLine("findItem: current.item = " + current.getItem().ToString());
    //            Console.WriteLine();

    //            return current;
    //        }
    //        else
    //        {
    //            Console.WriteLine();
    //            Console.WriteLine("findItem: afterNode = null");
    //            Console.WriteLine();

    //            return null;
    //        }
    //    }

    //    public bool insertAfter(Object newItem, Object afterItem)
    //    {
    //        ListNode afterNode = findItem(afterItem);  // find the afterItem's node

    //        if (afterNode != null)    // afterItem in list
    //        {

    //            // create newItem's node & set its next to afterItem's next
    //            ListNode newItemNode = new ListNode(newItem, afterNode.getNext());

    //            afterNode.setNext(newItemNode);

    //            length++;

    //            return true;
    //        }
    //        else
    //        {    // afterItem not in list
    //            return false;
    //        }
    //    }


    //    public void printList()
    //    {
    //        if (head == null)
    //        {
    //            Console.WriteLine("List is empty");
    //        }
    //        else
    //        {
    //            ListNode current = new ListNode();

    //            current = head;

    //            Console.WriteLine("Items in the list are:");

    //            while (current != null)   // not at end of the list
    //            {
    //                Console.WriteLine(current.getItem().ToString());
    //                current = current.getNext();
    //            }
    //        }
    //    }

    //}


    //public class LinkedList
    //{
    //    public ListNode head;

    //    public LinkedList()
    //    {
    //        head = null;
    //    }

    //    public bool isEmpty()
    //    {
    //        return head == null;
    //    }

    //    public void insertAtHead(PriorityQueueNode node)
    //    {
    //        head = new ListNode(node, head);
    //    }

    //    public void insertAfter(PriorityQueueNode node, ListNode prevNode)
    //    {
    //        if (prevNode == null)
    //        {
    //            throw new ArgumentException("Previous node cannot be null.");
    //        }

    //        ListNode newNode = new ListNode(node, prevNode.next);
    //        prevNode.next = newNode;
    //    }

    //    public void removeAtHead()
    //    {
    //        if (head == null)
    //        {
    //            throw new InvalidOperationException("List is empty.");
    //        }

    //        head = head.next;
    //    }

    //    public void removeAfter(ListNode prevNode)
    //    {
    //        if (prevNode == null)
    //        {
    //            throw new ArgumentException("Previous node cannot be null.");
    //        }

    //        if (prevNode.next == null)
    //        {
    //            throw new InvalidOperationException("No next node to remove.");
    //        }

    //        prevNode.next = prevNode.next.next;
    //    }

    //    public ListNode getHead()
    //    {
    //        return head;
    //    }
    //}


    public class LinkedList
    {
        public ListNode head;
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

        public void insertAtHead(PriorityQueueNode node)
        {
            ListNode newNode = new ListNode(node);

            if (isEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }

        public void insertAfter(PriorityQueueNode node, PriorityQueueNode prevNode)
        {
            ListNode newNode = new ListNode(node);
            ListNode prevListNode = findItem(prevNode);

            if (prevListNode == null)
            {
                throw new ArgumentException("Previous node not found.");
            }

            ListNode nextNode = prevListNode.next;
            prevListNode.next = newNode;
            newNode.next = nextNode;

            if (nextNode == null)
            {
                tail = newNode;
            }
        }

        public void insertAtTail(PriorityQueueNode node)
        {
            ListNode newNode = new ListNode(node);

            if (isEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
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
            }
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

        public ListNode getHead()
        {
            return head;
        }

        public ListNode getTail()
        {
            return tail;
        }

        
    }

}
