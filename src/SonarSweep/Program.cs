//solution to puzzle listed on https://adventofcode.com/2021/day/1

using SonarSweep;

List<int> measurements = new List<int>() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

Console.WriteLine("Number of increases: " + SonarSweepUtils.CountMeasurementIncreases(measurements));


