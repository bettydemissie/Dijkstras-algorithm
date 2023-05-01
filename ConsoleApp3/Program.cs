using System.Security;
using ConsoleApp3;

Menu newMenu = new Menu();

string filepath = "/Users/Ifeoma1/Downloads/Zone-1-walkingdistance.xlsx";
string filepathstations = "/Users/Ifeoma1/Downloads/StationsExcel.xlsx";

ReadExcel read = new ReadExcel();
ReadStationsandNetworks text = new ReadStationsandNetworks(read);
var stations = text.GetTheStations(filepathstations);

var networks = text.GetNetworks(filepath);

foreach (Network item in networks)
{
    Console.WriteLine(item);

}

Console.WriteLine("\n");

//newMenu.runMenu();