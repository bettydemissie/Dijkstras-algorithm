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
            string filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            string filepathstations = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";

            var networks = text.GetNetworks(filepath);

            Console.WriteLine("\n");

            //create station network
            CreateStationNetwork(networks);

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

        public void RunTest1ForDijsktraVersion1()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Baker Street", "Goodge Street");
        }
        //far
        public void RunTest2ForDijsktraVersion1()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Knightsbridge", "Liverpool Street");
        }
        //medium
        public void RunTest3ForDijsktraVersion1()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Bond Street", "Blackfriars");
        }
        //close
        public void RunTest4ForDijsktraVersion1()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Green Park", "Goodge Street");
        }
        public void RunTestForGetTubeInformationVersion1()
        {
            controller.DisplayTubeInformation("Tower Hill");
        }
    }
}

