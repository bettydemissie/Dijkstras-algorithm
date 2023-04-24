using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp3
{
	public class PriorityQueue<T, U>
	{

        private LinkedList<KeyValuePair<T, U>> queue = new LinkedList<KeyValuePair<T, U>>();

  //      public PriorityQueue(Station firstStation, Station lastStation, int weight)
		//{
		//	this.firstStation = firstStation;
  //          this.lastStation = lastStation;
		//	this.weight = weight;
		//}

        //min heap representation of queue
        public void Enqueue(T item, U priority)
        {
            queue.AddLast(new KeyValuePair<T, U>(item, priority));
            queue = new LinkedList<KeyValuePair<T, U>>(queue.OrderBy(x => x.Value));
        }

        public T Dequeue()
        {
            //check if queue is empty
            //shift first element in queue to the next item ie +1
            if (queue.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T item = queue.First.Value.Key;
            queue.RemoveFirst();
            return item;
        }

        public bool isEmpty()
        {
            return (lengthOfQueue == 0);
        }
    }
}

