using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Triple.Infrastructure;

namespace Triple.Entities.Cards
{
    public class CardCreateOptions : BaseOptions
    {
        /// <summary>
        /// The number of the credit card to be charged.
        /// </summary>
        [JsonPropertyName("cc")]
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// This is a unique code printed on cards to authorize payments.
        /// </summary>
        [JsonPropertyName("cvv")]
        public string CardVerificationValue { get; set; }

        /// <summary>
        /// A two-digit month value for the expiration of the card.
        /// </summary>
        [JsonPropertyName("mm")]
        public string ExpirationMonth { get; set; }

        /// <summary>
        /// A two-digit month value for the expiration of the card.
        /// </summary>
        [JsonPropertyName("yy")]
        public string ExpirationYear { get; set; }

        /// <summary>
        /// (Optional) A valid email address representing a customer.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
