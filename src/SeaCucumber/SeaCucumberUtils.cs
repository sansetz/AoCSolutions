namespace SeaCucumber {
    public static class SeaCucumberUtils {

        public static string[] ReadInput(string inputFilePath) {
            if (string.IsNullOrWhiteSpace(inputFilePath))
                throw new ArgumentException("Filepath mag niet leeg zijn.", nameof(inputFilePath));

            if (!File.Exists(inputFilePath))
                throw new FileNotFoundException("Bestand bestaat niet.", inputFilePath);

            return File.ReadAllLines(inputFilePath);
        }

        public static char[,] ConvertToCharMapForProcessing(string[] inputData) {
            int maxrow = inputData.Length;
            int maxcol = inputData[0].Length;

            char[,] charMap = new char[maxrow, maxcol];
            for (int row = 0; row < maxrow; row++)
                for (int col = 0; col < maxcol; col++)
                    charMap[row, col] = inputData[row][col];

            return charMap;
        }

        public static int MoveCucumbers(string[] inputData, bool printStepMaps) {
            int countSteps = 0;
            bool canMove = true;
            bool movedEast = false;
            bool movedSouth = false;

            if (inputData.Length == 0)
                return 0;

            char[,] seaCucumberMap = ConvertToCharMapForProcessing(inputData);

            if (printStepMaps)
                PrintSeaCucumberMap(countSteps, seaCucumberMap);
            while (canMove) {
                countSteps++;
                movedEast = MoveCucumbersEast(ref seaCucumberMap);
                movedSouth = MoveCucumbersSouth(ref seaCucumberMap);
                canMove = movedEast || movedSouth;
            }
            if (printStepMaps)
                PrintSeaCucumberMap(countSteps, seaCucumberMap);

            return countSteps;
        }


        private static bool MoveCucumbersEast(ref char[,] seaCucumberMap) {
            bool hasMoved = false;
            int maxrow = seaCucumberMap.GetLength(0);
            int maxcol = seaCucumberMap.GetLength(1);

            char[,] mapToUpdate = (char[,])seaCucumberMap.Clone();

            for (int row = 0; row < maxrow; row++) {

                for (int col = 0; col < maxcol; col++) {
                    //iterate over columns within each row

                    if (col < maxcol - 1) {
                        //not last character in row
                        if (seaCucumberMap[row, col] == '>' && seaCucumberMap[row, col + 1] == '.') {
                            mapToUpdate[row, col] = '.';
                            mapToUpdate[row, col + 1] = '>';
                            hasMoved = true;
                        }
                    }
                    else {
                        //last character in row
                        if (seaCucumberMap[row, col] == '>' && seaCucumberMap[row, 0] == '.') {
                            mapToUpdate[row, col] = '.';
                            mapToUpdate[row, 0] = '>';
                            hasMoved = true;
                        }
                    }
                }
            }
            seaCucumberMap = mapToUpdate;
            return hasMoved;
        }

        private static bool MoveCucumbersSouth(ref char[,] seaCucumberMap) {
            bool hasMoved = false;
            int maxrow = seaCucumberMap.GetLength(0);
            int maxcol = seaCucumberMap.GetLength(1);

            char[,] mapToUpdate = (char[,])seaCucumberMap.Clone();

            for (int col = 0; col < maxcol; col++) {
                for (int row = 0; row < maxrow; row++) {
                    //iterate over columns within each row

                    if (row < maxrow - 1) {
                        //not last character in row
                        if (seaCucumberMap[row, col] == 'v' && seaCucumberMap[row + 1, col] == '.') {
                            mapToUpdate[row, col] = '.';
                            mapToUpdate[row + 1, col] = 'v';
                            hasMoved = true;
                        }
                    }
                    else {
                        //last character in row
                        if (seaCucumberMap[row, col] == 'v' && seaCucumberMap[0, col] == '.') {
                            mapToUpdate[row, col] = '.';
                            mapToUpdate[0, col] = 'v';
                            hasMoved = true;
                        }
                    }
                }

            }
            seaCucumberMap = mapToUpdate;
            return hasMoved;

        }

        private static void PrintSeaCucumberMap(int stepnr, char[,] map) {
            Console.WriteLine($"Map after {stepnr} step{(stepnr == 1 ? "" : "s")}:\n");

            for (int row = 0; row < map.GetLength(0); row++) {
                for (int col = 0; col < map.GetLength(1); col++) {
                    Console.Write(map[row, col]);
                }
                Console.WriteLine(); // nieuwe regel aan het eind van de rij
            }

            Console.WriteLine(); // extra witregel na de hele map, voor leesbaarheid
        }
    }
}
