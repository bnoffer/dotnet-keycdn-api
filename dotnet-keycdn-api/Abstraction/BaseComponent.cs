using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using Refit;
using Com.KeyCDN.Api.Logging;

namespace Com.KeyCDN.Api.Abstraction
{
    public abstract class BaseComponent
    {
        #region Properties
        protected AsyncRetryPolicy Policy;
        #endregion

        #region Constructor
        /// <summary>
        /// Base component for setting the general retry policy
        /// </summary>
        protected BaseComponent()
        {
            string tag = this + ".BaseComponent";
            try
            {
                // Define Policy
                this.Policy = Polly.Policy
                    .Handle<ApiException>()
                    .Or<HttpRequestException>()
                    .Or<TimeoutException>()
                    .RetryAsync(3, (exception, retry) =>
                    {
                        Track.Exception(tag, exception);

                        // Handle Unauthorized
                        if (exception is ApiException apiException)
                        {
                            if (apiException.StatusCode == HttpStatusCode.RequestTimeout)
                            {
                            }
                            if ((int)apiException.StatusCode == 429)
                            {
                                // Rate limit reached, wait a second
                                Thread.Sleep(TimeSpan.FromSeconds(1));
                            }
                            if (apiException.StatusCode == HttpStatusCode.Unauthorized)
                            {
                                if (retry == 1)
                                {
                                    // The first time an Unauthorized exception occurs, 
                                    Thread.Sleep(TimeSpan.FromSeconds(2));
                                }
                                else if (retry == 2)
                                {

                                }
                            }
                        }
                        // Handle everything else
                        else
                        {
                            // Wait a bit and try again
                            Thread.Sleep(TimeSpan.FromSeconds(retry));
                        }
                    });
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
        #endregion

        #region Base64

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion

        public string FormatBasicAuthHeader(string username, string password)
        {
            var token = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            return $"Basic {token}";
        }

        protected T GetRestService<T>(string baseUrl)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(baseUrl) };
            return RestService.For<T>(httpClient);
        }
    }
}

