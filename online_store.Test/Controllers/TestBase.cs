using online_store.Core.DTOs;
using online_store.Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace online_store.Test.Controllers
{
    public abstract class TestBase
    {
        private static string hostUrl = "http://localhost:8080";
        protected readonly HttpClient client = new HttpClient { BaseAddress = new Uri(hostUrl) };
        protected readonly JsonSerializerOptions serializerOptions =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        protected UserResponseDTO UserToken;

        public TestBase()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "Integration Test App");
            UserToken = TokenValidator.GetToken();
        }
    }
}
