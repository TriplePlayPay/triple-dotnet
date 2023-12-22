using System;
using System.Threading;
using System.Threading.Tasks;
using Triple.Infrastructure;

namespace Triple.Interfaces
{
    /// <summary>
    /// Interface for HTTP clients used to make requests to Triple's API.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>Sends a request to Triple's API as an asynchronous operation.</summary>
        /// <param name="request">The parameters of the request to send.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<TripleResponse> MakeRequestAsync(
            TripleRequest request,
            CancellationToken cancellationToken = default);

        Task<TripleStreamedResponse> MakeStreamingRequestAsync(
            TripleRequest request,
            CancellationToken cancellationToken = default);
    }
}
