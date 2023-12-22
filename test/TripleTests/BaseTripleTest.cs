using System.Net;
using System.Reflection;
using System.Text;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace TripleTests
{
    [Collection("Triple tests")]
    public class BaseTripleTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTripleTest"/> class with no fixtures.
        /// </summary>
        public BaseTripleTest()
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTripleTest"/> class with the
        /// <see cref="TripleMockFixture"/> fixture. Use this constructor for tests that need to
        /// send requests to Triple-mock, but don't need mocking capabilities (i.e. don't need to
        /// assert or stub HTTP requests).
        /// </summary>
        /// <param name="TripleMockFixture">
        /// The <see cref="TripleMockFixture"/> fixture.
        /// </param>
        public BaseTripleTest(TripleMockFixture TripleMockFixture)
            : this(TripleMockFixture, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTripleTest"/> class with the
        /// <see cref="MockHttpClientFixture"/> fixture. Use this constructor for tests that need
        /// mocking capabilities (i.e. need to assert or stub HTTP requests) but don't need to send
        /// requests to Triple-mock.
        /// </summary>
        /// <param name="mockHttpClientFixture">
        /// The <see cref="MockHttpClientFixture"/> fixture.
        /// </param>
        public BaseTripleTest(MockHttpClientFixture mockHttpClientFixture)
            : this(null, mockHttpClientFixture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTripleTest"/> class with both the
        /// <see cref="TripleMockFixture"/> and the <see cref="MockHttpClientFixture"/> fixtures.
        /// Use this constructor for tests that need to send requests to Triple-mock and also need
        /// mocking capabilities (i.e. need to assert or stub HTTP requests).
        /// </summary>
        /// <param name="TripleMockFixture">
        /// The <see cref="TripleMockFixture"/> fixture.
        /// </param>
        /// <param name="mockHttpClientFixture">
        /// The <see cref="MockHttpClientFixture"/> fixture.
        /// </param>
        public BaseTripleTest(
            TripleMockFixture TripleMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
        {
            this.TripleMockFixture = TripleMockFixture;
            this.MockHttpClientFixture = mockHttpClientFixture;

            if ((this.TripleMockFixture != null) && (this.MockHttpClientFixture != null))
            {
                // Set up TripleClient to use Triple-mock with the mock HTTP client
                var httpClient = new SystemNetHttpClient(
                    new HttpClient(this.MockHttpClientFixture.MockHandler.Object));
                this.TripleClient = this.TripleMockFixture.BuildTripleClient(
                    httpClient: httpClient);

                // Reset the mock before each test
                this.MockHttpClientFixture.Reset();
            }
            else if (this.TripleMockFixture != null)
            {
                // Set up TripleClient to use Triple-mock
                this.TripleClient = this.TripleMockFixture.BuildTripleClient();
            }
            else if (this.MockHttpClientFixture != null)
            {
                // Set up TripleClient with the mock HTTP client
                var httpClient = new SystemNetHttpClient(
                    new HttpClient(this.MockHttpClientFixture.MockHandler.Object));
                this.TripleClient = new TripleClient(
                    "testapikey",
                    httpClient: httpClient);

                // Reset the mock before each test
                this.MockHttpClientFixture.Reset();
            }
            else
            {
                // Use the default TripleClient
                this.TripleClient = new TripleClient("testapikey");
            }
        }

        protected ITripleClient TripleClient { get; }

        protected MockHttpClientFixture MockHttpClientFixture { get; }

        protected TripleMockFixture TripleMockFixture { get; }

        /// <summary>
        /// Gets a resource file and returns its contents in a string.
        /// </summary>
        /// <param name="path">Path to the resource file.</param>
        /// <returns>The file contents.</returns>
        protected static string GetResourceAsString(string path)
        {
            var fullpath = "TripleTests.Resources." + path;
            var contents = new StreamReader(
                typeof(BaseTripleTest).GetTypeInfo().Assembly.GetManifestResourceStream(fullpath),
                Encoding.UTF8).ReadToEnd();

            return contents;
        }

        /// <summary>
        /// Asserts that a single HTTP request was made with the specified method and path.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The HTTP path.</param>
        protected void AssertRequest(HttpMethod method, string path)
        {
            if (this.MockHttpClientFixture == null)
            {
                throw new TripleTestException(
                    "AssertRequest called from a test class that doesn't have access to "
                    + "MockHttpClientFixture. Make sure that the constructor for "
                    + $"{this.GetType().Name} receives MockHttpClientFixture and calls the "
                    + "base constructor.");
            }

            this.MockHttpClientFixture.AssertRequest(method, path);
        }

        /// <summary>
        /// Stubs an HTTP request with the specified method and path to return the specified status
        /// code and response body.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The HTTP path.</param>
        /// <param name="status">The status code to return.</param>
        /// <param name="response">The response body to return.</param>
        /// <param name="query">The HTTP query.</param>
        protected void StubRequest(HttpMethod method, string path, HttpStatusCode status, string response, string query = null)
        {
            if (this.MockHttpClientFixture == null)
            {
                throw new TripleTestException(
                    "StubRequest called from a test class that doesn't have access to "
                    + "MockHttpClientFixture. Make sure that the constructor for "
                    + $"{this.GetType().Name} receives MockHttpClientFixture and calls the "
                    + "base constructor.");
            }

            this.MockHttpClientFixture.StubRequest(method, path, status, response, query);
        }

        /// <summary>
        /// Gets fixture data with expansions specified. Expansions are specified the same way as
        /// they are in the normal API like <c>customer</c> or <c>data.customer</c>.
        /// Use the special <c>*</c> character to specify that all fields should be
        /// expanded.
        /// </summary>
        /// <param name="path">API path to use to get a fixture for Triple-mock.</param>
        /// <param name="expansions">Set of expansions that should be applied.</param>
        /// <returns>Fixture data encoded as JSON.</returns>
        protected string GetFixture(string path)
        {
            if (this.TripleMockFixture == null)
            {
                throw new TripleTestException(
                    "GetFixture called from a test class that doesn't have access to "
                    + "TripleMockFixture. Make sure that the constructor for "
                    + $"{this.GetType().Name} receives TripleMockFixture and calls the "
                    + "base constructor.");
            }

            return this.TripleMockFixture.GetFixture(path);
        }
    }
}