using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] puzzleInput = File.ReadAllLines(@"D:\AdventOfCode\DayFour\PuzzleInput.txt", Encoding.UTF8);
            List<string> passports = GeneratePassports(puzzleInput);

            PartOne(passports);
            PartTwo(passports);
        }

        private static List<string> GeneratePassports(string[] puzzleInput)
        {
            List<string> passports = new List<string>();
            string passportContent = "";

            foreach (string data in puzzleInput)
            {
                if (data == "")
                {
                    passportContent.Trim();
                    passports.Add(passportContent);
                    passportContent = "";
                    continue;
                }

                passportContent = passportContent + " " + data;
                //Console.WriteLine(passportContent);
            }

            passports.Add(passportContent);
            return passports.Where(x => x.Split(" ").Length > 7).Select(x => x).ToList();
        }

        static void PartOne(List<string> passports)
        {
            int counter = 0;

            foreach (string passport in passports)
            {
                if (PartOneValidator(passport))
                {
                    counter++;
                }
            }

            Console.WriteLine($"Part One: There are {counter} valid passports.");
        }

        private static bool PartOneValidator(string passport)
        {
            List<string> keys = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };         //cid is not needed.

            foreach (string content in keys)
            {
                if (!passport.Contains(content))
                {
                    return false;
                }
            }

            return true;
        }

        static void PartTwo(List<string> passports)
        {
            int counter = 0;

            foreach (string passport in passports)
            {
                if (PartTwoValidator(passport))
                {
                    counter++;
                }
            }

            Console.WriteLine($"Part Two: There are {counter} valid passports.");
        }

        private static bool PartTwoValidator(string passport)
        {
            List<string> data = new List<string>() {@"byr(19[2-9][0-9]|200[0-2])",                              // four digits; at least 1920 and at most 2002.
                                                    @"iyr(201[0-9]|2020)",                                      // four digits; at least 2010 and at most 2020.
                                                    @"eyr(202[0-9]|2030)",                                      // four digits; at least 2020 and at most 2030.
                                                    @"hgt((1[5-8][0-9]|19[0-3])cm)|hgt(59|6[0-9]|7[0-6])in",    // If cm, the number must be at least 150 and at most 193. If in, the number must be at least 59 and at most 76.
                                                    @"hcl(#[0-9a-f]{6})",                                       // a # followed by exactly six characters 0-9 or a-f.
                                                    @"ecl(amb|blu|brn|gry|grn|hzl|oth)",                        // exactly one of: amb, blu, brn, gry, grn, hzl, or oth.
                                                    @"pid(\d{9}\b)"};                                           // a nine-digit number, including leading zeroes.
                                                    // @"cid(¯\_( ツ )_/¯)"                                     // ignored, missing or not.

            foreach (string regex in data)
            {
                MatchCollection matches = Regex.Matches(passport, regex);

                if (matches.Count == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
