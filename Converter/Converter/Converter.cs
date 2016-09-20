using System;
using Converter.Services;

namespace Converter
{
    class Converter
    {
        static void Main(string[] args)
        {
            ConverterService converter = new ConverterService();

            //Infinite loop
            while (true)
            {
                Console.WriteLine("Please input a value:");
                string input = Console.ReadLine();
                Console.WriteLine(converter.OutputMessage(input));
            }
        }
    }
}
