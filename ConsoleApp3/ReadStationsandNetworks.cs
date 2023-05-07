using System;
using static System.Collections.Specialized.BitVector32;

namespace GraphVersionThree
{
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

            foreach (string[] stat in stringArray)
            {
                 IndexOneItem.AddLast(new Station(stat[0]));
            }
            return IndexOneItem;
        }

        public LinkedList<Network> GetNetworks(string filepath)
        {
            LinkedList<string[]> networkArray = read.Excel(filepath, 0);

            LinkedList<Network> arrayNetwork = new LinkedList<Network>();

            foreach (string[] network in networkArray)
            {
                if ((int.TryParse(network[3], out int stationDistance)))
                {
                    arrayNetwork.AddLast(new Network(new Station(network[0]), new Station(network[1]), network[2], stationDistance));
                }
            }
            return arrayNetwork;
        }
    }
}