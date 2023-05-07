using Testing;

//Consistency Testing
ConsistencyTestV1 cTest1 = new ConsistencyTestV1();
ConsistencyTestV3 cTest3 = new ConsistencyTestV3();

cTest1.RunTestForDijsktraVersion1();
cTest1.RunTestForGetTubeInformationVersion1();
cTest1.RunTestForPrintAllClosedRoutesVersion1();
cTest1.RunTestForPrintAllDelayedRoutesVersion1();

cTest3.RunTestForDijsktraVersion3();
cTest3.RunTestForGetTubeInformationVersion3();
cTest3.RunTestForPrintAllClosedRoutesVersion3();
cTest3.RunTestForPrintAllDelayedRoutesVersion3();

//Benchamarking Testing
BenchmarkingTestV1 bTest1 = new BenchmarkingTestV1();
BenchmarkingTestV3 bTest3 = new BenchmarkingTestV3();

double bTest1DijAns = bTest1.RunTestForDijsktraVersion1();
double bTest1TubeAns = bTest1.RunTestForGetTubeInformationVersion1();
double bTest1ClosedAns = bTest1.RunTestForPrintAllClosedRoutesVersion1();
double bTest1DelayAns = bTest1.RunTestForAddDelayNetworkVersion1();

double bTest3DijAns = bTest3.RunTestForDijsktraVersion3();
double bTest3TubeAns  = bTest3.RunTestForGetTubeInformationVersion3();
double bTest3ClosedAns = bTest3.RunTestForPrintAllClosedRoutesVersion3();
double bTest3DelayAns = bTest3.RunTestForAddDelayNetworkVersion3();

string outputFormat = "{0,-40} {1,-40} {2,-40} {3,-40}";

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Beginning of Benchmarking Tests");
Console.WriteLine("-------------------------------");
Console.WriteLine();
Console.WriteLine(outputFormat, "Test Name", "Test Name", "VersionOne Elapsed Time (ms)", "VersionThree Elapsed Time (ms)");
Console.WriteLine();
Console.WriteLine(outputFormat, "Dijsktra", "Baker Street - Goodge Street", bTest1DijAns, bTest3DijAns);
Console.WriteLine();
Console.WriteLine(outputFormat, "Getting Tube Information", "Tower Hill", bTest1TubeAns, bTest3TubeAns);
Console.WriteLine();
Console.WriteLine(outputFormat, "Add Delay To Network", "Oxford Circus - Bond Street", bTest1ClosedAns, bTest3ClosedAns);
Console.WriteLine();
Console.WriteLine(outputFormat, "Print Closed Routes", " ", bTest1DelayAns, bTest3DelayAns);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("-------------------------------");
Console.WriteLine("End of Benchmarking Tests");


