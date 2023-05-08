using System;
namespace GraphVersionThree
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
            //string filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            //string filepathstations = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";
            string filepath = "/Users/Ifeoma1/Documents/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            string filepathstations = "/Users/Ifeoma1/Documents/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";

            //create network
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
    }
}

