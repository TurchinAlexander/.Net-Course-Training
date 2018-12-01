using System;
using Ninject;

using XmlParser.FileLoader;
using XmlParser.FileStorage;
using XmlParser.Parser;

namespace XmlParser
{
    public class ParserService<T, U>
    {
        private IFileLoader<T> fileLoader;
        private IFileStorage<U> fileStorage;
        private IParser<T, U> parser;

        public ParserService(
            IFileLoader<T> fileLoader, 
            IFileStorage<U> fileStorage, 
            IParser<T, U> parser) 
        {
            this.fileLoader = fileLoader ?? throw new ArgumentNullException(nameof(fileLoader));
            this.fileStorage = fileStorage ?? throw new ArgumentNullException(nameof(fileStorage));
            this.parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public void Parse()
        {
            var input = fileLoader.GetAllStrings();
            var result = parser.Parse(input);
            fileStorage.Store(result);
        }
    }
}
