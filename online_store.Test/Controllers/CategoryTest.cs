using online_store.Core.Models;
using online_store.Test.Common;
using online_store.Test.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Xunit;

namespace online_store.Test
{
    public class CategoryTest : TestBase
    {
        private string resourcePath = "api/Category";

        [Fact]
        public void GetCategoriesWithoutToken()
        {
            var statusCode = StatusCodeValidator.GetStatusCode(client, HttpMethod.Get, resourcePath, string.Empty, string.Empty);
            Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
        }

        [Fact]
        public void GetCategoriesWithToken()
        {
            var res = TokenValidator.GetToken();
            var response = StatusCodeValidator.MakeRequestWithToken(client, HttpMethod.Get, resourcePath, string.Empty, res.Token);
            var categories = JsonSerializer.Deserialize<List<Category>>(response, serializerOptions);
            
            Assert.NotNull(categories);
            Assert.Equal(20, categories.Count);
        }
    }
}
