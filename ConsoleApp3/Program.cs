// See https://aka.ms/new-console-template for more information

using System.Security;
using ConsoleApp3;

Console.WriteLine("Hello, World!");

var graph = new ZoneOneGraph();
Station Baker = graph.CreateStation("Baker");
Station GreatPortland = graph.CreateStation("GreatPortland");
Station CharingCross = graph.CreateStation("Charing Cross");
Station PiccadillyCircus = graph.CreateStation("Piccadilly Circus");
Station OxfordCircus = graph.CreateStation("Oxford Circus");
Station Marylebone = graph.CreateStation("MaryleBone");
Station Holborn = graph.CreateStation("Holborn");
Station WaterlooStation = graph.CreateStation("Waterloo");
Station RegentPark = graph.CreateStation("Regents Park");
Station MarbleArch = graph.CreateStation("Marble Arch");
Station BondStreet = graph.CreateStation("Bond Street");


Network BakerlooNetworkOne = graph.CreateNetwork(Baker, Marylebone, "Bakerloo", 6);
Network BakerlooNetworkTwo = graph.CreateNetwork(CharingCross, PiccadillyCircus, "Bakerloo", 11);
Network BakerlooNetworkThree = graph.CreateNetwork(RegentPark, Baker, "Bakerloo", 10);
Network BakerlooNetworkFour = graph.CreateNetwork(RegentPark, OxfordCircus, "City", 12);
Network MetropolitanNetworkOne = graph.CreateNetwork(Baker, GreatPortland, "Metropolitan", 15);
Network DistrictLineOne = graph.CreateNetwork(Baker, OxfordCircus, "District", 5);
Network CentralLineOne = graph.CreateNetwork(MarbleArch, BondStreet, "Central", 7);
Network JubileeLineOne = graph.CreateNetwork(BondStreet, Baker, "Jubilee", 16);
Network CircleLineOne = graph.CreateNetwork(Baker, GreatPortland, "Circle", 13);

graph.CreateStationNetwork(Baker);
graph.CreateStationNetwork(CharingCross);
graph.CreateStationNetwork(OxfordCircus);

graph.AddNetworkToStationNetwork(Baker, BakerlooNetworkOne);
graph.AddNetworkToStationNetwork(CharingCross, BakerlooNetworkTwo);
graph.AddNetworkToStationNetwork(RegentPark, BakerlooNetworkThree);
graph.AddNetworkToStationNetwork(RegentPark, BakerlooNetworkFour);
graph.AddNetworkToStationNetwork(Baker, MetropolitanNetworkOne);
graph.AddNetworkToStationNetwork(Baker, DistrictLineOne);
graph.AddNetworkToStationNetwork(MarbleArch, CentralLineOne);
graph.AddNetworkToStationNetwork(BondStreet, JubileeLineOne);
graph.AddNetworkToStationNetwork(Baker, CircleLineOne);


var controller = new GraphController(graph);
//graph.ConnectedNetworksToAStation(Baker);
//graph.GetAllPathFrom(MarbleArch, GreatPortland);

//controller.AddDelayToNetwork("Baker", "GreatPortland", "Circle",10);
//controller.OpenOrCloseStationsNetwork("Baker", "GreatPortland", "Circle", "Bridge Closed",true);
controller.FindFastestWalkingRoutes("Marble Arch", "GreatPortland");
//controller.PrintAllDelayedRoutes();
//controller.PrintAllClosedRoutes();


//var network = graph.GetNetworkInAStationNetwork(GreatPortland, Baker, "Circle");

