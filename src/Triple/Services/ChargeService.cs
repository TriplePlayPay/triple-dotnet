using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Triple.Abstract;
using Triple.Infrastructure;
using Triple.Interfaces;
using Triple.Entities.Charges;

namespace Triple.Services
{
    public class ChargeService : Service<Charge>,
        ICreatable<Charge, ChargeCreateOptions>
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

        public virtual Charge Create(ChargeCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<Charge>(HttpMethod.Post, BasePath, options, requestOptions);
        }

        public virtual Task<Charge> CreateAsync(ChargeCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Charge>(HttpMethod.Post, BasePath, options, requestOptions, cancellationToken);
        }
    }
}
