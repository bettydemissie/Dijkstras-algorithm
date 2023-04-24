using System.Security.Cryptography;
using System.Xml.Linq;

namespace ConsoleApp3;

public class Station : AccessStatus
{
    private static int SID = 0;
    private int StationID;                       // a unique ID number 
    private string name;                          // name                      
    private string TubeLine;                     // TubeLine
    private AccessStatus.ACCESS StationAccess;   // access method
    private int TravelZone;                      // Travel Zone its on
    private AccessStatus.STATUS StationStatus;   // open or closed


    public Station(string name, string TubeLine,
                AccessStatus.ACCESS StationAccess, int TravelZone,
                AccessStatus.STATUS StationStatus)
    {
        this.StationID = SID++;
        this.name = name;
        this.TubeLine = TubeLine;
        this.StationAccess = StationAccess;
        this.TravelZone = TravelZone;
        this.StationStatus = StationStatus;

    }


    //initialised constructor for the current tests, will delete when other parameters
    //in this constructor is initialised in Station implementation
    public Station(string name)
    {
        this.StationID = SID++;
        this.name = name;
        this.TubeLine = TubeLine;
        this.StationAccess = StationAccess;
        this.TravelZone = TravelZone;
        this.StationStatus = StationStatus;

    }

    public void setStationID(int StationID)
    {
        this.StationID = StationID;
    }

    public int getStationID()
    {
        return StationID;
    }

    public string getName()
    {
        return name;
    }

    public override string ToString()
    {
        return
            $"{name}" +
            $"{StationID.ToString()}" +
            $"{TubeLine}" +
            $"{StationAccess.ToString()}" +
            $"{TravelZone.ToString()}" +
            $"{StationStatus.ToString()}";
    }

    
}