using System;
using System.Diagnostics;
using GraphVersionTwo;

namespace Testing
{
	public class BenchmarkingTestV2
	{
        public ZoneOneGraph graph = new ZoneOneGraph();
        public GraphController controller;
        public ReadExcel read;
        public ReadStationsandNetworks text;

        public BenchmarkingTestV2()
		{
            ReadExcel read = new ReadExcel();
            ReadStationsandNetworks text = new ReadStationsandNetworks(read);
            //string filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            //string filepathstations = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";
            string filepath = "/Users/Ifeoma1/Documents/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            string filepathstations = "/Users/Ifeoma1/Documents/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";

            var networks = text.GetNetworks(filepath);

            Console.WriteLine("\n");

            //create station network
            CreateStationNetwork(networks);

            controller = new GraphController(graph);
        }

        public void CreateStationNetwork(GraphVersionTwo.LinkedList<Network> arrayNetwork)
        {
            var networkNode = arrayNetwork.First();
            while (networkNode != null)
            {
                var network = networkNode.Value;
                graph.AddNetworkToStationNetwork(network.getSourceStation(), network);
                networkNode = networkNode.Next;
            }
        }

        public double RunTestForDijsktraVersion1_1stEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Baker Street", "Goodge Street");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion1_2ndEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Temple", "Lambeth North");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion1_3rdEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Green Park", "Liverpool Street");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion1_4thEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Marble Arch", "Cannon Street");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion1_5thEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("London Bridge", "Marylebone");

            // Stop timing
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion1_6thEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Paddington", "Tower Hill");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForGetTubeInformationVersion1()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.DisplayTubeInformation("Tower Hill");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForAddDelayNetworkVersion1()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.AddDelayToNetwork("Oxford Circus", "Bond Street", "Central", 10);

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForPrintAllClosedRoutesVersion1()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.PrintAllClosedRoutes();

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForCreatingAdacencyListVersion1()
        {
            ReadExcel read = new ReadExcel();
            this.text = new ReadStationsandNetworks(read);
            string filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            var networks = text.GetNetworks(filepath);

            // Start timing
            var stopwatch = Stopwatch.StartNew();

            CreateStationNetwork(networks);

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}