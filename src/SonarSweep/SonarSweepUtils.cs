namespace SonarSweep {
    public static class SonarSweepUtils {

        public static List<int> ReadInput(string inputFilePath) {
            if (string.IsNullOrWhiteSpace(inputFilePath))
                throw new ArgumentException("Filepath mag niet leeg zijn.", nameof(inputFilePath));

            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException("Bestand bestaat niet.", inputFilePath);

            //skip lines that are null or whitespace, and parse only valid integers
            return File.ReadAllLines(inputFilePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line =>
                    int.TryParse(line, out var value)
                        ? (int?)value
                        : null)
                .Where(v => v.HasValue)
                .Select(v => v!.Value)
                .ToList();
        }

        public static int CountMeasurementIncreases(List<int> measurements) {
            int count = 0;
            for (int i = 1; i < measurements.Count; i++) {
                if (measurements[i] > measurements[i - 1]) {
                    count++;
                }
            }
            return count;
        }

        public static int CountMeasurementWindowIncreases(List<int> measurements, int windowSize) {
            //not enough data
            if (measurements.Count < windowSize + 1) return 0;

            int count = 0;

            for (int i = 0; i <= measurements.Count - windowSize - 1; i++) {
                int window1Sum = 0;
                int window2Sum = 0;
                for (int j = 0; j < windowSize; j++) {
                    window1Sum += measurements[i + j];
                    window2Sum += measurements[i + j + 1];
                }
                if (window2Sum > window1Sum) {
                    count++;
                }
            }

            return count;
        }
    }
}
