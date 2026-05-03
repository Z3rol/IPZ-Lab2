using System;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            Console.Clear();

            Start();
        }

        static void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                PrintMenu();
                int choice = GetValidInt("Your choice", 0, 2);

                switch (choice)
                {
                    case 1:
                        // Get valid whole number and a fraction from the user
                        (string wholePart, string fraction) = GetValidDecimalBinary("Enter a decimal binary in [binary.binary] format");

                        // Convert both parts into numbers
                        int wholeNumber = ConvertBinaryToInt(wholePart);
                        double fractionNumber = ConvertFractionalBinaryToDouble(fraction);

                        // Add them to get final decimal result
                        double result = wholeNumber + fractionNumber;

                        Console.WriteLine(result);
                    break;

                    case 2:
                        string binary = GetValid8BitBinary("Enter a binary of 8 characters (the first must represent sign)");
                        string directBinary = ConvertDirectToTwosComplement(binary);
                        Console.WriteLine(directBinary);
                    break;

                    case 0:
                        isRunning = false;
                    break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine(" Task 1. Convert entered decimal binary to number");
            Console.WriteLine(" Task 2. Convert binary code to two's component");
            Console.WriteLine(" 0. Close the program");
        }



        static int ConvertBinaryToInt(string binary)
        {
            int result = 0;
            int multiplier = 1;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                    result += multiplier;

                multiplier *= 2;
            }

            return result;
        }

        static double ConvertFractionalBinaryToDouble(string binary)
        {
            double result = 0;
            double multiplier = 0.5;

            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                    result += multiplier;

                multiplier /= 2;
            }

            return result;
        }

        static string ConvertDirectToTwosComplement(string binary)
        {
            char[] chars = new char[binary.Length];
            chars[0] = binary[0];

            bool oneIsFound = false;
            for (int i = binary.Length - 1; i > 0; i--)
            {
                if (oneIsFound)
                {
                    if (binary[i] == '1')
                        chars[i] = '0';
                    else
                        chars[i] = '1';
                }
                else
                {
                    chars[i] = binary[i];

                    if (binary[i] == '1')
                        oneIsFound = true;
                }
            }

            return new string(chars);
        }
        



        // Prompts user until they enter a valid fraction binary
        // Return the part before dot and after it
        static (string leftSide, string rightSide) GetValidDecimalBinary(string message)
        {
            while (true)
            {
                Console.Write($"{message}: ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (input == "")
                {
                    Console.WriteLine("Invalid input. Please try again");
                    continue;
                }

                // Normalize and split to get the whole part and a fraction
                string normalizedInput = input.Replace(',', '.');
                string[] parts = normalizedInput.Split('.');

                // Handle case with 2 or more dots entered
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid format, please use \"binary.binary\" format");
                    continue;
                }

                // Handle any incorrect binary input
                if (!IsBinaryValid(parts[0]) || !IsBinaryValid(parts[1]))
                {
                    Console.WriteLine("Invalid input. Please enter a valid binary");
                    continue;
                }

                // If no errors found, return both parts
                return (parts[0], parts[1]);
            }
        }

        static string GetValid8BitBinary(string message)
        {
            while (true)
            {
                Console.Write($"{message}: ");
                string input = Console.ReadLine()?.Trim() ?? "";

                if (input == "")
                {
                    Console.WriteLine("Invalid input. Please try again");
                    continue;
                }
                else if (!IsBinaryValid(input))
                {
                    Console.WriteLine("Invalid input. Please enter a valid binary");
                    continue;
                }
                else if (input.Length != 8)
                {
                    Console.WriteLine("Invalid length. Please enter 8 bit binary");
                    continue;
                }

                return input;
            }
        }

        

        // Check if a string contains only valid base-2 characters
        static bool IsBinaryValid(string bin)
        {
            if (bin.Length == 0)
                return false;

            for (int i = 0; i < bin.Length; i++)
            {
                if (bin[i] != '0' && bin[i] != '1')
                    return false;
            }

            return true;
        }

        static int GetValidInt(string message, int min, int max)
        {
            while (true)
            {
                Console.Write($"{message}: ");

                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number");
                    continue;
                }

                if (num < min || num > max)
                {
                    Console.WriteLine($"{num} is out of range. Please enter a number in range ({min}-{max})");
                    continue;
                }

                return num;
            }
        }
    }
}