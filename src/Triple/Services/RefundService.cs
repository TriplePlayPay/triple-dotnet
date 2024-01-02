using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Triple.Abstract;
using Triple.Entities.Refunds;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace Triple.Services
{
    public class RefundService : Service<Refund>,
        ICreatable<Refund, RefundCreateOptions>
    {
        public RefundService()
            : base(null)
        {
        }

        public RefundService(ITripleClient client)
        : base(client)
        {
        }

        public override string BasePath => "/refund";

        public virtual Refund Create(RefundCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<Refund>(HttpMethod.Post, BasePath, options, requestOptions);
        }

        public virtual Task<Refund> CreateAsync(RefundCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<Refund>(HttpMethod.Post, BasePath, options, requestOptions, cancellationToken);
        }
    }
}
