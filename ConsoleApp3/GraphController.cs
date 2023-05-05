namespace ConsoleApp3;

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
        foreach (var stationNetwork in graph.GetStationNetworks())
        {
            foreach (var network in stationNetwork.getNetworks())
            {
                if (network.isDelayed())
                {
                    delayedRouteExists = true;
                    logger.LogDelayedNetwork(network);
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
        var delayedClosedExists = false;
        foreach (var stationNetwork in graph.GetStationNetworks())
        {
            foreach (var network in stationNetwork.getNetworks())
            {
                if (network.isNetworkClosed())
                {
                    delayedClosedExists = true;
                    logger.LogCloseNetwork(network);
                }
            }
        }
        if (!delayedClosedExists)
        {
            logger.LogNoClosedRoute();
        }
    }

    public void FindFastestWalkingRoutes(string sourceStation, string destStation)
    {
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
        var source = graph.fetchStation(sourceStation).getStation();
        var dest = graph.fetchStation(destStation).getStation();
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
        //an array to all distances of all vertices in the graph
        int[] disToV = new int[graph.GetStationNetworks().Count];
        //initialize each value with infinity
        graph.InitializeDistances(disToV, source);
        //an array to store networks (edgeToV)
        Network[] edgeToV = new Network[graph.GetStationNetworks().Count];
        
        //initialize a priority queue
        PriorityQueue<Station, int> priorityQueue = new PriorityQueue<Station, int>();
        priorityQueue.Enqueue(source,0);

        while (priorityQueue.Count > 0)
        {
            //get nearest station/vertex
            var nearestStation = priorityQueue.Dequeue();
            
            //fetch all neighbors
            var neighbornetworks = graph.ConnectedNetworksToAStation(nearestStation);
            if (neighbornetworks != null)
            {
                foreach (var network in neighbornetworks)
                {
                    //relax edge
                    graph.RelaxEdge(network, disToV,edgeToV,priorityQueue);
                }
            }
        }
        //get the shortest distance
        var dvindex = graph.GetIndexOfAStationFromList(dest);
        int shortestdistance = disToV[dvindex];
        //compute the paths
        var paths =  new LinkedList<Network>();
        Network destnetwork = edgeToV[dvindex];
        paths.AddLast(destnetwork);
        while (destnetwork.getSourceStation().getName() != source.getName())
        {
            var svindex = graph.GetIndexOfAStationFromList(destnetwork.getSourceStation());
            Network network = edgeToV[svindex];
            paths.AddFirst(network);
            destnetwork = network;
        }
        
        logger.LogDestSourceStationsName(source.getName(), dest.getName());
        logger.LogAllNetworkPath(paths);
        logger.LogTotalDistance(shortestdistance);
    }
}