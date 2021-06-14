using System;
using McbCodeTest;

namespace simpleUseOfClassLib
{
    class Program
    {
        static void Main(string[] args)
        {
            IMcbDataConverter converter = new MyDataConverter();
            Console.WriteLine(converter.ConvertDataToJson());
            Console.ReadLine();
        }
    }
}
