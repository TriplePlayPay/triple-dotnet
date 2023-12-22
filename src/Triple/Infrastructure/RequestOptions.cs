using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triple.Infrastructure
{
    public class RequestOptions
    {
        /// <summary>
        /// Gets or sets the API
        /// key</a> to use for the request.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>Gets or sets the base URL for the request.</summary>
        /// <remarks>
        /// This is an internal property. It is set by services or individual request methods.
        /// </remarks>
        internal string BaseUrl { get; set; }
    }
}
