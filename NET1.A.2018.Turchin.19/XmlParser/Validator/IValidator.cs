using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.Validator
{
    public interface IValidator<in T>
    {
        bool Validate(T value);
    }
}
