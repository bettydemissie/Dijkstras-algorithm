using System.Diagnostics; //stopwatch

namespace ConsoleApp3;

public class Benchmarking
{ 
    public void benchmarkmethod()
    {
        // Start timing
        var stopwatch = Stopwatch.StartNew();

        // Code to benchmark goes here
        

        // Stop timing
        stopwatch.Stop();

        // Print the elapsed time
        Console.WriteLine("Elapsed time: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}
