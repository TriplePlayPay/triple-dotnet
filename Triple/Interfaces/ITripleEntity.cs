using Triple.Infrastructure;

namespace Triple.Interfaces
{
    /// <summary>
    /// Interface that identifies all entities returned by TriplePlayPay.
    /// </summary>
    public interface ITripleEntity
    {
        TripleResponse TripleResponse { get; set; }
    }
}
