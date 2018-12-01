using System;
using Ninject.Modules;

using XmlParser;
using XmlParser.FileLoader;
using XmlParser.FileStorage;
using XmlParser.Logger;
using XmlParser.Parser;
using XmlParser.Validator;

namespace Console
{
    public class ConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileLoader<string>>().To<FileLoaderEntity>().WithConstructorArgument("source.txt");
            Bind<IFileStorage<Uri>>().To<FileStorageEntity>().WithConstructorArgument("result.txt");
            Bind<ILogger>().To<NLogger>();
            Bind<IParser<string, Uri>>().To<StringUriParser>();
            Bind<IValidator<string>>().To<ValidatorEntity>();
            Bind<ParserService<string, Uri>>().ToSelf();
        }
    }
}
