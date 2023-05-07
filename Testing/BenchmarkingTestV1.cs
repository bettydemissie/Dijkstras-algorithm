using System;
using System.Diagnostics;
using GraphVersionOne;

namespace Testing
{
	public class BenchmarkingTestV1
	{
        public ZoneOneGraph graph = new ZoneOneGraph();
        public GraphController controller;
        public ReadExcel read;
        public ReadStationsandNetworks text;

        public BenchmarkingTestV1()
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

        public double RunTestForDijsktraVersion1()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Baker Street", "Goodge Street");

            // Stop timing
            stopwatch.Stop();

            // Print the elapsed time
            //Console.WriteLine("Elapsed time for Dijsktra V1: " + stopwatch.Elapsed.TotalMilliseconds + " ms");//as third parameter in table
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForGetTubeInformationVersion1()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.DisplayTubeInformation("Tower Hill");

            // Stop timing
            stopwatch.Stop();

            // Print the elapsed time
            //Console.WriteLine("Elapsed time for Getting Tube Information V1: " + stopwatch.Elapsed.TotalMilliseconds + " ms");//as third parameter in table
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForAddDelayNetworkVersion1()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.AddDelayToNetwork("Oxford Circus", "Bond Street", "Central", 10);

            // Stop timing
            stopwatch.Stop();

            // Print the elapsed time
            //Console.WriteLine("Elapsed time for Add Delay To Network V1: " + stopwatch.Elapsed.TotalMilliseconds + " ms");//as third parameter in table
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForPrintAllClosedRoutesVersion1()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.PrintAllClosedRoutes();

            // Stop timing
            stopwatch.Stop();

            // Print the elapsed time
            //Console.WriteLine("Elapsed time for Closed Routes V1: " + stopwatch.Elapsed.TotalMilliseconds + " ms");//as third parameter in table

            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}