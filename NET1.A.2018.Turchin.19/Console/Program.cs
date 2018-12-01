using System;
using Ninject;

using XmlParser;
using XmlParser.FileLoader;
using XmlParser.FileStorage;
using XmlParser.Logger;
using XmlParser.Parser;
using XmlParser.Validator;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new ConfigurationModule());
            var service = kernel.Get<ParserService<string, Uri>>();

            service.Parse();
        }
    }
}
