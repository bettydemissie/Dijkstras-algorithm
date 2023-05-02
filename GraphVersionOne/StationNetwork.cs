namespace GraphVersionOne;

public class StationNetwork
{
    private Station station;
    private LinkedList<Network> networks;

    public StationNetwork(Station station, LinkedList<Network> networks)
    {
        this.station = station;
        this.networks = networks;
    }
    
    public StationNetwork(Station station)
    {
        this.station = station;
    }

    public LinkedList<Network> getNetworks()
    {
        return networks;
    }
    
    public Station getStation()
    {
        return station;
    }
    
    public void addToNetworks(Network network)
    {
        networks.AddLast(network);
    }
}