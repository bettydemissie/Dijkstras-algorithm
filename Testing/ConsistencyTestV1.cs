using System;
using GraphVersionOne;
using System.Diagnostics;

namespace Testing
{
	public class ConsistencyTestV1
	{
        public ZoneOneGraph graph = new ZoneOneGraph();
        public GraphController controller;
        public ReadExcel read;
        public ReadStationsandNetworks text;

        public ConsistencyTestV1()
		{
            ReadExcel read = new ReadExcel();
            ReadStationsandNetworks text = new ReadStationsandNetworks(read);
            string filepath = "/Users/Ifeoma1/Downloads/Zone-1-walkingdistance.xlsx";
            string filepathstations = "/Users/Ifeoma1/Downloads/StationsExcel.xlsx";

            var networks = text.GetNetworks(filepath);

            Console.WriteLine("\n");

            //create station network
            CreateStationNetwork(networks);
            Console.WriteLine("BREAK!!!!!!!!!");

            controller = new GraphController(graph);
        }

        public void CreateStationNetwork(GraphVersionOne.LinkedList<Network> arrayNetwork)
        {
            var networkNode = arrayNetwork.First();
            while (networkNode != null)
            {
                var network = networkNode.Value;
                graph.AddNetworkToStationNetwork(network.getSourceStation(), network);
                networkNode = networkNode.Next;
            }
        }

        public void RunTestForDijsktraVersion1()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Baker Street", "Goodge Street");
        }

        public void RunTestForGetTubeInformationVersion1()
        {
            controller.DisplayTubeInformation("Tower Hill");
        }

        public void RunTestForPrintAllDelayedRoutesVersion1()
        {
            controller.PrintAllDelayedRoutes();
        }

        public void RunTestForPrintAllClosedRoutesVersion1()
        {
            controller.PrintAllClosedRoutes();
        }
    }
}

