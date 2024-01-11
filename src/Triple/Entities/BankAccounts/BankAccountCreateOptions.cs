using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Triple.Infrastructure;

namespace Triple.Entities.BankAccounts
{
    public class BankAccountCreateOptions : BaseOptions
    {
        /// <summary>
        /// The routing number to the financial institution.
        /// </summary>
        [JsonPropertyName("routing_number")]
        public string RoutingNumber { get; set; }

        /// <summary>
        /// The account number to the financial institution.
        /// </summary>
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// (Optional) A valid email address representing a customer.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}
