using System.Security.Cryptography;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using static GraphVersionOne.AccessStatus;

namespace GraphVersionOne;

public class Station:AccessStatus
{
    private static int SID = 0;
    private int StationID;                       // a unique ID number 
    private string name;                          // name                      
    private AccessStatus.ACCESS StationAccess;   // access method
    private int TravelZone;                      // Travel Zone its on
    private AccessStatus.STATUS StationStatus;   // open or closed


    public Station(string name, int TravelZone, ACCESS StationAccess, AccessStatus.STATUS StationStatus)
    {
        this.StationID = SID++;
        this.name = name;
        this.StationAccess = StationAccess;
        this.StationStatus = StationStatus;
        this.TravelZone = 1;
    }

    //initialised constructor for the current tests, will delete when other parameters
    //in this constructor is initialised in Station implementation
    public Station(string name)
    {
        this.StationID = SID++;
        this.name = name;
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

    public AccessStatus.ACCESS GetStationAccess()
    {
        return StationAccess;
    }

    public AccessStatus.STATUS GetStationStatus()
    {
        return StationStatus;
    }

    public void SetStationStatus(AccessStatus.STATUS status)
    {
        StationStatus = status;
    }

    public string getName()
    {
        return name;
    }

    public override string ToString()
    {
        return $"Station Name: {name} | Station ID: {StationID} | Station Access: {StationAccess} | Travel Zone: {TravelZone} | Station Status: {StationStatus}";
    }
}
