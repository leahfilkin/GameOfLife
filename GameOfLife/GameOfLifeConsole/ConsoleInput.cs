using System;
using System.Collections.Generic;

namespace GameOfLife.GameOfLifeConsole
{
    public class ConsoleInput : IInput
    {
        public List<string> GetInput()
        {
            Console.WriteLine("Please enter your grid. Enter D (for Done) on a new line to finish:");
            string line;
            var input = new List<string>();
            while ((line = Console.ReadLine()) != null && line != "" && line.ToUpper() != "F") 
            {
                input.Add(line);
            }
            return input;
        }
    }
}