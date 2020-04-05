/*
    Programming Aptitude Test (C#) - Problem B
    - Passed .NET Core 3.1
    - Passed .NET 4.7.2
    - Passed Roslyn 3.4
    Author: Josef Gabrielsson
    Version: 1.0.0
    Github: https://github.com/aramean
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProblemB
{
    public class Program
    {

        // Parameterized Constructor in Struct
        public struct Family
        {
            public string Child;
            public string Parent1;
            public string Parent2;

            public Family(string child, string parent1, string parent2)
            {
                this.Child = child;
                this.Parent1 = parent1;
                this.Parent2 = parent2;
            }
        }

        public struct Claimant
        {
            public string Name { get; internal set; }
        }

        // Keep in memory
        private static string founder;
        private static Dictionary<string, Family> families = new Dictionary<string, Family>();
        private static List<Claimant> claimants = new List<Claimant>();
        private static readonly Dictionary<string, float> royals = new Dictionary<string, float>();

        public static void Main()
        {
            string line;

            Byte maxFamily = 0; // 0 to 255
            Byte maxClaims = 0; // 0 to 255

            while ((line = Console.ReadLine()) != null)
            {
                try
                {
                    string[] split = line.Split(new char[] { ' ' }, StringSplitOptions.None); // Split total Family lines and total Claims

                    maxFamily = Byte.Parse(split[0]);
                    maxClaims = Byte.Parse(split[1]);
                }
                catch { }

                try
                {
                    founder = Console.ReadLine();
                }
                catch { }

                Debug.WriteLine("Founder: " + founder);
                Debug.WriteLine("Total family relation lines: {0}", maxFamily);
                Debug.WriteLine("Total claims to the thrown: {0}", maxClaims);
                Debug.WriteLine("Total input lines: {0}", (maxFamily + maxClaims));

                for (int i = 1; i <= (maxFamily); i++) // Iterate until reached
                {
                    try // Handle errors
                    {
                        string inputs = Console.ReadLine(); // Read inputs from line
                        string[] split = inputs.Split(new char[] { ' ' }, StringSplitOptions.None); // Split Child, Parent 1, Parent 2
                        string inputChild = split[0], inputParent1 = split[1], inputParent2 = split[2]; // Parse Child, Parent 1, Parent 2

                        Debug.WriteLine("Input {0} => child: {1}, parent1: {2}, parent2: {3}", i, inputChild, inputParent1, inputParent2);

                        if (!families.ContainsKey(inputChild)) // Do this magic instead of iterating, block duplicates
                        {
                            families.Add(inputChild, new Family { Child = inputChild, Parent1 = inputParent1, Parent2 = inputParent2 }); // Add to the collection
                        }

                    }
                    catch
                    {
                        Debug.WriteLine("Input error! Need (Child Parent1 Parent2)");
                    }
                }

                for (int i = 1; i <= (maxClaims); i++) // Iterate until reached
                {
                    try // Handle errors
                    {
                        string inputClaimant = Console.ReadLine(); // Read input from line

                        Debug.Write("Claimant: " + inputClaimant + ", ");

                        if (!claimants.Exists(x => x.Name == inputClaimant)) // Do this magic instead of iterating, block duplicates
                            claimants.Add(new Claimant { Name = inputClaimant });
                    }
                    catch
                    {
                        Debug.WriteLine("Input error! Claimant error =)");
                    }
                }

                try // Do the magic output =)
                {

                    //Reverse the elements of dictionary.
                    //families = families.Reverse().ToDictionary(x => x.Key, x => x.Value);

                    /*Console.WriteLine("\n\n");
                    foreach (var family in families)
                    {
                        Console.WriteLine("{0} {1} {2}", family.Value.Child, family.Value.Parent1, family.Value.Parent2);
                    }

                    Console.WriteLine("\n\n");
                    */

                    foreach (var claimant in claimants)
                    {
                        Debug.WriteLine("Claimant check: " + claimant.Name);

                        if (families.ContainsKey(claimant.Name)) // Add only if person is in the lineage
                        {
                            float blood = GetAmountBlood(claimant.Name);
                            royals.Add(claimant.Name, blood); // Get Amount of Blood and add to Royal list
                        }
                    }

                    foreach (var royal in royals)
                    {
                        Debug.WriteLine("{0}:{1}", royal.Key, royal.Value);
                    }

                    Console.WriteLine(GetRightfulHeir());

                }
                catch { }

                royals.Clear();
                families.Clear();
                claimants.Clear();
            }

        }

        private static string GetRightfulHeir()
        {
            var heir = royals.FirstOrDefault(x => x.Value.Equals(royals.Values.Max()));
            return heir.Key;
        }

        private static float GetAmountBlood(string name)
        {
            float amountBlood = 0;
            int childParents = 0;
            int lineage = families.Count();

            foreach (var family in families)
            {
                if (family.Value.Child.Contains(name) | family.Value.Parent1.Contains(name) || family.Value.Parent2.Contains(name))
                {
                    childParents++;
                    foreach (var notroyal in families)
                    {
                        if (family.Value.Parent1.Contains(notroyal.Value.Child))
                            amountBlood += .25f;
                    }
                }
            }

            for (int i = 0; i < (lineage - childParents); i++)
            {
                amountBlood += .5f;
            }

            //Console.WriteLine("{0} {1}", name, (lineage - childParents));

            return amountBlood;
        }
    }
}