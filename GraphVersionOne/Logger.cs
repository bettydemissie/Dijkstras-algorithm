namespace GraphVersionOne;

public class Logger
{

    public void LogAllNetworks(LinkedList<Network> networks)
    {
        var node = networks.First();
        while (node != null)
        {
            var network = node.Value;
            Console.WriteLine(network);

            node = node.Next;
        }
    }

    public void LogStation(Station station)
    { 
        Console.WriteLine(station);
        
    }

    public void LogAllStationNetworks(LinkedList<StationNetwork> stationNetworks)
    {
        var node = stationNetworks.First();
        while (node != null)
        {
            var stationNetwork = node.Value;
            Console.WriteLine($"__________Beginning of {stationNetwork.getStation().getName()} Station Network____");
            Console.WriteLine(stationNetwork.getStation());
            LogAllNetworks(stationNetwork.getNetworks());
            Console.WriteLine($"__________End of {stationNetwork.getStation().getName()} Station Network____");
            Console.WriteLine("");

            node = node.Next;
        }
    }

    public void LogAllNetworkPaths(LinkedList<LinkedList<Network>> networksLists)
    {
        Console.WriteLine("_________RESULT________");
        var number = 0;
        var networksNode = networksLists.First();
        while (networksNode != null)
        {
            var networks = networksNode.Value;
            var path = "";
            number++;
            path += $" {number}. ";
            Network previousNetwork = null;
            Network lastNetwork = networks.Last().Value;
            var routeNumber = 0;

            var networkNode = networks.First();
            while (networkNode != null)
            {
                var network = networkNode.Value;
                routeNumber++;
                if (previousNetwork != null)
                {
                    path += $"\n({routeNumber}) Change:  {previousNetwork.getDestinationStation()} ({previousNetwork.getLine()}) to {network.getSourceStation()} ({network.getLine()})";
                }
                else
                {
                    previousNetwork = network;
                    path += $"\n({routeNumber}) Start:   {network.getSourceStation()} ({previousNetwork.getLine()})";
                }

                routeNumber++;
                path += $" \n({routeNumber})          {network}";

                networkNode = networkNode.Next;
            }

            routeNumber++;
            path += $"\n({routeNumber}) End:     {lastNetwork.getDestinationStation()} ({lastNetwork.getLine()})";
            Console.WriteLine(path);

            networksNode = networksNode.Next;
        }
    }

    public void LogAllNetworkPath(LinkedList<Network> networks)
    {
        var number = 0;
        var path = "";
        Network previousNetwork = null;
        Network lastNetwork = networks.Last().Value;
        var routeNumber = 0;

        var networkNode = networks.First();
        while (networkNode != null)
        {
            var network = networkNode.Value;
            routeNumber++;
            if (previousNetwork != null)
            {
                path += $"\n({routeNumber}) Change:  {previousNetwork.getDestinationStation()} ({previousNetwork.getLine()}) to {network.getSourceStation()} ({network.getLine()})";
                previousNetwork = network;
            }
            else
            {
                previousNetwork = network;
                path += $"({routeNumber}) Start:   {network.getSourceStation()} ({previousNetwork.getLine()})";
            }

            routeNumber++;
            path += $" \n({routeNumber})          {network}";

            networkNode = networkNode.Next;
        }

        routeNumber++;
        path += $"\n({routeNumber}) End:     {lastNetwork.getDestinationStation()} ({lastNetwork.getLine()})";
        Console.WriteLine(path);
    }

    public void LogStationNetwork(StationNetwork stationNetwork)
    {
        Console.WriteLine($"__________{stationNetwork.getStation().getName()} Network Station__________");
        LogAllNetworks(stationNetwork.getNetworks());
    }
    
    public void LogNewlyCreatedStationNetworkWithoutNetwork(StationNetwork stationNetwork)
    {
        Console.WriteLine($"{stationNetwork.getStation()} Station Created Successfully");
    }

    public void LogShortestPath(LinkedList<Network> networkList)
    {
        Console.WriteLine("__________Shortest Path__________");
        var path = "";
        var networkNode = networkList.First();
        while (networkNode != null)
        {
            var network = networkNode.Value;
            path += $"{network}";
            networkNode = networkNode.Next;
        }
        Console.WriteLine(path);
    }

    public void LogTotalDistance(int distance)
    {
        Console.WriteLine($"Total Journey Time: {distance} minutes");
    }
    
    public void LogDestSourceStationsName(string source, string dest)
    {
        Console.WriteLine($"Route: {source} to {dest}:");
    }
    
    public void LogDelayedNetwork(Network network)
    {
        Console.WriteLine($"{network.getLine()} Line: {network.getSourceStation()} - {network.getDestinationStation()} : {network.getTime()} min now {network.getTime() + network.getDelayTime()} min");
    }
    
    public void LogCloseNetwork(Network network)
    {
        Console.WriteLine($"{network.getLine()} Line: {network.getSourceStation()} - {network.getDestinationStation()} : {network.getClosureReason()}");
    }
    
    public void LogStationDoesNotExist(string station)
    {
        Console.WriteLine($"Station: {station}Doesn't Exist");
    }
    
    public void LogNoDelayRoute()
    {
        Console.WriteLine($"No Delayed Routes");
    }
    
    public void LogNoClosedRoute()
    {
        Console.WriteLine($"No Closed Routes");
    }
    
    public void LogStationDoesNotExist()
    {
        Console.WriteLine($"Station(S) Doesn't Exist");
    }
    
    public void Log(string str)
    {
        Console.WriteLine($"{str}");
    }
}