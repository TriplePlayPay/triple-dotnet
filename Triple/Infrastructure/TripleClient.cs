using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using Triple.Entities;
using Triple.Interfaces;


namespace Triple.Infrastructure
{
    /// <summary>
    /// A Triple client, used to issue requests to Triple's API and deserialize responses.
    /// </summary>
    public class TripleClient : ITripleClient
    {
        /// <summary>Initializes a new instance of the <see cref="TripleClient"/> class.</summary>
        /// <param name="apiKey">The API key used by the client to make requests.</param>
        /// <param name="httpClient">
        /// The <see cref="IHttpClient"/> client to use. If <c>null</c>, an HTTP client will be
        /// created with default parameters.
        /// </param>
        /// <param name="apiBase">
        /// The base URL for Triple's API. Defaults to <see cref="DefaultApiBase"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">if <c>apiKey</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// if <c>apiKey</c> is empty or contains whitespace.
        /// </exception>
        public TripleClient(
            string apiKey = null,
            string clientId = null,
            IHttpClient httpClient = null,
            string apiBase = null)
        {
            if (apiKey != null && apiKey.Length == 0)
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            this.ApiKey = apiKey;
            this.HttpClient = httpClient ?? BuildDefaultHttpClient();
            this.ApiBase = apiBase ?? DefaultApiBase;
        }

        /// <summary>Default base URL for Triple's API.</summary>
        public static string DefaultApiBase => "https://tripleplaypay.com/api";

        /// <summary>Gets the base URL for Triple's API.</summary>
        /// <value>The base URL for Triple's API.</value>
        public string ApiBase { get; }

        /// <summary>Gets the API key used by the client to send requests.</summary>
        /// <value>The API key used by the client to send requests.</value>
        public string ApiKey { get; }

        /// <summary>Gets the <see cref="IHttpClient"/> used to send HTTP requests.</summary>
        /// <value>The <see cref="IHttpClient"/> used to send HTTP requests.</value>
        public IHttpClient HttpClient { get; }

        /// <summary>Sends a request to Triple's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the Triple entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="TripleException">Thrown if the request fails.</exception>
        public async Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
            where T : ITripleEntity
        {
            var request = new TripleRequest(this, method, path, options, requestOptions);

            var response = await this.HttpClient.MakeRequestAsync(request, cancellationToken)
                .ConfigureAwait(false);

            return ProcessResponse<T>(response);
        }

        /// <inheritdoc/>
        public async Task<Stream> RequestStreamingAsync(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            var request = new TripleRequest(this, method, path, options, requestOptions);

            var response = await this.HttpClient.MakeStreamingRequestAsync(request, cancellationToken)
                .ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Body;
            }

            var readResponse = await response.ToTripleResponseAsync().ConfigureAwait(false);
            throw BuildTripleException(readResponse);
        }

        private static IHttpClient BuildDefaultHttpClient()
        {
            return new SystemNetHttpClient();
        }

        private static T ProcessResponse<T>(TripleResponse response)
            where T : ITripleEntity
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw BuildTripleException(response);
            }

            T obj;
            try
            {
                obj = TripleEntity.FromJson<T>(response.Content);
            }
            catch (JsonException)
            {
                throw BuildInvalidResponseException(response);
            }
            obj.TripleResponse = response;

            return obj;
        }

        private static TripleException BuildTripleException(TripleResponse response)
        {
            return new TripleException(
                response.StatusCode,
                response.Content)
            {
                TripleResponse = response,
            };
        }

        private static TripleException BuildInvalidResponseException(TripleResponse response)
        {
            return new TripleException(
                response.StatusCode,
                $"Invalid response object from API: \"{response.Content}\"")
            {
                TripleResponse = response,
            };
        }
    }
}
