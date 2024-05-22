using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Triple.Interfaces;

namespace Triple.Entities.RecurringCharges
{
    /// <summary>
    /// The <c>RecurringChargeMessage</c> object represents nested 
    /// object highlighting transactional details of a recurring charge.
    /// </summary>
    public class RecurringChargeMessage : IHasMeta
    {
        /// <summary>
        /// Decimal string representing the amount processed.
        /// </summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Date value in YYYY-MM-DD value representing the
        /// next date the customer will be charged.
        /// </summary>
        [JsonPropertyName("next")]
        public string Next { get; set; }

        /// <summary>
        /// String which describes the interval at which customers
        /// will be charged. ie: `monthly`
        /// </summary>
        [JsonPropertyName("interval")]
        public string Interval { get; set; }

        /// <summary>
        /// Date value in YYYY-MM-DD value representing the
        /// end date the customer will be charged.
        /// </summary>
        [JsonPropertyName("end")]
        public string End { get; set; }

        /// <summary>
        /// Describes the frequency of the charge.
        /// </summary>
        [JsonPropertyName("frequency")]
        public object Frequency { get; set; }

        /// <summary>
        /// Set of key-value pairs that can be attached to an object.
        /// </summary>
        [JsonPropertyName("meta")]
        public dynamic? Meta { get; set; }
    }
}
