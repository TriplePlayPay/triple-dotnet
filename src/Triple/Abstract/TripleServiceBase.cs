using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Linq;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace Triple.Abstract
{
    /// <summary>Abstract base class for all services.</summary>
    /// <typeparam name="TEntityReturned">
    /// The type of <see cref="ITripleEntity"/> that this service returns.
    /// </typeparam>
    public abstract class Service<TEntityReturned>
        where TEntityReturned : ITripleEntity
    {
        private ITripleClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class.
        /// </summary>
        protected Service()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class with a
        /// custom <see cref="ITripleClient"/>.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        protected Service(ITripleClient client)
        {
            this.client = client;
        }

        public abstract string BasePath { get; }

        public virtual string BaseUrl => this.Client.ApiBase;

        /// <summary>
        /// Gets or sets the client used by this service to send requests.
        /// </summary>
        /// <remarks>
        /// Setting the client at runtime may not be thread-safe.
        /// If you wish to use a custom client, it is recommended that you pass it to the service's constructor and not change it during the service's lifetime.
        /// </remarks>
        public ITripleClient Client
        {
            get => this.client;
            set => this.client = value;
        }

        protected TEntityReturned Request(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            return this.Request<TEntityReturned>(
                method,
                path,
                options,
                requestOptions);
        }

        protected Task<TEntityReturned> RequestAsync(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            return this.RequestAsync<TEntityReturned>(
                method,
                path,
                options,
                requestOptions,
                cancellationToken);
        }

        protected T Request<T>(
            HttpMethod method,
        string path,
            BaseOptions options,
            RequestOptions requestOptions)
            where T : ITripleEntity
        {
            return this.RequestAsync<T>(method, path, options, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected Stream RequestStreaming(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            return this.RequestStreamingAsync(method, path, options, requestOptions)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        protected async Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
            where T : ITripleEntity
        {
            requestOptions = this.SetupRequestOptions(requestOptions);
            return await this.Client.RequestAsync<T>(
                method,
                path,
                options,
                requestOptions,
                cancellationToken).ConfigureAwait(false);
        }

        protected async Task<Stream> RequestStreamingAsync(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            requestOptions = this.SetupRequestOptions(requestOptions);
            var stream = await this.Client.RequestStreamingAsync(
                    method,
                    path,
                    options,
                    requestOptions,
                    cancellationToken)
                .ConfigureAwait(false);
            return stream;
        }

        protected RequestOptions SetupRequestOptions(RequestOptions requestOptions)
        {
            if (requestOptions == null)
            {
                requestOptions = new RequestOptions();
            }

            requestOptions.BaseUrl = requestOptions.BaseUrl ?? this.BaseUrl;

            return requestOptions;
        }

        protected virtual string ClassUrl()
        {
            return this.BasePath;
        }

        protected virtual string InstanceUrl(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(
                    "The resource ID cannot be null or whitespace.",
                    nameof(id));
            }

            return $"{this.ClassUrl()}/{WebUtility.UrlEncode(id)}";
        }
    }
}
