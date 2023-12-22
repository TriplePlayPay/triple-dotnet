using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace Triple.Abstract
{
    /// <summary>
    /// Represents a response from Triple Play Pay's API.
    /// </summary>
    public abstract class TripleResponseBase
    {
        /// <summary>Initializes a new instance of the <see cref="TripleResponseBase"/> class.</summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="headers">The HTTP headers of the response.</param>
        public TripleResponseBase(HttpStatusCode statusCode, HttpResponseHeaders headers)
        {
            this.StatusCode = statusCode;
            this.Headers = headers;
        }

        /// <summary>Gets the HTTP status code of the response.</summary>
        /// <value>The HTTP status code of the response.</value>
        public HttpStatusCode StatusCode { get; }

        /// <summary>Gets the HTTP headers of the response.</summary>
        /// <value>The HTTP headers of the response.</value>
        public HttpResponseHeaders Headers { get; }

        internal int NumRetries { get; set; }

        /// <summary>Returns a string that represents the <see cref="TripleResponse"/>.</summary>
        /// <returns>A string that represents the <see cref="TripleResponse"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "<{0} status={1}}>",
                this.GetType().FullName,
                (int)this.StatusCode);
        }
    }
}
