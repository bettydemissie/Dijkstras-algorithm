﻿using System;
using Testing;
using GraphVersionTwo;

//Consistency Testing
ConsistencyTestV2 cTest1 = new ConsistencyTestV2();
ConsistencyTestV3 cTest3 = new ConsistencyTestV3();
Logger logger = new Logger();

//Console.WriteLine("Version 2");
//cTest1.RunTest1ForDijsktraVersion1();
//cTest1.RunTest2ForDijsktraVersion1();
cTest1.RunTest3ForDijsktraVersion1();
//cTest1.RunTest4ForDijsktraVersion1();
//cTest1.RunTestForGetTubeInformationVersion1();

//Console.WriteLine("Version 3");
//cTest3.RunTest1ForDijsktraVersion3();
//cTest3.RunTest2ForDijsktraVersion3();
//cTest3.RunTest3ForDijsktraVersion3();
//cTest3.RunTest4ForDijsktraVersion3();
//cTest3.RunTestForGetTubeInformationVersion3();


//Benchamarking Testing
//BenchmarkingTestV2 bTest1 = new BenchmarkingTestV2();
//BenchmarkingTestV3 bTest3 = new BenchmarkingTestV3();

//double bTest1DijkstraAns1 = bTest1.RunTestForDijsktraVersion1_1stEnquiry();
//double bTest1DijkstraAns2 = bTest1.RunTestForDijsktraVersion1_2ndEnquiry();
//double bTest1DijkstraAns3 = bTest1.RunTestForDijsktraVersion1_3rdEnquiry();
//double bTest1DijkstraAns4 = bTest1.RunTestForDijsktraVersion1_4thEnquiry();
//double bTest1DijkstraAns5 = bTest1.RunTestForDijsktraVersion1_5thEnquiry();
//double bTest1DijkstraAns6 = bTest1.RunTestForDijsktraVersion1_6thEnquiry();
//double bTest1TubeAns = bTest1.RunTestForGetTubeInformationVersion1();
//double bTest1ClosedAns = bTest1.RunTestForPrintAllClosedRoutesVersion1();
//double bTest1DelayAns = bTest1.RunTestForAddDelayNetworkVersion1();
//double bTest1AdjacencyListAns = bTest1.RunTestForCreatingAdacencyListVersion1();

//double bTest3DijkstraAns1 = bTest3.RunTestForDijsktraVersion3_1stEnquiry();
//double bTest3DijkstraAns2 = bTest3.RunTestForDijsktraVersion3_2ndEnquiry();
//double bTest3DijkstraAns3 = bTest3.RunTestForDijsktraVersion3_3rdEnquiry();
//double bTest3DijkstraAns4 = bTest3.RunTestForDijsktraVersion3_4thEnquiry();
//double bTest3DijkstraAns5 = bTest3.RunTestForDijsktraVersion3_5thEnquiry();
//double bTest3DijkstraAns6 = bTest3.RunTestForDijsktraVersion3_6thEnquiry();
//double bTest3TubeAns = bTest3.RunTestForGetTubeInformationVersion3();
//double bTest3ClosedAns = bTest3.RunTestForPrintAllClosedRoutesVersion3();
//double bTest3DelayAns = bTest3.RunTestForAddDelayNetworkVersion3();
//double bTest3AdjacencyListAns = bTest3.RunTestForCreatingAdacencyListVersion3();

//double averageElapsedTimeVersion1 = (bTest1DijkstraAns1 + bTest1DijkstraAns2 + bTest1DijkstraAns3 + bTest1DijkstraAns4 + bTest1DijkstraAns5 + bTest1DijkstraAns6) / 6;
//double averageElapsedTimeVersion3 = (bTest3DijkstraAns1 + bTest3DijkstraAns2 + bTest3DijkstraAns3 + bTest3DijkstraAns4 + bTest3DijkstraAns5 + bTest3DijkstraAns6) / 6;

//string outputFormat = "{0,-40} {1,-40} {2,-40} {3,-40}";

//logger.Log("\n");
//logger.Log("\n");
//logger.Log("Beginning of Benchmarking Tests");
//logger.Log("-------------------------------");
//logger.Log("");
//logger.Log(outputFormat, "Test Name", "Station(s)", "VersionTwo Elapsed Time (ms)", "VersionThree Elapsed Time (ms)");
//logger.Log("");
//logger.Log(outputFormat, "Dijsktra", "Baker Street - Goodge Street", bTest1DijkstraAns1, bTest3DijkstraAns1);
//logger.Log("");
//logger.Log(outputFormat, "Dijsktra", "Temple - Lambeth North", bTest1DijkstraAns2, bTest3DijkstraAns2);
//logger.Log("");
//logger.Log(outputFormat, "Dijsktra", "Green Park - Liverpool Street", bTest1DijkstraAns3, bTest3DijkstraAns3);
//logger.Log("");
//Console.WriteLine(outputFormat, "Dijsktra", "Marble Arch - Cannon Street", bTest1DijkstraAns4, bTest3DijkstraAns4);
//logger.Log("");
//logger.Log(outputFormat, "Dijsktra", "London Bridge - Marylebone", bTest1DijkstraAns5, bTest3DijkstraAns5);
//logger.Log("");
//logger.Log(outputFormat, "Dijsktra", "Paddington - Tower Hill", bTest1DijkstraAns6, bTest3DijkstraAns6);
//logger.Log("");
//logger.Log(outputFormat, "Getting Tube Information", "Tower Hill", bTest1TubeAns, bTest3TubeAns);
//logger.Log("");
//logger.Log(outputFormat, "Add Delay To Network", "Oxford Circus - Bond Street", bTest1ClosedAns, bTest3ClosedAns);
//logger.Log("");
//logger.Log(outputFormat, "Print Closed Routes", " ", bTest1DelayAns, bTest3DelayAns);
//logger.Log("");
//logger.Log(outputFormat, "Create Adjacency List", " ", bTest1AdjacencyListAns, bTest3AdjacencyListAns);
//logger.Log("");
//logger.Log("");
//logger.Log($"Average ELapsed Time (FindShortestPath) for VersionTwo: {averageElapsedTimeVersion1}(ms)");
//logger.Log("");
//logger.Log($"Average ELapsed Time (FindShortestPath) for VersionThree: {averageElapsedTimeVersion3}(ms)");
//logger.Log("");
//logger.Log("-------------------------------");
//logger.Log("End of Benchmarking Tests");

