namespace GraphVersionThree;

public class Station : AccessStatus
{
    private static int SID = 0;
    private int StationID;                       // a unique ID number 
    private string name;                          // name          
    private AccessStatus.ACCESS StationAccess;   // access method
    private int TravelZone;                      // Travel Zone its on

    public Station(string name, int TravelZone, AccessStatus.ACCESS StationAccess)
    {
        this.StationID = SID++;
        this.name = name;
        this.StationAccess = StationAccess;
        this.TravelZone = 1;

    }

    public Station(string name)
    {
        this.StationID = SID++;
        this.name = name;
        StationAccess = AccessStatus.ACCESS.Lift;
        TravelZone = 1;

    }

    public void setStationID(int StationID)
    {
        this.StationID = StationID;
    }

    public int getStationID()
    {
        return StationID;
    }

    public void setTravelZone(int TravelZone)
    {
        this.TravelZone = TravelZone;
    }

    public int getTravelZone()
    {
        return TravelZone;
    }

    public AccessStatus.ACCESS GetStationAccess()
    {
        return StationAccess;
    }


    public void SetStationAccess(AccessStatus.ACCESS StationAccess)
    {
        this.StationAccess = StationAccess;
    }

    public string getName()
    {
        return name;
    }

    public override string ToString()
    {
        return $"Station Name: {name} | Station ID: {StationID} | Station Access: {StationAccess} | Travel Zone: {TravelZone}";

    }
}