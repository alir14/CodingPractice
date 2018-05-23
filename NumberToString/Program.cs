using System;
using NumberToStringDataComponent;
using NumberToStringBusinessComponent;
using NumberToStringFramework.Interface;

namespace NumberToString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Console.WriteLine(ConverNumberToString(input));

            Console.ReadKey();
        }

        private static string ConverNumberToString(string number)
        {
            INumbersStringDataComponent data = new NumbersStringDataComponent();

            var converter = new ConvertNumberBusinessComponent(number, data);

            return converter.ConvertNumber();
        }
    }
}
