using System.Globalization;

namespace ConsoleApp3;

public interface ZoneOneGraphInterface
{
    public LinkedList<StationNetwork> GetStationNetworks();
    public Station CreateStation(String name);
    public Network CreateNetwork(Station stationOne, Station stationTwo, String line, int time);
    public void CreateStationNetwork(Station station);
    public void AddStationNetworkToList(StationNetwork stationNetwork);
    public void AddNetworkToStationNetwork(Station station, Network network);
    public StationNetwork FindStationNetworkBy(Station station);
    public LinkedList<Network> ConnectedNetworksToAStation(Station source);
    public Network GetNetworkInAStationNetwork(Station source, Station dest, string line);
    public int ComputeTotalTime(LinkedList<Network> networks);
    public void RelaxEdge(Network network, int[] distToV, Network[] edgeToV, PriorityQueue<Station, int> priorityQueue);
    public int GetIndexOfAStationFromList(Station station);
    public void InitializeDistances(int[] distances, Station source);
    public bool checkIfStationExist(string station);
    public StationNetwork fetchStation(string sourcestation);
}


//Baker Staion Network



