using System;

namespace GraphVersionTwo;

public class ZoneOneGraph:ZoneOneGraphInterface
{
    private LinkedList<StationNetwork> stationNetworks;
    
    private Logger logger;
    public ZoneOneGraph()
    {
        stationNetworks = new LinkedList<StationNetwork>();
        logger = new Logger();
    }
    
    public LinkedList<StationNetwork> GetStationNetworks()
    {
        return stationNetworks;
    }
    public Station CreateStation(string name)
    {
        return new Station(name);
    }
    public Network CreateNetwork(Station stationOne, Station stationTwo, string line, int time)
    {
        return new Network(stationOne, stationTwo, line, time);
    }
    public void CreateStationNetwork(Station station)
    {
        //if station network doesnt exist
        //-create station network
        //initialize a list
        LinkedList<Network> networks = new LinkedList<Network>();
        var stationNetwork = new StationNetwork(station, networks);
        AddStationNetworkToList(stationNetwork);
        //log new created station network
        logger.LogNewlyCreatedStationNetworkWithoutNetwork(stationNetwork);
    }
    public void CreateStationNetwork(Station station, Network network)
    {
        //if station network doesnt exist
        //-create station network
        //initialize a list
        LinkedList<Network> networks = new LinkedList<Network>();
        var stationNetwork = new StationNetwork(station, networks);
        networks.AddLast(network);
        AddStationNetworkToList(stationNetwork);
    }
    public void AddStationNetworkToList(StationNetwork stationNetwork)
    {
        var stationN = FindStationNetworkBy(stationNetwork.getStation());
        if (stationN == null)
        {
            stationNetworks.AddLast(stationNetwork);
        }
    }
    public void AddNetworkToStationNetwork(Station sourceStation, Network network)
    {   
        //if stationnetwork exist
        //add the network to it //  B-G
        //if it doesnt exist       B -> B-G
        ////            G -> G-B
        //create station network and add the network to it
        var firstStationNetwork = FindStationNetworkBy(sourceStation);
        var secondStationNetwork = FindStationNetworkBy(network.getDestinationStation());
        if (firstStationNetwork != null)
        {
            
            firstStationNetwork.addToNetworks(network);
        }
        else
        {
            CreateStationNetwork(sourceStation, network);
        }
        
        Network secondNetwork = SwitchNetworkStations(network);
      
        if (secondStationNetwork != null)
        {
            secondStationNetwork.addToNetworks(secondNetwork);
        }
        else
        {
            
            CreateStationNetwork(network.getDestinationStation(), secondNetwork);
        }
        
        logger.LogAllStationNetworks(stationNetworks);
    }
    private Network SwitchNetworkStations(Network network)
    {
        return new Network(network.getDestinationStation(), network.getSourceStation(), network.getLine(), network.getTime());
    }
    public StationNetwork FindStationNetworkBy(Station station)
    {
        ListNode<StationNetwork> currentNode = stationNetworks.head;

        while (currentNode != null)
        {
            StationNetwork stationNetwork = currentNode.Value;

            if (stationNetwork.getStation().getName().Equals(station.getName()))
            {
                return stationNetwork;
            }

            currentNode = currentNode.Next;
        }

        return null;
    }

    public LinkedList<Network> ConnectedNetworksToAStation(Station source)
    {
        //find station network by station
        var stationNetwork = FindStationNetworkBy(source);
        //fetch all the destination stations on each edges
        if (stationNetwork != null)
        {
            logger.LogStationNetwork(stationNetwork);
            return stationNetwork.getNetworks();
        }
        return null;
    }

    public Network GetNetworkInAStationNetwork(Station source, Station dest, string line)
    {
        var stationNetwork = FindStationNetworkBy(source);

        if (stationNetwork != null)
        {
            ListNode<Network> currentNode = stationNetwork.getNetworks().head;

            while (currentNode != null)
            {
                Network network = currentNode.Value;

                if (network.getSourceStation() == source && network.getDestinationStation() == dest && network.getLine() == line)
                {
                    return network;
                }

                currentNode = currentNode.Next;
            }
        }

        return null;
    }

    public int ComputeTotalTime(LinkedList<Network> networks)
    {
        var total = 0;
        ListNode<Network> currentNode = networks.head;

        while (currentNode != null)
        {
            Network network = currentNode.Value;
            total += network.getTime();
            currentNode = currentNode.Next;
        }

        return total;
    }

    public void RelaxEdge(Network network, int[] distToV, Network[] edgeToV, PriorityQueue<Station, int> priorityQueue)
    {
        Station sv = network.getSourceStation();
        Station dv = network.getDestinationStation();
        var dvindex = GetIndexOfAStationFromList(dv);
      
        var dvvalue = distToV[dvindex];
      
        var svindex = GetIndexOfAStationFromList(sv);
        var svvalue = distToV[svindex];
       
        if (dvvalue > svvalue + network.getTime() + network.getDelayTime())
        {
            distToV[dvindex] = svvalue + network.getTime() + network.getDelayTime();
            edgeToV[dvindex] = network;
            priorityQueue.Enqueue(dv, distToV[dvindex]);
        }
    }
    public int GetIndexOfAStationFromList(Station station)
    {
        for (int i = 0; i < stationNetworks.Count(); i++)
        {
            if (stationNetworks.ElementAt(i).Value.getStation().getName() == station.getName()) //rewrite statement
            {
                return i;
            }
        }

        return -1;
    }
    public void InitializeDistances(int[] distances, Station source)
    {
        logger.LogAllStationNetworks(stationNetworks);
        for (int i = 0; i < stationNetworks.Count(); i++)
        {
            if (stationNetworks.ElementAt(i).Value.getStation().getName() == source.getName())
            {
                distances[i] = 0;
            }
            else
            {
                distances[i] = int.MaxValue;
            }
        }
    }

    public LinkedList<Network> ShortestBetweenTwoPaths(LinkedList<Network> firstpath, LinkedList<Network> secondpath)
    {
        int distance = ComputeTotalTime(secondpath);
        Console.WriteLine(distance);
        if (firstpath.Count() != 0)
        {
            int currentResult = ComputeTotalTime(firstpath);
            if (distance < currentResult)
            {
                return secondpath;
            }
            else
            {
                return firstpath;
            }
        }
        firstpath = secondpath;
        return firstpath;
    }

    public LinkedList<LinkedList<Network>> GetAllPathFrom(Station source, Station dest)
    {
        var result = new LinkedList<LinkedList<Network>>();
        var shortestresult = new LinkedList<Network>();
        var queue = new LinkedList<LinkedList<Network>>();
        var networks = ConnectedNetworksToAStation(source);

        var networksCount = networks.Count();
        var networksIndex = 0;

        while (networksIndex < networksCount)
        {
            var network = networks.ElementAt(networksIndex);
            var list = new LinkedList<Network>();
            list.AddLast(network.Value);
            queue.AddLast(list);

            networksIndex++;
        }

        while (queue.Count() > 0)
        {
            var pathNode = queue.First();
            var pathList = pathNode.Value;
            var lastNode = pathList.Last();
            var path = lastNode.Value;

            queue.RemoveFirst();
            var destinationNode = path.getDestinationStation();

            if (destinationNode == dest)
            {
                shortestresult = ShortestBetweenTwoPaths(shortestresult, pathList);
                result.AddLast(pathList);
            }
            else
            {
                var neighbornetworks = ConnectedNetworksToAStation(destinationNode);
                if (neighbornetworks != null)
                {
                    var neighbornetworksCount = neighbornetworks.Count();
                    var neighbornetworksIndex = 0;

                    while (neighbornetworksIndex < neighbornetworksCount)
                    {
                        var network = neighbornetworks.ElementAt(neighbornetworksIndex);
                        if (network.Value.getDestinationStation() != path.getSourceStation())
                        {
                            var newPathList = new LinkedList<Network>();
                            var currentNode = pathList.head;

                            while (currentNode != null)
                            {
                                newPathList.AddLast(currentNode.Value);
                                currentNode = currentNode.Next;
                            }

                            newPathList.AddLast(network.Value);
                            queue.AddLast(newPathList);
                        }

                        neighbornetworksIndex++;
                    }
                }
            }
        }

        logger.LogAllNetworkPaths(result);
        logger.LogShortestPath(shortestresult);
        return result;
    }


    public bool checkIfStationExist(string station)
    {
        var deststation = fetchStation(station);
        if (deststation != null)
        {
            return true;
        }

        return false;
    }

    public StationNetwork fetchStation(string sourceStation)
    {
        for (int i = 0; i < stationNetworks.Count(); i++)
        {
            if (stationNetworks.ElementAt(i).Value.getStation().getName() == sourceStation)
            {
                return stationNetworks.ElementAt(i).Value;
            }
        }

        return null;
    }

}