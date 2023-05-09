using System;
using GraphVersionThree;

namespace Testing
{
	public class ConsistencyTestV3
	{
        public ZoneOneGraph graph = new ZoneOneGraph();
        public GraphController controller;
        public ReadExcel read;
        public ReadStationsandNetworks text;
        public Logger logger;

        public ConsistencyTestV3()
		{
            ReadExcel read = new ReadExcel();
            ReadStationsandNetworks text = new ReadStationsandNetworks(read);
            logger = new Logger();
            string filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            string filepathstations = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";

            var networks = text.GetNetworks(filepath);

            logger.Log("\n");

            //create station network
            CreateStationNetwork(networks);

            controller = new GraphController(graph);
        }

        public void CreateStationNetwork(LinkedList<Network> arrayNetwork)
        {

            foreach (Network network in arrayNetwork)
            {
                graph.AddNetworkToStationNetwork(network.getSourceStation(), network);
            }

        }

        public void RunTest1ForDijsktraVersion3()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Baker Street", "Goodge Street");
        }

        //long distance between stations
        public void RunTest2ForDijsktraVersion3()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Knightsbridge", "Liverpool Street");
        }

        //medium distance between stations
        public void RunTest3ForDijsktraVersion3()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Bond Street", "Blackfriars");
        }

        //close distance between stations
        public void RunTest4ForDijsktraVersion3()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Green Park", "Goodge Street");
        }

        public void RunTestForGetTubeInformationVersion3()
        {
            controller.DisplayTubeInformation("Tower Hill");
        }
    }
}

