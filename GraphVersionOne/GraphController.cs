namespace GraphVersionOne;

public class GraphController
{
    private ZoneOneGraphInterface graph;
    private Logger logger;

    public GraphController(ZoneOneGraphInterface zoneOneGraph)
    {
        this.graph = zoneOneGraph;
        logger = new Logger();
    }

    public void PrintAllDelayedRoutes()
    {
        var delayedRouteExists = false;
        var stationNetworks = graph.GetStationNetworks();
        for (int i = 0; i < stationNetworks.Count(); i++)
        {
            var networks = stationNetworks.ElementAt(i).Value.getNetworks();
            for (int j = 0; j < networks.Count(); j++)
            {
                var network = networks.ElementAt(j);
                if (network.Value.isDelayed())
                {
                    delayedRouteExists = true;
                    logger.LogDelayedNetwork(network.Value);
                }
            }
        }

        if (!delayedRouteExists)
        {
            logger.LogNoDelayRoute();
        }
    }


    public void PrintAllClosedRoutes()
    {
        var closedRouteExists = false;
        var stationNetworks = graph.GetStationNetworks();
        for (int i = 0; i < stationNetworks.Count(); i++)
        {
            var networks = stationNetworks.ElementAt(i).Value.getNetworks();
            for (int j = 0; j < networks.Count(); j++)
            {
                var network = networks.ElementAt(j);
                if (network.Value.isNetworkClosed())
                {
                    closedRouteExists = true;
                    logger.LogCloseNetwork(network.Value);
                }
            }
        }

        if (!closedRouteExists)
        {
            logger.LogNoClosedRoute();
        }
    }




    public void FindFastestWalkingRoutes(string sourceStation, string destStation)
    {
        //added to check if grapgh
        var source = graph.fetchStation(sourceStation).getStation();
        var dest = graph.fetchStation(destStation).getStation();
        if (source != null && dest != null)
        {
            djikstra(source,dest);
        }
        else
        {
            logger.LogStationDoesNotExist();
        }
    }
    
    public void AddDelayToNetwork(string sourceStation, string destStation, string line, int delay)
    {
        var source = graph?.fetchStation(sourceStation).getStation();
        var dest = graph?.fetchStation(destStation).getStation();
        if (source != null  && dest != null)
        {
            var firstNetwork = graph.GetNetworkInAStationNetwork(source, dest, line);
            var secondNetwork = graph.GetNetworkInAStationNetwork(dest, source, line);
            firstNetwork.addDelay(delay);
            secondNetwork.addDelay(delay);
            logger.LogDelayedNetwork(firstNetwork);
            logger.LogDelayedNetwork(secondNetwork);
        }
        else
        {
            logger.LogStationDoesNotExist();
        }
        
    }
    
    public void OpenOrCloseStationsNetwork(string sourceStation, string destStation, string line, string reason, bool closeStatus)
    {
        var source = graph.fetchStation(sourceStation).getStation();
        var dest = graph.fetchStation(destStation).getStation();
        if (source != null  && dest != null)
        {
            var firstNetwork = graph.GetNetworkInAStationNetwork(source, dest, line);
            var secondNetwork = graph.GetNetworkInAStationNetwork(dest, source, line);
            firstNetwork.closeNetwork(closeStatus, reason);
            secondNetwork.closeNetwork(closeStatus, reason);
            logger.LogCloseNetwork(firstNetwork);
            logger.LogCloseNetwork(secondNetwork);
        }
        else
        {
            logger.LogStationDoesNotExist();
        }
    }

    public void DisplayTubeInformation(string sourceStation)
    {
        //validation check
        var source = graph.fetchStation(sourceStation).getStation();
        if (source != null)
        {
            logger.LogStation(source);
        }
        else
        {
            logger.LogStationDoesNotExist(sourceStation);
        }
    }

    private void djikstra(Station source, Station dest)
    {
        int stationCount = graph.GetStationNetworks().Count();

        int[] disToV = new int[stationCount];
        graph.InitializeDistances(disToV, source);

        Network[] edgeToV = new Network[stationCount];

        PriorityQueue<Station, int> priorityQueue = new PriorityQueue<Station, int>();
        priorityQueue.Enqueue(source, 0);

        while (!priorityQueue.IsEmpty())
        {
            var nearestStation = priorityQueue.Dequeue();

            var neighbornetworks = graph.ConnectedNetworksToAStation(nearestStation.Element);
            if (neighbornetworks != null)
            {
                for (int i = 0; i < neighbornetworks.Count(); i++)
                {
                    var network = neighbornetworks.ElementAt(i);
                    graph.RelaxEdge(network.Value, disToV, edgeToV, priorityQueue);
                }
            }
        }

        int destIndex = graph.GetIndexOfAStationFromList(dest);
        int shortestDistance = disToV[destIndex];

        var paths = new LinkedList<Network>();
        Network destNetwork = edgeToV[destIndex];
        paths.AddLast(destNetwork);

        while (destNetwork.getSourceStation().getName() != source.getName())
        {
            int sourceIndex = graph.GetIndexOfAStationFromList(destNetwork.getSourceStation());
            Network network = edgeToV[sourceIndex];
            paths.AddFirst(network);
            destNetwork = network;
        }

        logger.LogDestSourceStationsName(source.getName(), dest.getName());
        logger.LogAllNetworkPath(paths);
        logger.LogTotalDistance(shortestDistance);
    }

}