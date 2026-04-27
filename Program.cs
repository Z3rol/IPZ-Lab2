using System;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            // Get valid whole number and a fraction from the user
            (string wholePart, string fraction) = GetValidDecimalBinary("Enter a decimal binary in [binary.binary] format");

            // Convert both parts into numbers
            int wholeNumber = ConvertBinaryToInt(wholePart);
            double fractionNumber = ConvertFractionalBinaryToDouble(fraction);

            // Add them to get final decimal result
            double result = wholeNumber + fractionNumber;
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



        // Prompts user until they enter a valid fraction binary
        // Return the part before dot and the part after it
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
    }
}