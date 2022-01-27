using System;
using Refit;
using Com.KeyCDN.Api.Abstraction;

/// <summary>
/// Library for the KeyCDN API
/// </summary>
namespace Com.KeyCDN.Api
{
	/// <summary>
    /// KeyCDN API
    /// </summary>
	public class KeyCDN : BaseComponent
	{
		private string _apiKey;
		public string ApiKey
        {
			get { return _apiKey; }
			set { _apiKey = value; }
        }

		private string _endpoint;
		public string Endpoint
        {
			get { return _endpoint; }
			set { _endpoint = value; }
        }

		public KeyCDN(string apiKey, string endpoint = null)
		{
			if (string.IsNullOrEmpty(endpoint)) {
				endpoint = "https://api.keycdn.com";
			}

			this.ApiKey = apiKey;
			this.Endpoint = endpoint;
		}


	}
}

