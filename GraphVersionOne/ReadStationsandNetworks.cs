using System;
//using static System.Collections.Specialized.BitVector32;

namespace GraphVersionOne;

public class ReadStationsandNetworks
{
    ReadExcel read;

    public ReadStationsandNetworks(ReadExcel read)
    {
        this.read = read;
    }

    public LinkedList<Station> GetTheStations(string filepath)
    {
        LinkedList<string[]> stringArray = read.Excel(filepath, 0);

        LinkedList<Station> IndexOneItem = new LinkedList<Station>();

        ListNode<string[]> node = stringArray.First();
        while (node != null)
        {
            string[] stat = node.Value;
            IndexOneItem.AddLast(new Station(stat[0]));

            node = node.Next;
        }

        return IndexOneItem;
    }




    //public LinkedList<Network> GetNetworks(string filepath)
    //{
    //    LinkedList<string[]> networkArray = read.Excel(filepath, 0);

    //    LinkedList<Network> arrayNetwork = new LinkedList<Network>();

    //    foreach (string[] network in networkArray)
    //    {
    //        if ((int.TryParse(network[3], out int stationDistance)))
    //        {
    //            arrayNetwork.AddLast(new Network(new Station(network[0]), new Station(network[1]), network[2], stationDistance));
    //        }

    //    }
    //    return arrayNetwork;

    //}

    public LinkedList<Network> GetNetworks(string filepath)
    {
        LinkedList<string[]> networkArray = read.Excel(filepath, 0);
        LinkedList<Station> stationList = new LinkedList<Station>(); // Create an empty station list

        LinkedList<Network> arrayNetwork = new LinkedList<Network>();

        ListNode<string[]> node = networkArray.First();
        while (node != null)
        {
            string[] network = node.Value;
            if (int.TryParse(network[3], out int stationDistance))
            {
                // Check if the source station already exists in the station list
                ListNode<Station> sourceStationNode = stationList.Find(x => x.getName() == network[0]);

                Station sourceStation = null;

                if (sourceStationNode != null)
                {
                    sourceStation = sourceStationNode.Value;
                }

                if (sourceStation == null)
                {
                    // If the source station does not exist, create a new Station object and add it to the station list
                    sourceStation = new Station(network[0]);
                    stationList.AddLast(sourceStation);
                }

                // Check if the destination station already exists in the station list
                ListNode<Station> destinationStationNode = stationList.Find(x => x.getName() == network[1]);

                Station destinationStation = null;

                if (destinationStationNode != null)
                {
                    destinationStation = destinationStationNode.Value;
                }

                if (destinationStation == null)
                {
                    // If the destination station does not exist, create a new Station object and add it to the station list
                    destinationStation = new Station(network[1]);
                    stationList.AddLast(destinationStation);
                }

                // Create the Network object using the source and destination Station objects
                arrayNetwork.AddLast(new Network(sourceStation, destinationStation, network[2], stationDistance));
            }

            node = node.Next;
        }

        return arrayNetwork;
    }

}

