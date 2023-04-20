namespace ConsoleApp3;

public class Network
{
    private Station SourceStation;
    private Station DestinationStation;
    private string line;
    private int time;
    private int delay;
    private bool closed;
    private string reasonforclosure;

    public Network(Station sourceStation, Station destinationStation, string line, int time)
    {
        SourceStation = sourceStation;
        DestinationStation = destinationStation;
        this.line = line;
        this.time = time;
        delay = 0;
        closed = false;
        reasonforclosure = "";
    }
    
    public void addDelay(int delay)
    {
        this.delay = delay;
    }
    
    public void closeNetwork(bool closed, string reasonforclosure)
    {
        this.closed = closed;
        this.reasonforclosure = reasonforclosure;
    }
    
    public override string ToString()
    {
        return
            $"{SourceStation.getName()} ({line}) to {DestinationStation.getName()} ({line})   {time} min";
    }
    
    public Station getSourceStation()
    {
        return SourceStation;
    }
    
    public Station getDestinationStation()
    {
        return DestinationStation;
    }
    
    public string getLine()
    {
        return line;
    }
    
    public int getTime()
    {
        return time;
    }
    
    public int getDelayTime()
    {
        return delay;
    }
    
    public string getClosureReason()
    {
        return reasonforclosure;
    }
    
    public bool isNetworkClosed()
    {
        return closed;
    }
    
    public bool isDelayed()
    {
        return delay != 0;
    }

}

