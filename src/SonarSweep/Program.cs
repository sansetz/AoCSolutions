//solution to puzzle listed on https://adventofcode.com/2021/day/1

using SonarSweep;


string inputFilePath;
int windowSize;
if (args.Length != 2) {
    // Use default values
    inputFilePath = @"./input.txt";
    windowSize = 3;
}
else {
    inputFilePath = args[0];
    if (!int.TryParse(args[1], out windowSize))
        windowSize = 3;
}

List<int> measurements = SonarSweepUtils.ReadInput(inputFilePath);

Console.WriteLine(
    "Number of increases: " +
    SonarSweepUtils.CountMeasurementIncreases(measurements)
);

Console.WriteLine(
    "Number of window increases: " +
    SonarSweepUtils.CountMeasurementWindowIncreases(
        measurements,
        windowSize
    )
);


