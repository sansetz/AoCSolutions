//solution to puzzle listed on https://adventofcode.com/2021/day/25

//original data from puzzle
using SeaCucumber;

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

int result = SeaCucumberUtils.MoveCucumbers(seaCucumberData, false);
Console.WriteLine($"The cucumbers stopped moving after {result} step{(result == 1 ? "" : "s")}:\n");
