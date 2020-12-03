using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayOne
{
    //Challenges:
    //          Part One:
    //                      Find the two values that sum to 2020.
    //                      Find the result of multiplying them together.
    //          Part Two:
    //                      Find the three values that sum to 2020.
    //                      Find the result of multiplying them together.

    //Solutions:
    //          Part One:
    //                      Create smaller arrays containing numbers ending in pairs that could result in xxx0.
    //                      Work through these arrays until you find the correct pair.
    //                      Some redundancy exists as some pairs in arrays still won't result in xxx0. e.g. 1524 and 1594 are in the same array but can't ever result in xxx0.
    //                      Still a bit cleaner than brute force.
    //          Part Two:
    //                      Find the three values that sum to 2020.
    //                      Find the result of multiplying them together.

    class Program
    {
        static void Main(string[] args)
        {
            int checkInt = 2020;

            int[] largeArray = File.ReadLines("D:\\AdventOfCode\\DayOne\\DayOne.txt").Select(line => int.Parse(line)).ToArray();

            PartOne(largeArray, checkInt);
            PartTwo(largeArray, checkInt);
        }

        static void PartOne(int[] largeArray, int checkInt)
        {
            Console.WriteLine("Part One:");

            var intList0 = new List<int>(largeArray.Length);
            var intList1 = new List<int>(largeArray.Length);
            var intList2 = new List<int>(largeArray.Length);
            var intList3 = new List<int>(largeArray.Length);
            var intList4 = new List<int>(largeArray.Length);
            var intList5 = new List<int>(largeArray.Length);

            for (int i = 0; i < largeArray.Length; i++)
            {
                int modTest = largeArray[i] % 10;

                if (modTest == 0)
                {
                    intList0.Add(largeArray[i]);
                }
                else if (modTest == 1 || modTest == 9)
                {
                    intList1.Add(largeArray[i]);
                }
                else if (modTest == 2 || modTest == 8)
                {
                    intList2.Add(largeArray[i]);
                }
                else if (modTest == 3 || modTest == 7)
                {
                    intList3.Add(largeArray[i]);
                }
                else if (modTest == 4 || modTest == 6)
                {
                    intList4.Add(largeArray[i]);
                }
                else
                {
                    intList5.Add(largeArray[i]);
                }
            }

            List<List<int>> megaList = new List<List<int>>(6);
            megaList.Add(intList0);
            megaList.Add(intList1);
            megaList.Add(intList2);
            megaList.Add(intList3);
            megaList.Add(intList4);
            megaList.Add(intList5);

            //Do the actual testing.
            for (int i = 0; i < megaList.Count; i++)
            {
                TestSumOne(megaList[i], checkInt);
            }

        }

        static void PartTwo(int[] largeArray, int checkInt)
        {
            //Brute force
            Console.WriteLine("Part Two:");

            int result = 0;
            int secondSum = 0;

            for (int i = 0; i < largeArray.Length; i++)
            {
                for (int j = 0; j < largeArray.Length; j++)
                {
                    int sum = largeArray[i] + largeArray[j];

                    if (sum < checkInt)
                    {
                        for (int k = 0; k < largeArray.Length; k++)
                        {
                            secondSum = sum + largeArray[k];

                            if (secondSum == checkInt)
                            {
                                Console.WriteLine("I have found three values which sum to 2020. They are:");
                                Console.WriteLine(largeArray[i] + ", " + largeArray[j] + ", and " + largeArray[k] + ".");

                                result = largeArray[i] * largeArray[j] * largeArray[k];

                                Console.WriteLine("The result of multiplying them together is:");
                                Console.WriteLine(result + ".");

                                return;
                            }
                        }

                    }
                }
            }
        }

        static void TestSumOne(List<int> array, int checkInt)
        {
            int result = 0;

            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count; j++)
                {
                    int sum = array[i] + array[j];

                    if (sum == checkInt)
                    {
                        Console.WriteLine("I have found two values which sum to 2020. They are:");
                        Console.WriteLine(array[i] + " and " + array[j] + ".");

                        result = array[i] * array[j];

                        Console.WriteLine("The result of multiplying them together is:");
                        Console.WriteLine(result + ".");

                        return;
                    }
                }
            }
        }
    }
}
