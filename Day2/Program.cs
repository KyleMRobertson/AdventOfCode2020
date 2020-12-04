using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            int max = 0;
            char testChar = default;
            string password = "";


            string[] puzzleInput = File.ReadAllLines(@"D:\AdventOfCode\DayTwo\PuzzleInput.txt", Encoding.UTF8);

            PartOne(puzzleInput, min, max, testChar, password);
            PartTwo(puzzleInput, min, max, testChar, password);
        }

        static void PartOne(string[] puzzleInput, int min, int max, char testChar, string password)
        {
            int counter = 0;
            for (int i = 0; i < puzzleInput.Length; i++)
            {
                char[] delimiterChars = { ' ', ':', '-', '\t' };

                string[] subStringArray = puzzleInput[i].Split(delimiterChars);

                min = int.Parse(subStringArray[0]);
                max = int.Parse(subStringArray[1]);
                testChar = Convert.ToChar(subStringArray[2]);
                password = subStringArray[4];

                if (password != "")
                {
                    int count = password.Count(f => f == testChar);

                    if (min <= count && count <= max)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine($"Part One has {counter} valid passwords.");
        }
        static void PartTwo(string[] puzzleInput, int min, int max, char testChar, string password)
        {
            int counter = 0;
            bool minTrue = false;
            bool maxTrue = false;

            for (int i = 0; i < puzzleInput.Length; i++)
            {
                char[] delimiterChars = { ' ', ':', '-', '\t' };

                string[] subStringArray = puzzleInput[i].Split(delimiterChars);

                min = int.Parse(subStringArray[0]) - 1;
                max = int.Parse(subStringArray[1]) - 1;
                testChar = Convert.ToChar(subStringArray[2]);
                password = subStringArray[4];

                for (int k = 0; k < password.Length; k++)
                {
                    if (k == min)
                    {
                        if (password[k] == testChar)
                        {
                            minTrue = true;
                        }
                    }
                    else if (k == max)
                    {
                        if (password[k] == testChar)
                        {
                            maxTrue = true;
                            break;
                        }
                    }
                }

                if (minTrue && maxTrue)
                {
                    minTrue = false;
                    maxTrue = false;
                }
                else if (minTrue && !maxTrue || !minTrue && maxTrue)
                {
                    counter++;
                    minTrue = false;
                    maxTrue = false;
                }
            }

            Console.WriteLine($"Part Two has {counter} valid passwords.");
        }
    }
}
