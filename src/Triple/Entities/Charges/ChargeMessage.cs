using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Triple.Interfaces;

namespace Triple.Entities.Charges
{
    /// <summary>
    /// The <c>ChargeMessage</c> object represents nested 
    /// object highlighting transactional details of a charge.
    /// </summary>
    public class ChargeMessage : IHasMeta
    {
        /// <summary>
        /// Decimal string representing the amount processed.
        /// </summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }


        /// <summary>
        /// IP Address from the request
        /// </summary>
        [JsonPropertyName("status")]
        public string? status { get; set; }

        /// <summary>
        /// IP Address from the request
        /// </summary>
        [JsonPropertyName("ip")]
        public string? Ip { get; set; }

        /// <summary>
        /// Identifier of the transactions. 
        /// Good to keep for reporting purposes.
        /// </summary>
        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }

        /// <summary>
        /// Decimal string representing the fee that will be owed
        /// back to the facilitator. Note this is not added into the
        /// `amount` value.
        /// </summary>
        [JsonPropertyName("fee")]
        public string? Fee { get; set; }

        /// <summary>
        /// Decimal string representing the tip that will be owed
        /// back to the merchant. Note this is added into the `amount`.
        /// </summary>
        [JsonPropertyName("tip")]
        public string? Tip { get; set; }

        /// <summary>
        /// Represents a digitially signed payment token which can be used.
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// This is a custom message set to provide additional context
        /// of the transaction which was processed.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        
        /// <summary>
        /// This represents additional information returned
        /// directly back from the end processor.
        /// </summary>
        [JsonPropertyName("details")]
        public dynamic? Details { get; set; }

        /// <summary>
        /// This is a List containing object values
        /// which represent a receipt within the system.
        /// </summary>
        [JsonPropertyName("receipt")]
        public List<dynamic>? Receipt { get; set; }

        /// <summary>
        /// Set of key-value pairs that can be attached to an object.
        /// </summary>
        [JsonPropertyName("meta")]
        public dynamic? Meta { get; set; }
    }
}
