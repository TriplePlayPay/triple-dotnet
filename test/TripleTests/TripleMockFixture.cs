using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace TripleTests
{
    public class TripleMockFixture
    {
        private readonly string apiBase;

        public TripleMockFixture(string apiBase = "https://sandbox.tripleplaypay.com")
        {
            this.apiBase = apiBase;
        }

        /// <summary>
        /// Creates and returns a new instance of <see cref="TripleClient"/> suitable for use with
        /// Triple-mock.
        /// </summary>
        /// <param name="httpClient">
        /// The <see cref="IHttpClient"/> client to use. If <c>null</c>, an HTTP client will be
        /// created with default parameters.
        /// </param>
        /// <returns>The new <see cref="TripleClient"/> instance.</returns>
        public TripleClient BuildTripleClient(IHttpClient httpClient = null)
        {
            return new TripleClient(
                "testapikey",
                httpClient: httpClient,
                apiBase: this.apiBase);
        }

        /// <summary>
        /// Gets fixture data with expansions specified. Expansions are specified the same way as
        /// they are in the normal API.
        /// </summary>
        /// <param name="path">API path to use to get a fixture for Triple.</param>
        /// <returns>Fixture data encoded as JSON.</returns>
        public string GetFixture(string path)
        {
            string url = $"{this.apiBase}{path}";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization
                    = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        "testapikey");

                HttpResponseMessage response;

                try
                {
                    response = client.GetAsync(url).Result;
                }
                catch (Exception)
                {
                    throw new TripleTestException(
                        $"Couldn't reach Triple at `{this.apiBase}`. "
                        + "Is it running?");
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new TripleTestException(
                        $"Triple returned status code: {response.StatusCode}.");
                }

                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// Does a POST to our sandbox environment to return a value.
        /// </summary>
        /// <param name="path">API path to use to get a fixture for Triple.</param>
        /// <param name="path">API path to use to get a fixture for Triple.</param>
        /// <returns>Fixture data encoded as JSON.</returns>
        public string PostFixture(string path, HttpContent content)
        {
            string url = $"{this.apiBase}{path}";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                client.DefaultRequestHeaders.Authorization
                    = new System.Net.Http.Headers.AuthenticationHeaderValue(
                        "Bearer",
                        "testapikey");

                HttpResponseMessage response;

                try
                {
                    response = client.PostAsync(url, content).Result;
                }
                catch (Exception)
                {
                    throw new TripleTestException(
                        $"Couldn't reach Triple at `{this.apiBase}`. "
                        + "Is it running?");
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new TripleTestException(
                        $"Triple returned status code: {response.StatusCode}.");
                }

                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
