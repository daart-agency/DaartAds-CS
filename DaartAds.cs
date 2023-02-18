using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Javadi.DaartAgency
{
    public class DaartAds
    {
        private readonly string _token;
        private readonly string _API_URL;

        /// <summary>
        /// Initialise the Class
        /// </summary>
        /// <param name="token">The token that you received from DaartAds</param>
        public DaartAds(string token)
        {
            _token = token;
            _API_URL = "https://api.daartads.com/api/v1/GetAds";
        }

        private string HttpRequest(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentLength = 0;
                request.Accept = "application/json";
                request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {_token}");

                return new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream() ??
                                        throw new NullReferenceException()).ReadToEnd();
            }
            catch (WebException we)
            {
                if (((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("Token is not valid");
                }
            }

            return null;
        }

        /// <summary>
        /// Get Ads
        /// </summary>
        /// <param name="forMobile">Do you want to show advertisements on mobile?</param>
        /// <returns>List of details about ads</returns>
        public JToken GetAds(bool forMobile = false)
        {
           return JObject.Parse(HttpRequest(forMobile ? $"{_API_URL}?forMobile" : _API_URL)).SelectToken("Result");
        }

    }
}
