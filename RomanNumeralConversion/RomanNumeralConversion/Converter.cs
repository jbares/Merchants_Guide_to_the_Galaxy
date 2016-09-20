using System;
using RomanNumeralConversion.Services;

namespace RomanNumeralConversion
{
    class Converter
    {
        static void Main(string[] args)
        {
            ConverterService converter = new ConverterService();

            while (true)
            {
                Console.WriteLine("Please input a value:");
                string input = Console.ReadLine();
                Console.WriteLine(converter.OutputMessage(input));
            }
        }        
    }
}
