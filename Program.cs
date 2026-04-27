using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            
        }



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

                string normalizedInput = input.Replace(',', '.');
                string[] parts = normalizedInput.Split('.');

                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid format, please use \"binary.binary\" format");
                    continue;
                }

                if (!IsBinaryValid(parts[0]) || !IsBinaryValid(parts[1]))
                {
                    Console.WriteLine("Invalid input. Please enter a valid binary");
                    continue;
                }

                return (parts[0], parts[1]);
            }
        }

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