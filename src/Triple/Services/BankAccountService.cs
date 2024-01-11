using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Triple.Abstract;
using Triple.Interfaces;
using Triple.Infrastructure;
using Triple.Entities.BankAccounts;
using System.Net.Http;

namespace Triple.Services
{
    public class BankAccountService : Service<BankAccount>,
        ICreatable<BankAccount, BankAccountCreateOptions>
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
