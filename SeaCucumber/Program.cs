//solution to puzzle listed on https://adventofcode.com/2021/day/25

//original data from puzzle
string[] seaCucumberData = new string[]
{
    "v...>>.vv>",
    ".vv>>.vv..",
    ">>.>v>...v",
    ">>v>>.>.v.",
    "v>v.vv.v..",
    ">.>>..v...",
    ".vv..>.>v.",
    "v.v..>>v.v",
    "....v..v.>"
};

//convert data into 2D char array for easier processing
int _maxrow = seaCucumberData.Length;
int _maxcol = seaCucumberData[0].Length;

char[,] seaCucumberMap = new char[_maxrow, _maxcol];
for (int row = 0; row < _maxrow; row++)
    for (int col = 0; col < _maxcol; col++)
        seaCucumberMap[row, col] = seaCucumberData[row][col];


int countSteps = 0;
bool canMove = true;
bool movedEast = false;
bool movedSouth = false;
PrintSeaCucumberMap(countSteps, seaCucumberMap);
while (canMove) {
    countSteps++;
    movedEast = MoveCucumbersEast(ref seaCucumberMap);
    movedSouth = MoveCucumbersSouth(ref seaCucumberMap);
    canMove = movedEast || movedSouth;
}
Console.WriteLine($"Sea cucumbers stop moving after {countSteps} steps.");
PrintSeaCucumberMap(countSteps, seaCucumberMap);


bool MoveCucumbersEast(ref char[,] seaCucumberMap) {
    bool hasMoved = false;

    char[,] mapToUpdate = (char[,])seaCucumberMap.Clone();

    //move cucumbers east
    for (int row = 0; row < _maxrow; row++) {

        for (int col = 0; col < _maxcol; col++) {
            //iterate over columns within each row

            if (col < _maxcol - 1) {
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

bool MoveCucumbersSouth(ref char[,] seaCucumberMap) {
    bool hasMoved = false;

    char[,] mapToUpdate = (char[,])seaCucumberMap.Clone();

    for (int col = 0; col < _maxcol; col++) {
        for (int row = 0; row < _maxrow; row++) {
            //iterate over columns within each row

            if (row < _maxrow - 1) {
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

void PrintSeaCucumberMap(int stepnr, char[,] map) {
    Console.WriteLine($"Map after {stepnr} step{(stepnr == 1 ? "" : "s")}:\n");

    for (int row = 0; row < _maxrow; row++) {
        for (int col = 0; col < _maxcol; col++) {
            Console.Write(map[row, col]);
        }
        Console.WriteLine(); // nieuwe regel aan het eind van de rij
    }

    Console.WriteLine(); // extra witregel na de hele map, voor leesbaarheid
}