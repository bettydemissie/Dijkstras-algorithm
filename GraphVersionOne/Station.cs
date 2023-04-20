namespace ConsoleApp3;

public class Station
{
    private string name;

    public Station(string name)
    {
        this.name = name;
      
    }
    
    public override string ToString()
    {
        return
            $"{name}";
    }

    public string getName()
    {
        return name;
    }
}