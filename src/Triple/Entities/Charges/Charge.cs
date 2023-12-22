using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace Triple.Entities.Charges
{
    /// <summary>
    /// The <c>Charge</c> object represents a single attempt to move money into your Triple account.
    /// </summary>
    public class Charge : TripleEntity<Charge>, IHasId, IHasStatus
    {
        /// <summary>
        /// Unique identifier for the object.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Status determining whether or not the payment was successfully processed.
        /// </summary>
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        /// <summary>
        /// String highlighting the payment method which was utilized to successfully process.
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; }

        /// <summary>
        /// Interally focused `ChargeMessage` entity returning additional attributes 
        /// on the transaction which has just been processed.
        /// </summary>
        [JsonPropertyName("message")]
        public ChargeMessage Message { get; set; }
    }
}
