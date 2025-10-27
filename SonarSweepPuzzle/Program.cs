
List<int> measurements = new List<int>() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

Console.WriteLine(CountMeasurementIncreases(measurements));

int CountMeasurementIncreases(List<int> measurements) {
    int count = 0;
    for (int i = 1; i < measurements.Count; i++) {
        if (measurements[i] > measurements[i - 1]) {
            count++;
        }
    }
    return count;
}
