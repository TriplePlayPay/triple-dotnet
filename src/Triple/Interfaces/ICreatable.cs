using System.Threading;
using System.Threading.Tasks;
using Triple.Infrastructure;

namespace Triple.Interfaces
{
    public interface ICreatable<TEntity, TOptions>
        where TEntity : ITripleEntity
        where TOptions : BaseOptions, new()
    {
        TEntity Create(TOptions createOptions, RequestOptions requestOptions = null);

        Task<TEntity> CreateAsync(TOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);
    }
}
