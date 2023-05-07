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

        public ConsistencyTestV3()
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

        public void CreateStationNetwork(LinkedList<Network> arrayNetwork)
        {

            foreach (Network network in arrayNetwork)
            {
                graph.AddNetworkToStationNetwork(network.getSourceStation(), network);
            }

        }

        public void RunTestForDijsktraVersion3()
        {
            // Code for consistency goes here
            controller.FindFastestWalkingRoutes("Baker Street", "Goodge Street");
        }

        public void RunTestForGetTubeInformationVersion3()
        {
            controller.DisplayTubeInformation("Tower Hill");
        }

        public void RunTestForPrintAllDelayedRoutesVersion3()
        {
            controller.PrintAllDelayedRoutes();
        }

        public void RunTestForPrintAllClosedRoutesVersion3()
        {
            controller.PrintAllClosedRoutes();
        }
    }
}

