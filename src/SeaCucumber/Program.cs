//solution to puzzle listed on https://adventofcode.com/2021/day/25

//original data from puzzle
using SeaCucumber;

string inputFilePath = args.FirstOrDefault() ?? @"./input.txt";

int result = SeaCucumberUtils.MoveCucumbers(SeaCucumberUtils.ReadInput(inputFilePath), false);
Console.WriteLine($"The cucumbers stopped moving after {result} step{(result == 1 ? "" : "s")}:\n");
