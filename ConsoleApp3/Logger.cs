namespace GraphVersionThree;

public class Logger
{
    public void LogAllNetworks(LinkedList<Network> networks)
    {
        foreach (var network in networks)
        {
            Console.WriteLine(network);
        }
    }
    public void LogStation(Station station)
    { 
        Console.WriteLine(station);
        
    }
    public void LogAllStationNetworks(LinkedList<StationNetwork> stationNetworks)
    {
        foreach (var stationNetwork in stationNetworks)
        { 
            Console.WriteLine($"__________Beginning of {stationNetwork.getStation().getName()} Station Network____");
           Console.WriteLine(stationNetwork.getStation());
           LogAllNetworks(stationNetwork.getNetworks());
           Console.WriteLine($"__________End of {stationNetwork.getStation().getName()} Station Network____");
           Console.WriteLine("");
        }
    }
    public void LogAllNetworkPaths(LinkedList<LinkedList<Network>> networksLists)
    { 
        Console.WriteLine("_________RESULT________");
        var number = 0;
        foreach (var networks in networksLists)
        {
            var path = "";
            number++;
            path += $" {number}. ";
            Network previousNetwork = null;
            Network lastNetwork = networks.Last();
            var routeNumber = 0;
           
            foreach (var network in networks)
            {
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
            }
            routeNumber++;
            path += $"\n({routeNumber}) End:     {lastNetwork.getDestinationStation()} ({lastNetwork.getLine()})";
            Console.WriteLine(path);
        }
    }
    
    public string LogAllNetworkPath(LinkedList<Network> networks)
    {
        var number = 0;
        var path = "";
        Network previousNetwork = null;
            Network lastNetwork = networks.Last();
            var routeNumber = 0;
           
            foreach (var network in networks)
            {
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
            }
            routeNumber++;
            path += $"\n({routeNumber}) End:     {lastNetwork.getDestinationStation()} ({lastNetwork.getLine()})";
            Console.WriteLine(path);
        return path;
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
        foreach (var network in networkList)
        {
            path += $"{network}";
            
        }
        Console.WriteLine(path);
    }
    
    public string LogTotalDistance(int distance)
    {
        Console.WriteLine($"Total Journey Time: {distance} minutes");
        return $"Total Journey Time: {distance} minutes";
    }
    
    public string LogDestSourceStationsName(string source, string dest)
    {
        Console.WriteLine($"Route: {source} to {dest}:");
        return $"Route: {source} to {dest}:";
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