using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Triple.Infrastructure;

namespace Triple.Interfaces
{
    /// <summary>
    /// Interface for a Triple client.
    /// </summary>
    public interface ITripleClient
    {
        /// <summary>Gets the base URL for Triple's API.</summary>
        /// <value>The base URL for Triple's API.</value>
        string ApiBase { get; }

        /// <summary>Gets the API key used by the client to send requests.</summary>
        /// <value>The API key used by the client to send requests.</value>
        string ApiKey { get; }

        /// <summary>Sends a request to Triple's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the Triple entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="TripleException">Thrown if the request fails.</exception>
        Task<T> RequestAsync<T>(
            HttpMethod method,
        string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
            where T : ITripleEntity;

        /// <summary>Sends a request to Triple's API as an asynchronous operation and returns a <see cref="Stream"/> as the response.</summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A task object with the Stream of the response body on success..</returns>
        /// <exception cref="TripleException">Thrown if the request fails.</exception>
        Task<Stream> RequestStreamingAsync(
            HttpMethod method,
        string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default);
    }
}
