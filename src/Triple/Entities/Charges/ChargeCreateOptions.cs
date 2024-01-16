using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Triple.Infrastructure;

namespace Triple.Entities.Charges
{
    public class ChargeCreateOptions : BaseOptions
    {
        /// <summary>
        /// Amount intended to be collected by this payment.
        /// </summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Eight to twelve digit account number for the 
        /// bank account being used.
        /// </summary>
        [JsonPropertyName("account_number")]
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Nine digit routing number for the 
        /// bank account being used.
        /// </summary>
        [JsonPropertyName("routing_number")]
        public string? RoutingNumber { get; set; }

        /// <summary>
        /// The number of the credit card to be charged.
        /// </summary>
        [JsonPropertyName("cc")]
        public string? CreditCardNumber { get; set; }

        /// <summary>
        /// This is a unique code printed on cards to authorize payments.
        /// </summary>
        [JsonPropertyName("cvv")]
        public string? CardVerificationValue { get; set; }

        /// <summary>
        /// A two-digit month value for the expiration of the card.
        /// </summary>
        [JsonPropertyName("mm")]
        public string? ExpirationMonth { get; set; }

        /// <summary>
        /// A two-digit month value for the expiration of the card.
        /// </summary>
        [JsonPropertyName("yy")]
        public string? ExpirationYear { get; set; }

        /// <summary>
        /// (Optional) A valid email address representing a customer.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// (Optional) A valid postal code representing a customer location.
        /// </summary>
        [JsonPropertyName("zip")]
        public string? ZipCode { get; set; }

        /// <summary>
        /// (Optional) Value representing origination source of the customer.
        /// </summary>
        [JsonPropertyName("source")]
        public string? Source { get; set; }

        /// <summary>
        /// (Optional) A Triple Play Pay issued token which can be used to purchase. 
        /// </summary>
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
