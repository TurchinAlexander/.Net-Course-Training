using System;
using System.Collections.Generic;
using XmlParser.Validator;

namespace XmlParser.Parser
{
    public  class StringUriParser : IParser<string, Uri>
    {
        private IValidator<string> validator;

        public StringUriParser(IValidator<string> validator)
        {
            this.validator = validator;
        }

        public IEnumerable<Uri> Parse(IEnumerable<string> values)
        {
            foreach (var element in values)
            {
                if (validator.Validate(element))
                {
                    yield return new Uri(element);
                }
            }
        }
    }
}
