/*
    Programming Aptitude Test (C#) - Problem A
    - Passed .NET Core 3.1
    - Passed .NET 4.7.2
    - Passed Roslyn 3.4
    Author: Josef Gabrielsson
    Version: 1.0.0
    Github: https://github.com/aramean
*/
using System;
using System.Diagnostics;

namespace ProblemA
{
    public class Program
    {
        public static void Main()
        {
            string line;

            while ((line = Console.ReadLine()) != null)
            {
                decimal inputTotalMinutes = 0, inputTotalSeconds = 0;
                ushort observations = 0;

                try
                {
                    observations = ushort.Parse(line); // long.TryParse(line, out Int64 observations);
                    Debug.WriteLine("Total observations " + observations);
                }
                catch { }

                for (int i = 1; i <= observations; i++) // Iterate until total observations reached
                {
                    try // Handle errors
                    {
                        string inputs = Console.ReadLine(); // Read inputs M and S
                        string[] split = inputs.Split(new char[] { ' ' }, StringSplitOptions.None); // Split M and S
                        long inputMinutes = Int64.Parse(split[0]), inputSeconds = Int64.Parse(split[1]); // Parse M and S

                        inputTotalMinutes += inputMinutes;
                        inputTotalSeconds += inputSeconds;

                        Debug.WriteLine("Total input minutes " + inputTotalMinutes);
                        Debug.WriteLine("Total input seconds " + inputTotalSeconds);
                    }
                    catch
                    {
                        Debug.WriteLine("Input error!");
                    }
                }

                try
                {
                    decimal output = inputTotalSeconds / (inputTotalMinutes * 60);

                    if (output > 1)
                        Console.WriteLine("{0:F9}", output); // Measurement output 10^-7 in decimal form
                    else
                        Console.WriteLine("measurement error");
                }
                catch { } // DivideByZeroException
            }
        }
    }
}