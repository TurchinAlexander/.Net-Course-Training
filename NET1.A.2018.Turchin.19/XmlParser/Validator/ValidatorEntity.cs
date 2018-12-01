using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XmlParser.Logger;

namespace XmlParser.Validator
{
    public  class ValidatorEntity : IValidator<string>
    {
        private ILogger logger;

        public ValidatorEntity(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Validate to URI's format.
        /// </summary>
        /// <param name="uriAddress">The <see cref="string"/> to validate.</param>
        /// <returns><c>true</c>if the validation was success. Otherwise, <c>false</c>.</returns>
        public bool Validate(string uriAddress)
        {
            try
            {
                new Uri(uriAddress);
            }
            catch (UriFormatException)
            {
                logger.LogWarn($"{uriAddress} can't be parsed");

                return false;
            }

            return true;
        }
    }
}
