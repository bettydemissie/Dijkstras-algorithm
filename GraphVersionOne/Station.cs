using System.Security.Cryptography;
using System.Xml.Linq;

namespace GraphVersionOne;

public class Station:AccessStatus
{
    private static int SID = 0;
    private int StationID;                       // a unique ID number 
    private string name;                          // name                      
    //consider removing since this is implemented in the Network class
    //private string TubeLine;                     // TubeLine
    private AccessStatus.ACCESS StationAccess;   // access method
    private int TravelZone;                      // Travel Zone its on
    private AccessStatus.STATUS StationStatus;   // open or closed


    public Station(string name, int TravelZone)//AccessStatus.ACCESS StationAccess, int TravelZone, AccessStatus.STATUS StationStatus
    {
        this.StationID = SID++;
        this.name = name;
        //this.TubeLine = TubeLine;
        //this.StationAccess = StationAccess;
        this.TravelZone = 1;
        //this.StationStatus = StationStatus;

    }


    //initialised constructor for the current tests, will delete when other parameters
    //in this constructor is initialised in Station implementation
    public Station(string name)
    {
        this.StationID = SID++;
        this.name = name;
        //TubeLine = "";
        StationAccess = AccessStatus.ACCESS.Lift;
        TravelZone = 1;
        StationStatus = AccessStatus.STATUS.Open;

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

    //public void setTubeLine(string TubeLine)
    //{
    //    this.TubeLine = TubeLine;
    //}

    //public string getTubeLine()
    //{
    //    return TubeLine;
    //}

    public string getName()
    {
        return name;
    }

    public override string ToString()
    {
        return
            $"Station Name: {name} ," + 
            $"Station ID: {StationID.ToString()} ," +
            $"Station Access: {StationAccess.ToString()} ," +
            $"Travel Zone: {TravelZone.ToString()} ," +
            $"Station Status: {StationStatus.ToString()} ,";
    }

    
}