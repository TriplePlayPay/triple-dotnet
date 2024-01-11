    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using Triple.Interfaces;

    namespace Triple.Entities.BankAccounts
    {
        public class BankAccount : TripleEntity<BankAccount>, IHasId, IHasStatus
        {
            /// <summary>
            /// The identifier of the account just passed in.
            /// </summary>
            [JsonPropertyName("id")]
            public string Id { get; set; }

            /// <summary>
            /// The status of the web request provided.
            /// </summary>
            [JsonPropertyName("status")]
            public bool Status { get; set; }

            /// <summary>
            /// The result of the tokenized account.
            /// </summary>
            [JsonPropertyName("message")]
            public string Token { get; set; }

            /// <summary>
            /// The request method which has been called.
            /// </summary>
            [JsonPropertyName("method")]
            public string Method { get; set; }

            /// <summary>
            /// (Optional) A valid email address representing a customer.
            /// </summary>
            [JsonPropertyName("email")]
            public string? Email { get; set; }
        }
    }
}
