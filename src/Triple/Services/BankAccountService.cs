using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Triple.Services
{
    public class BankAccountService : Service<BankAccount>,
        ICreatable<Card, CardCreateOptions>
    {
        public BankAccountService()
            : base(null)
        {
        }

        public BankAccountService(ITripleClient client)
        : base(client)
        {
        }

        public override string BasePath => "/bankaccount";

        public virtual BankAccount Create(BankAccountCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.Request<BankAccount>(HttpMethod.Post, BasePath, options, requestOptions);
        }

        public virtual Task<BankAccount> CreateAsync(BankAccountCreateOptions options, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<BankAccount>(HttpMethod.Post, BasePath, options, requestOptions, cancellationToken);
        }
    }
}
