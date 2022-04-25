using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace WebApiMango.ApiMaingo
{
    public class RequestApi
    {
        private string uri = "https://app.mango-office.ru/vpbx/events/call";
        public void PostRequesMango(Route route)
        {
            var vpbx_api_key = "hzqw8bciijbj3dlvywle78avmfz9kqqr";
            var sign = "f6ee7hmgropkr15gnhllfl6sqws0c8ii";
            var request = JsonConvert.SerializeObject(route);
            using (var clint = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(uri),
                    Method = HttpMethod.Post,
                    Content = new StringContent(request)
                };
                httpRequest.Headers.Add("vpbx_api_key", vpbx_api_key);
                httpRequest.Headers.Add("sign", sign);
                var response = clint.SendAsync(httpRequest).Result;
                var jsonTask = response.Content.ReadAsStringAsync();
                
            }
        }
    }
}
