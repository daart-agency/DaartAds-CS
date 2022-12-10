using System;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
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
            _API_URL = "https://daartads.com/advertising/apiAdv4.php";
        }

        private string HttpRequest(string url, Dictionary<string, string> data)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                string PostFields = "";
                foreach (var param in data)
                {
                    PostFields += $"{param.Key}={param.Value}&";
                }
                var PostData = Encoding.ASCII.GetBytes(PostFields);

                request.Method = "POST";
              
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = PostData.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(PostData, 0, PostData.Length);
                }

               return new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()).ReadToEnd();
            }
            catch (WebException we)
            {
                if(((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new Exception("Token Not valid");
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AdSize">Select the ad size ID that appears on the API docs.</param>
        /// <returns>List of details about ads</returns>
        public JToken GetAds(string AdSize)
        {
           return JObject.Parse(HttpRequest(_API_URL, new Dictionary<string, string>
            {
                  { "token", _token},
                  { "adsize", AdSize }
            })).SelectToken("data");
        }

        /// <summary>
        /// Make Ad Callback URL
        /// </summary>
        /// <param name="Cid">Click ID (Obtain from GetAds() Method)</param>
        /// <param name="Source">Your ID (Obtain from GetAds() Method)</param>
        /// <param name="adSize">Chosen Ad size</param>
        /// <returns>URL for Callback</returns>
        public string GetAdCallBack(int Cid,int Source, string adSize)
        {
            return $"https://daartads.com/CP.php?Cid={Cid}&Source={Source}&adsize={adSize}";
        }

    }
}
