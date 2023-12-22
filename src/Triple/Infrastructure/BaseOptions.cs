using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Triple.Interfaces;

namespace Triple.Infrastructure
{
    /// <summary>
    /// Base class for Triple options classes, i.e. classes representing parameters for Triple
    /// API requests.
    /// </summary>
    public class BaseOptions : INestedOptions
    {
        /// <summary>Specifies which fields in the response should be expanded.</summary>
        [JsonPropertyName("expand")]
        public List<string> Expand { get; set; }

        /// <summary>Dictionary containing extra request parameters.</summary>
        [JsonExtensionData]
        public IDictionary<string, object> ExtraParams { get; set; }
            = new Dictionary<string, object>();

        /// <summary>
        /// Adds an <c>expand</c> value to the request, to request expansion of a specific
        /// field in the response. When requesting expansions in a list request, don't forget
        /// to prefix the field names with <c>data.</c>.
        /// </summary>
        /// <param name="value">The name of the field to expand.</param>
        public void AddExpand(string value)
        {
            if (this.Expand == null)
            {
                this.Expand = new List<string>();
            }

            this.Expand.Add(value);
        }

        /// <summary>
        /// Adds a collection of <c>expand</c> values to the request, to request expansion of
        /// specific fields in the response. When requesting expansions in a list request, don't
        /// forget to prefix the field names with <c>data.</c>.
        /// </summary>
        /// <param name="values">The collection of names of the fields to expand.</param>
        public void AddRangeExpand(IEnumerable<string> values)
        {
            if (this.Expand == null)
            {
                this.Expand = new List<string>();
            }

            this.Expand.AddRange(values);
        }

        /// <summary>
        /// Adds an extra parameter to the request. This can be useful if you need to use
        /// parameters not available in regular options classes, e.g. for beta features.
        /// </summary>
        /// <param name="key">The parameter's key.</param>
        /// <param name="value">The parameter's value.</param>
        public void AddExtraParam(string key, object value)
        {
            this.ExtraParams.Add(key, value);
        }
    }
}
