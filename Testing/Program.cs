using System;
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

double bTest1DijkstraAns1 = bTest1.RunTestForDijsktraVersion1_1stEnquiry();
double bTest1DijkstraAns2 = bTest1.RunTestForDijsktraVersion1_2ndEnquiry();
double bTest1DijkstraAns3 = bTest1.RunTestForDijsktraVersion1_3rdEnquiry();
double bTest1DijkstraAns4 = bTest1.RunTestForDijsktraVersion1_4thEnquiry();
double bTest1DijkstraAns5 = bTest1.RunTestForDijsktraVersion1_5thEnquiry();
double bTest1DijkstraAns6 = bTest1.RunTestForDijsktraVersion1_6thEnquiry();
double bTest1TubeAns = bTest1.RunTestForGetTubeInformationVersion1();
double bTest1ClosedAns = bTest1.RunTestForPrintAllClosedRoutesVersion1();
double bTest1DelayAns = bTest1.RunTestForAddDelayNetworkVersion1();
double bTest1AdjacencyListAns = bTest1.RunTestForCreatingAdacencyListVersion1();

double bTest3DijkstraAns1 = bTest3.RunTestForDijsktraVersion3_1stEnquiry();
double bTest3DijkstraAns2 = bTest3.RunTestForDijsktraVersion3_2ndEnquiry();
double bTest3DijkstraAns3 = bTest3.RunTestForDijsktraVersion3_3rdEnquiry();
double bTest3DijkstraAns4 = bTest3.RunTestForDijsktraVersion3_4thEnquiry();
double bTest3DijkstraAns5 = bTest3.RunTestForDijsktraVersion3_5thEnquiry();
double bTest3DijkstraAns6 = bTest3.RunTestForDijsktraVersion3_6thEnquiry();
double bTest3TubeAns  = bTest3.RunTestForGetTubeInformationVersion3();
double bTest3ClosedAns = bTest3.RunTestForPrintAllClosedRoutesVersion3();
double bTest3DelayAns = bTest3.RunTestForAddDelayNetworkVersion3();
double bTest3AdjacencyListAns = bTest3.RunTestForCreatingAdacencyListVersion3();

double averageElapsedTimeVersion1 = (bTest1DijkstraAns1 + bTest1DijkstraAns2 + bTest1DijkstraAns3 + bTest1DijkstraAns4 + bTest1DijkstraAns5 + bTest1DijkstraAns6) / 6; 
double averageElapsedTimeVersion3 = (bTest3DijkstraAns1 + bTest3DijkstraAns2 + bTest3DijkstraAns3 + bTest3DijkstraAns4 + bTest3DijkstraAns5 + bTest3DijkstraAns6) / 6;

string outputFormat = "{0,-40} {1,-40} {2,-40} {3,-40}";

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Beginning of Benchmarking Tests");
Console.WriteLine("-------------------------------");
Console.WriteLine();
Console.WriteLine(outputFormat, "Test Name", "Station(s)", "VersionOne Elapsed Time (ms)", "VersionThree Elapsed Time (ms)");
Console.WriteLine();
Console.WriteLine(outputFormat, "Dijsktra", "Baker Street - Goodge Street", bTest1DijkstraAns1, bTest3DijkstraAns1);
Console.WriteLine();
Console.WriteLine(outputFormat, "Dijsktra", "Temple - Lambeth North", bTest1DijkstraAns2, bTest3DijkstraAns2);
Console.WriteLine();
Console.WriteLine(outputFormat, "Dijsktra", "Green Park - Liverpool Street", bTest1DijkstraAns3, bTest3DijkstraAns3);
Console.WriteLine();
Console.WriteLine(outputFormat, "Dijsktra", "Marble Arch - Cannon Street", bTest1DijkstraAns4, bTest3DijkstraAns4);
Console.WriteLine();
Console.WriteLine(outputFormat, "Dijsktra", "London Bridge - Marylebone", bTest1DijkstraAns5, bTest3DijkstraAns5);
Console.WriteLine();
Console.WriteLine(outputFormat, "Dijsktra", "Paddington - Tower Hill", bTest1DijkstraAns6, bTest3DijkstraAns6);
Console.WriteLine();
Console.WriteLine(outputFormat, "Getting Tube Information", "Tower Hill", bTest1TubeAns, bTest3TubeAns);
Console.WriteLine();
Console.WriteLine(outputFormat, "Add Delay To Network", "Oxford Circus - Bond Street", bTest1ClosedAns, bTest3ClosedAns);
Console.WriteLine();
Console.WriteLine(outputFormat, "Print Closed Routes", " ", bTest1DelayAns, bTest3DelayAns);
Console.WriteLine();
Console.WriteLine(outputFormat, "Create Adjacency List", " ", bTest1AdjacencyListAns, bTest3AdjacencyListAns);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Average ELapsed Time (FindShortestPath) for VersionOne: {averageElapsedTimeVersion1}(ms)");
Console.WriteLine();
Console.WriteLine($"Average ELapsed Time (FindShortestPath) for VersionThree: {averageElapsedTimeVersion3}(ms)");
Console.WriteLine();
Console.WriteLine("-------------------------------");
Console.WriteLine("End of Benchmarking Tests");


////Analysis of Benchmarking Tests
//// Define the number of times each test case should be run
//const int numRuns = 6;

//// Define a dictionary to store the execution times for each test case and version
//Dictionary<string, Dictionary<string, List<double>>> results = new Dictionary<string, Dictionary<string, List<double>>>();

//// Run each test case for each version of the program and record the execution time
//for (int i = 0; i < numRuns; i++)
//{
//    // Run test case 1
//    double version1Time1 = bTest1.RunTestForDijsktraVersion1_1stEnquiry();
//    double version2Time1 = bTest3.RunTestForDijsktraVersion3_1stEnquiry();
//    AddResult("Test 1", "Version 1", version1Time1);
//    AddResult("Test 1", "Version 3", version2Time1);

//    // Run test case 2
//    double version1Time2 = bTest1.RunTestForDijsktraVersion1_2ndEnquiry();
//    double version2Time2 = bTest3.RunTestForDijsktraVersion3_2ndEnquiry();
//    AddResult("Test 2", "Version 1", version1Time2);
//    AddResult("Test 2", "Version 3", version2Time2);

//    // Run test case 3
//    double version1Time3 = bTest1.RunTestForDijsktraVersion1_3rdEnquiry();
//    double version2Time3 = bTest3.RunTestForDijsktraVersion3_3rdEnquiry();
//    AddResult("Test 3", "Version 1", version1Time3);
//    AddResult("Test 3", "Version 3", version2Time3);

//    // Run test case 4
//    double version1Time4 = bTest1.RunTestForDijsktraVersion1_4thEnquiry();
//    double version2Time4 = bTest3.RunTestForDijsktraVersion3_4thEnquiry();
//    AddResult("Test 4", "Version 1", version1Time4);
//    AddResult("Test 4", "Version 3", version2Time4);

//    // Run test case 5
//    double version1Time5 = bTest1.RunTestForDijsktraVersion1_5thEnquiry();
//    double version2Time5 = bTest3.RunTestForDijsktraVersion3_5thEnquiry();
//    AddResult("Test 5", "Version 1", version1Time5);
//    AddResult("Test 5", "Version 3", version2Time5);

//    // Run test case 6
//    double version1Time6 = bTest1.RunTestForDijsktraVersion1_6thEnquiry();
//    double version2Time6 = bTest3.RunTestForDijsktraVersion3_6thEnquiry();
//    AddResult("Test 6", "Version 1", version1Time6);
//    AddResult("Test 6", "Version 3", version2Time6);

//}

//// Calculate the average execution times for each test case and version
//foreach (var testCase in results.Keys)
//{
//    foreach (var version in results[testCase].Keys)
//    {
//        double totalTime = results[testCase][version].Sum();
//        double averageTime = totalTime / numRuns;
//        Console.WriteLine($"Average time for {version} on {testCase}: {averageTime} seconds");
//        Console.WriteLine();
//    }
//}

//// Helper method to add a result to the dictionary
//void AddResult(string testCase, string version, double time)
//{
//    if (!results.ContainsKey(testCase))
//    {
//        results[testCase] = new Dictionary<string, List<double>>();
//    }

//    if (!results[testCase].ContainsKey(version))
//    {
//        results[testCase][version] = new List<double>();
//    }

//    results[testCase][version].Add(time);
//}

//// Calculate the total execution times for version 1 and version 3
//double version1TotalTime = 0;
//double version3TotalTime = 0;
//foreach (var testCase in results.Keys)
//{
//    version1TotalTime += results[testCase]["Version 1"].Sum();
//    version3TotalTime += results[testCase]["Version 3"].Sum();
//}

//// Calculate the average execution times for version 1 and version 3
//double version1AverageTime = version1TotalTime / (numRuns * 6);
//double version3AverageTime = version3TotalTime / (numRuns * 6);


//Console.WriteLine();
//Console.WriteLine("Analysis of Benchmarking Tests");
//Console.WriteLine();
//Console.WriteLine($"Average time for Version 1: {version1AverageTime} seconds");
//Console.WriteLine($"Average time for Version 3: {version3AverageTime} seconds");




