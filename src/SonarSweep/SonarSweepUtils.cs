namespace SonarSweep {
    public static class SonarSweepUtils {
        public static int CountMeasurementIncreases(List<int> measurements) {
            int count = 0;
            for (int i = 1; i < measurements.Count; i++) {
                if (measurements[i] > measurements[i - 1]) {
                    count++;
                }
            }
            return count;
        }
    }
}
