using System;
using SolarFarm.Core.Interfaces;
using SolarFarm.Core.DTO;

namespace SolarFarm.UI
{
    class ConsoleIO
    {
        public int GetInt(string prompt)
        {
            int result = -1;
            bool valid = false;
            while (!valid)
            {
                Console.Write($"{prompt}: ");
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Error("Please input a proper integer\n\n");
                }
                else
                {
                    valid = true;
                }
            }
            return result;
        }
        
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
        
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Display("Main Menu");
            Display("=========");
            Display("0. Exit");
            Display("1. Find Panels by Section");
            Display("2. Add a Panel");
            Display("3. Update a Panel");
            Display("4. Remove a Panel");
            Display("Select [0-4]");
        }

        public DateTime ValiDATE(string input)
        {
            bool isValid = DateTime.TryParse(input, out DateTime date);
            while (!isValid)
            {
                Console.WriteLine("Not a valid date format, please try again");
                isValid = DateTime.TryParse(Console.ReadLine(), out date);
            }
            return date;
        }

        public int ValidInt(string input)
        {
            bool isValid = Int32.TryParse(input, out int output);
            while (!isValid)
            {
                Console.WriteLine("Not a valid integer, please try again");
                isValid = Int32.TryParse(Console.ReadLine(), out output);
            }
            return output;
        }
    }
}
