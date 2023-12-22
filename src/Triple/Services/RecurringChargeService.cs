using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triple.Abstract;
using Triple.Entities.RecurringCharges;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace Triple.Services
{
    public class RecurringChargeService : Service<RecurringCharge>,
        ICreatable<RecurringCharge, RecurringChargeCreateOptions>
    {
        public RecurringChargeService()
            : base(null)
        {
        }

        public RecurringChargeService(ITripleClient client)
        : base(client)
        {
        }

        public override string BasePath => "/subscription";

        public virtual RecurringCharge Create(RecurringChargeCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<RecurringCharge>(HttpMethod.Post, BasePath, options, requestOptions);
        }

        public virtual Task<RecurringCharge> CreateAsync(RecurringChargeCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<RecurringCharge>(HttpMethod.Post, BasePath, options, requestOptions, cancellationToken);
        }
    }
}
