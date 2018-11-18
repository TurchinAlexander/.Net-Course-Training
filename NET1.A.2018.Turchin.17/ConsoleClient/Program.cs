using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
			string source = "SourceText.txt";
			string destinationFileStream = "OutputTextFileStream.txt";
			string destinationMemoryStream = "OutputTextMemoryStream.txt";

			Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destinationFileStream)}");

            Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destinationMemoryStream)}");

            Console.WriteLine(IsContentEquals(source, destinationMemoryStream));

            //etc
        }
    }
}
