
using System;
using static System.Collections.Specialized.BitVector32;

namespace ConsoleApp3
{
    public class ReadStationsandNetworks
    {
        ReadExcel read;

        public ReadStationsandNetworks(ReadExcel read)
        {
            this.read = read;
        }


            //public List<Station> GetStationsFromWorkbookTwo()
            //{
            //    foreach()
            //    {

            //    }

            //} 

            //public Station CreateStationsFromExcel()
            //{
            //          CheckIfStationExist(string station)

            //          filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            //	read.Excel(filepath);
            //	read.Get2DList();



            //}

        
        public LinkedList<Station> GetTheStations(string filepath)
        {
            LinkedList<string[]> stringArray = read.Excel(filepath, 0);

            LinkedList<Station> IndexOneItem = new LinkedList<Station>();

            foreach (string[] stat in stringArray)
            {
                //if (stringArray.Count > 1)
                //{
                    IndexOneItem.AddLast(new Station(stat[0]));
                //}

            }
            return IndexOneItem;
        }

        public LinkedList<Network> GetNetworks(string filepath)
        {
            LinkedList<string[]> networkArray = read.Excel(filepath, 0);

            LinkedList<Network> arrayNetwork = new LinkedList<Network>();

            var index = 0;
            foreach (string[] network in networkArray)
            {
                Console.WriteLine(index++ + (network[3]));
                arrayNetwork.AddLast(new Network(new Station(network[0]), new Station(network[1]), network[2], int.Parse(network[3])));
            }
            return arrayNetwork;

        }
    }
}

