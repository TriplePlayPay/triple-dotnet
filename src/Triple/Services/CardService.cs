using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Triple.Abstract;
using Triple.Entities.Cards;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace Triple.Services
{
    public class CardService : Service<Card>,
        ICreatable<Card, CardCreateOptions>
    {
        public CardService()
            : base(null)
        {
        }

        public CardService(ITripleClient client)
        : base(client)
        {
        }

        public override string BasePath => "/card";

        public virtual Card Create(CardCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<Card>(HttpMethod.Post, BasePath, options, requestOptions);
        }

        public virtual Task<Card> CreateAsync(CardCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Card>(HttpMethod.Post, BasePath, options, requestOptions, cancellationToken);
        }
    }
}
