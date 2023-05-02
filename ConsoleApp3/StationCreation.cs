using System;
namespace ConsoleApp3
{
	public class StationCreation
	{
        public ZoneOneGraph graph = new ZoneOneGraph();
        public GraphController controller;
        public ReadExcel read;
        public ReadStationsandNetworks text;

        public StationCreation()
        {

            ReadExcel read = new ReadExcel();
            ReadStationsandNetworks text = new ReadStationsandNetworks(read);
            string filepath = "/Users/Ifeoma1/Downloads/Zone-1-walkingdistance.xlsx";
            string filepathstations = "/Users/Ifeoma1/Downloads/StationsExcel.xlsx";
            //string filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            //string filepathstations = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";

            var stations = text.GetTheStations(filepathstations);

            var networks = text.GetNetworks(filepath);

            //foreach (Network item in networks)
            //{
            //    Console.WriteLine(item);

            //}

            Console.WriteLine("\n");

            //create station network

            CreateStationNetwork(networks);
            Console.WriteLine("BREAK!!!!!!!!!");



            controller = new GraphController(graph);

        }

        public void CreateStationNetwork(LinkedList<Network> arrayNetwork)
        {

            foreach (Network network in arrayNetwork)
            {
                graph.AddNetworkToStationNetwork(network.getSourceStation(), network);
            }

            
        }
    }
}

