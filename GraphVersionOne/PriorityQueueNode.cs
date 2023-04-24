using System;
namespace ConsoleApp3
{
    public class PriorityQueueNode
    {
        public Station station { get; set; }
        public int distance { get; set; }

        public PriorityQueueNode(Station station, int distance)
        {
            this.station = station;
            this.distance = distance;
        }
    }
}

