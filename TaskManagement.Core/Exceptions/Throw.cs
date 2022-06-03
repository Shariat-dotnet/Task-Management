using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Throw;

namespace TaskManagement.Core.Exceptions
{
    public static class ThrowExtensions
    {
        public static ref readonly Validatable<string> IfFoo(this in Validatable<string> validatable)
        {
            if (string.Equals(validatable.Value, "foo", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("String shouldn't equal 'foo'", validatable.ParamName);
            }

            return ref validatable;
        }
    }
}
