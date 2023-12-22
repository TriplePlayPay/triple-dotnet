using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Triple.Entities.Charges;
using Triple.Interfaces;

namespace Triple.Entities.RecurringCharges
{
    /// <summary>
    /// The <c>Recurring</c> object represents a single attempt to move money into your Triple account,
    /// for a charge that will take place on an ongoing basis.
    /// </summary>
    public class RecurringCharge : TripleEntity<RecurringCharge>, IHasId, IHasStatus
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
        /// Interally focused `RecurringChargeMessage` entity returning
        /// additional attributes on the transaction which has just been processed.
        /// </summary>
        [JsonPropertyName("message")]
        public RecurringChargeMessage Message { get; set; }
    }
}
