﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text.Json;
using Triple.Interfaces;

namespace Triple.Infrastructure
{
    /// <summary>
    /// Global configuration class for Triple.net settings.
    /// </summary>
    public static class TripleConfiguration
    {
        private static string apiKey;

        private static int maxNetworkRetries = SystemNetHttpClient.DefaultMaxNumberRetries;

        private static ITripleClient TripleClient;

        static TripleConfiguration()
        {
        }

        /// <summary>Gets or sets the API key.</summary>
        /// <remarks>
        /// You can also set the API key using the <c>TripleApiKey</c> key in
        /// <see cref="System.Configuration.ConfigurationManager.AppSettings"/>.
        /// </remarks>
        public static string ApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(apiKey) &&
                    !string.IsNullOrEmpty(ConfigurationManager.AppSettings["TripleApiKey"]))
                {
                    apiKey = ConfigurationManager.AppSettings["TripleApiKey"];
                }

                return apiKey;
            }

            set
            {
                apiKey = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of times that the library will retry requests that
        /// appear to have failed due to an intermittent problem.
        /// </summary>
        public static int MaxNetworkRetries
        {
            get => maxNetworkRetries;

            set
            {
                maxNetworkRetries = value;
            }
        }

        private static TripleClient BuildDefaultTripleClient()
        {
            if (ApiKey != null && ApiKey.Length == 0)
            {
                var message = "Your API key is invalid, as it is an empty string. You can "
                    + "double-check your API key from Triple.";
                throw new TripleException(message);
            }

            if (ApiKey != null && StringUtils.ContainsWhitespace(ApiKey))
            {
                var message = "Your API key is invalid, as it contains whitespace. You can "
                    + "double-check your API key from Triple.";
                throw new TripleException(message);
            }

            var httpClient = new SystemNetHttpClient(
                httpClient: null,
                maxNetworkRetries: MaxNetworkRetries);
            return new TripleClient(ApiKey, httpClient: httpClient);
        }
    }
}