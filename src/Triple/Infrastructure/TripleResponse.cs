using System.Net;
using System.Net.Http.Headers;
using Triple.Abstract;

namespace Triple.Infrastructure
{
    /// <summary>
    /// Represents a buffered textual response from Triple's API.
    /// </summary>
    public class TripleResponse : TripleResponseBase
    {
        /// <summary>Initializes a new instance of the <see cref="TripleResponse"/> class.</summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="headers">The HTTP headers of the response.</param>
        /// <param name="content">The body of the response.</param>
        public TripleResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string content)
            : base(statusCode, headers)
        {
            Content = content;
        }

        /// <summary>Gets the body of the response.</summary>
        /// <value>The body of the response.</value>
        public string Content { get; }
    }
}
