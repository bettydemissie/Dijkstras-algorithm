using System;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using GraphVersionThree;

namespace Testing
{
	public class BenchmarkingTestV3
	{
        public ZoneOneGraph graph = new ZoneOneGraph();
        public GraphController controller;
        public ReadExcel read;
        public ReadStationsandNetworks text;
        public Logger logger;

        public BenchmarkingTestV3()
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

        public double RunTestForDijsktraVersion3_1stEnquiry()
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

        public double RunTestForDijsktraVersion3_2ndEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Temple", "Lambeth North");

            // Stop timing
            stopwatch.Stop();

            // Print the elapsed time
            //Console.WriteLine("Elapsed time for Dijsktra V1: " + stopwatch.Elapsed.TotalMilliseconds + " ms");//as third parameter in table
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion3_3rdEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Green Park", "Liverpool Street");

            // Stop timing
            stopwatch.Stop();

            // Print the elapsed time
            //Console.WriteLine("Elapsed time for Dijsktra V1: " + stopwatch.Elapsed.TotalMilliseconds + " ms");//as third parameter in table
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion3_4thEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Marble Arch", "Cannon Street");

            // Stop timing
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion3_5thEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("London Bridge", "Marylebone");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForDijsktraVersion3_6thEnquiry()
        {
            var stopwatch = Stopwatch.StartNew();

            // Code to benchmark goes here
            controller.FindFastestWalkingRoutes("Paddington", "Tower Hill");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForGetTubeInformationVersion3()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.DisplayTubeInformation("Tower Hill");

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForAddDelayNetworkVersion3()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.AddDelayToNetwork("Oxford Circus", "Bond Street", "Central", 10);

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForPrintAllClosedRoutesVersion3()
        {
            var stopwatch = Stopwatch.StartNew();

            controller.PrintAllClosedRoutes();

            // Stop timing
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }

        public double RunTestForCreatingAdacencyListVersion3()
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