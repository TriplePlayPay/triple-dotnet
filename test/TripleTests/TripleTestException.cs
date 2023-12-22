using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTests
{

    /// <summary>
    /// Represents errors that are related to tests themselves rather than the
    /// features under test.
    /// </summary>
    public class TripleTestException : Exception
    {
        public TripleTestException()
        {
        }

        public TripleTestException(string message)
            : base(message)
        {
        }
    }
}
