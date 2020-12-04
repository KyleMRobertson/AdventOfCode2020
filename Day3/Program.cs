using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DayThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("D:\\AdventOfCode\\DayThree\\PuzzleInput.txt").ToList();
            var map = input.Select(x => x.ToCharArray().Select(char.ToString).ToList()).ToList();

            PartOne(map);
            PartTwo(map);
        }

        static void PartOne(List<List<string>> map)
        {
            (int X, int Y) offset = (3, 1);
            int treesHit = TreesHit(map, (offset));

            Console.WriteLine($"In Part One I found {treesHit} trees.");
        }

        static void PartTwo(List<List<string>> map)
        {
            long total = (long)TreesHit(map, (1, 1)) *
                            TreesHit(map, (3, 1)) *
                            TreesHit(map, (5, 1)) *
                            TreesHit(map, (7, 1)) *
                            TreesHit(map, (1, 2));

            Console.WriteLine($"In Part One 2 found {total} trees.");
        }

        static int TreesHit(List<List<string>> map, (int X, int Y) offset)
        {
            int treesHit = 0;
            int currentX = offset.X, currentY = offset.Y;
            while (currentY < map.Count)
            {
                var currentPosition = map[currentY][currentX];
                if (currentPosition == "#")
                {
                    treesHit += 1;
                }
                currentX = (currentX + offset.X) % map[currentY].Count;
                currentY += offset.Y;
            }
            return treesHit;
        }
    }
}
