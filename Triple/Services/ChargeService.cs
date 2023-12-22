using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Triple.Entities;
using Triple.Abstract;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace Triple.Services
{
    public class ChargeService : Service<Charge>,
        ICreatable<Charge, ChargeCreateOptions>,
        IListable<Charge, ChargeListOptions>,
        IRetrievable<Charge, ChargeGetOptions>,
        ISearchable<Charge, ChargeSearchOptions>,
        IUpdatable<Charge, ChargeUpdateOptions>
    {
        public ChargeService()
            : base(null)
        {
        }

        public ChargeService(ITripleClient client)
        : base(client)
        {
        }
        public override string BasePath => "/charge";

        public virtual Charge Capture(string id, ChargeCaptureOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<Charge>(HttpMethod.Post, $"/v1/charges/{id}/capture", options, requestOptions);
        }

        public virtual Task<Charge> CaptureAsync(string id, ChargeCaptureOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Charge>(HttpMethod.Post, $"/v1/charges/{id}/capture", options, requestOptions, cancellationToken);
        }

        public virtual Charge Create(ChargeCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<Charge>(HttpMethod.Post, $"/v1/charges", options, requestOptions);
        }

        public virtual Task<Charge> CreateAsync(ChargeCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Charge>(HttpMethod.Post, $"/v1/charges", options, requestOptions, cancellationToken);
        }

        public virtual Charge Get(string id, ChargeGetOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<Charge>(HttpMethod.Get, $"/v1/charges/{id}", options, requestOptions);
        }

        public virtual Task<Charge> GetAsync(string id, ChargeGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Charge>(HttpMethod.Get, $"/v1/charges/{id}", options, requestOptions, cancellationToken);
        }

        public virtual TripleList<Charge> List(ChargeListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<TripleList<Charge>>(HttpMethod.Get, $"/v1/charges", options, requestOptions);
        }

        public virtual Task<TripleList<Charge>> ListAsync(ChargeListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<TripleList<Charge>>(HttpMethod.Get, $"/v1/charges", options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<Charge> ListAutoPaging(ChargeListOptions options = null, RequestOptions requestOptions = null)
        {
            return this.ListRequestAutoPaging<Charge>($"/v1/charges", options, requestOptions);
        }

        public virtual IAsyncEnumerable<Charge> ListAutoPagingAsync(ChargeListOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.ListRequestAutoPagingAsync<Charge>($"/v1/charges", options, requestOptions, cancellationToken);
        }

        public virtual TripleSearchResult<Charge> Search(ChargeSearchOptions options = null, RequestOptions requestOptions = null)
        {
            return this.Request<TripleSearchResult<Charge>>(HttpMethod.Get, $"/v1/charges/search", options, requestOptions);
        }

        public virtual Task<TripleSearchResult<Charge>> SearchAsync(ChargeSearchOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<TripleSearchResult<Charge>>(HttpMethod.Get, $"/v1/charges/search", options, requestOptions, cancellationToken);
        }

        public virtual IEnumerable<Charge> SearchAutoPaging(ChargeSearchOptions options = null, RequestOptions requestOptions = null)
        {
            return this.SearchRequestAutoPaging<Charge>($"/v1/charges/search", options, requestOptions);
        }

        public virtual IAsyncEnumerable<Charge> SearchAutoPagingAsync(ChargeSearchOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.SearchRequestAutoPagingAsync<Charge>($"/v1/charges/search", options, requestOptions, cancellationToken);
        }

        public virtual Charge Update(string id, ChargeUpdateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<Charge>(HttpMethod.Post, $"/v1/charges/{id}", options, requestOptions);
        }

        public virtual Task<Charge> UpdateAsync(string id, ChargeUpdateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Charge>(HttpMethod.Post, $"/v1/charges/{id}", options, requestOptions, cancellationToken);
        }
    }
}
