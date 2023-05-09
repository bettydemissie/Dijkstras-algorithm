﻿using System;
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
            //change the path below to where this coursework file is located on your device
            string filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
            string filepathstations = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";
          
            //create network
            var networks = text.GetNetworks(filepath);

            Console.WriteLine("\n");

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
    }
}

