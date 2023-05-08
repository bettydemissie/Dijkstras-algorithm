﻿using System;
namespace GraphVersionTwo;

public class StationCreation
{
    public ZoneOneGraph graph = new ZoneOneGraph();
    public GraphController controller;
    public ReadExcel read;
    public ReadStationsandNetworks text;
    private Logger logger;

    public StationCreation()
    {
        logger = new Logger();
        ReadExcel read = new ReadExcel();
        ReadStationsandNetworks text = new ReadStationsandNetworks(read);
        //string filepath = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
        //string filepathstations = "/Users/bettydemissie/Desktop/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";
        string filepath = "/Users/Ifeoma1/Documents/FastestWalkingRouteWithDjikstraAssignment/Zone-1-walkingdistance.xlsx";
        string filepathstations = "/Users/Ifeoma1/Documents/FastestWalkingRouteWithDjikstraAssignment/StationsExcel.xlsx";

        var stations = text.GetTheStations(filepathstations);

        var networks = text.GetNetworks(filepath);
        logger.Log("\n");

        //create station network

        CreateStationNetwork(networks);
        logger.Log("\n");
        controller = new GraphController(graph);

    }

    public void CreateStationNetwork(LinkedList<Network> arrayNetwork)
    {
        var networkNode = arrayNetwork.First();
        while (networkNode != null)
        {
            var network = networkNode.Value;
            graph.AddNetworkToStationNetwork(network.getSourceStation(), network);
            networkNode = networkNode.Next;
        }
    }

}
