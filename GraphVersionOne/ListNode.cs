using System;
namespace ConsoleApp3
{
    //public class ListNode
    //{
    //    private Object item;
    //    private ListNode next;
    //    public Station station { get; set; }
    //    public int distance { get; set; }

    //    public ListNode()
    //    {
    //        next = null;
    //        this.station = station;
    //        this.distance = distance;
    //    }

    //    public ListNode(Station station, int distance)
    //    {

    //        this.next = null;
    //        this.station = station;
    //        this.distance = distance;
    //    }

    //    public ListNode(Station station, int distance, ListNode next)
    //    {
    //        this.next = next;
    //        this.station = station;
    //        this.distance = distance;
    //    }

    //    public void setStation(Station station)
    //    {
    //        this.station = station;
    //    }

    //    public void setDistance(int distance)
    //    {
    //        this.distance = distance;
    //    }

    //    public void setNext(ListNode next)
    //    {
    //        this.next = next;
    //    }

    //    public Station getStation()
    //    {
    //        return this.station;
    //    }

    //    public ListNode getNext()
    //    {
    //        return this.next;
    //    }

    //    public int getDistance()
    //    {
    //        return this.distance;
    //    }

    //    public void printNode()
    //    {
    //        // print "NULL" if a variable is "null"
    //        string stationValue = (station == null ? "NULL" : station.ToString());

    //        int distanceValue = (getDistance());

    //        string nextValue = (next == null ? "NULL" : next.getStation().ToString());

    //        Console.WriteLine("LLnode[ item = " + stationValue + ", \t" +
    //                           "next --> " + nextValue + " ]");
    //    }

    //}  // ListNode



    public class ListNode
    {
        public PriorityQueueNode data;
        public ListNode next;

        public ListNode(PriorityQueueNode data, ListNode next)
        {
            this.data = data;
            this.next = next;
        }

        public PriorityQueueNode getData()
        {
            return data;
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

