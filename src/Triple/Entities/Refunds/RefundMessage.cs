using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Triple.Interfaces;

namespace Triple.Entities.Refunds
{
    /// <summary>
    /// The <c>RefundMessage</c> object represents nested 
    /// object highlighting transactional details of a refund.
    /// </summary>
    public class RefundMessage
    {
        /// <summary>
        /// Decimal string representing the amount refunded.
        /// </summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Decimal string representing the fee that will be refunded.
        /// `amount` value.
        /// </summary>
        [JsonPropertyName("fee")]
        public string Fee { get; set; }

        /// <summary>
        /// Decimal string representing the tip that will be refunded.
        /// </summary>
        [JsonPropertyName("tip")]
        public string Tip { get; set; }

        /// <summary>
        /// This is a custom message set to provide additional context
        /// of the transaction which was processed.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// This represents additional information returned
        /// directly back from the end processor.
        /// </summary>
        [JsonPropertyName("details")]
        public object Details { get; set; }

        /// <summary>
        /// This is a List containing object values
        /// which represent a receipt within the system.
        /// </summary>
        [JsonPropertyName("receipt")]
        public List<object> Receipt { get; set; }

        /// <summary>
        /// The original id the refund was called with.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin { get; set; }
    }
}
