using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace online_store.Test.Common
{
    public class StatusCodeValidator
    {
        public static HttpStatusCode GetStatusCode(HttpClient client, HttpMethod verb, string path, string content, string token)
        {
            var request = new HttpRequestMessage(verb, path);

            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            if (!string.IsNullOrWhiteSpace(content))
            {
                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            var response = client.SendAsync(request).Result;

            return response.StatusCode;
        }

        public static string MakeRequestWithoutToken(HttpClient client, HttpMethod verb, string path, string content)
        {
            var request = new HttpRequestMessage(verb, path);

            if (!string.IsNullOrWhiteSpace(content))
            {
                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            var response = client.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync().Result;
        }

        public static string MakeRequestWithToken(HttpClient client, HttpMethod verb, string path, string content, string token)
        {
            var request = new HttpRequestMessage(verb, path);
            
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (!string.IsNullOrWhiteSpace(content))
            {
                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            var response = client.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
