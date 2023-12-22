using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Triple.Interfaces;
using Triple.Infrastructure;

namespace Triple.Entities.Refunds
{
    public class RefundCreateOptions : BaseOptions, IHasId
    {
        /// <summary>
        /// Identity of the transaction to be refunded
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
