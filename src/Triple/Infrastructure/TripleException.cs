using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Triple.Infrastructure
{
    public class TripleException : Exception
    {
        public TripleException()
        {
        }

        public TripleException(string message)
            : base(message)
        {
        }

        public TripleException(string message, Exception err)
            : base(message, err)
        {
        }

        public TripleException(HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public TripleResponse TripleResponse { get; set; }
    }
}
