using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Triple.Interfaces;

namespace Triple.Entities.Cards
{
    public class Card : TripleEntity<Card>, IHasId, IHasStatus
    {
        /// <summary>
        /// The identifier of the Card just passed in.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The status of the web request provided.
        /// </summary>
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        /// <summary>
        /// The result of the tokenized card.
        /// </summary>
        [JsonPropertyName("message")]
        public string Token { get; set; }

        /// <summary>
        /// The request method which has been called.
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; }
    }
}
