using online_store.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace online_store.Test.Common
{
    public class TokenValidator
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly JsonSerializerOptions serializerOptions =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static UserResponseDTO GetToken()
        {
            var user = new UserDTO { Username = "Diego", Password = "diego123" };

            var serializedUser = JsonSerializer.Serialize(user);

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/api/User/login");

            request.Content = new StringContent(serializedUser);

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.SendAsync(request).Result;

            response.EnsureSuccessStatusCode();

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<UserResponseDTO>(responseBody, serializerOptions);
        }
    }
}
