namespace AoCUtils {
    public static class AoCUtils {
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
        public static string[] ReadInput(string inputFilePath) {
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
    }
}
