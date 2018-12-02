using System;
using Ninject.Modules;

using XmlParser.FileLoader;
using XmlParser.FileStorage;
using XmlParser.Logger;
using XmlParser.Parser;
using XmlParser.Validator;
namespace XmlParser
{
    public class ConfigurationModule1 : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileLoader<string>>().To<FileLoaderEntity>();
            Bind<IFileStorage<Uri>>().To<FileStorageEntity>();
            Bind<ILogger>().To<NLogger>();
            Bind<IParser<string, Uri>>().To<StringUriParser>();
            Bind<IValidator<string>>().To<ValidatorEntity>();
            Bind<ParserService<string, Uri>>().ToSelf();
        }
    }
}
