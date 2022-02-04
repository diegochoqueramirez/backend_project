using online_store.Core.DTOs;
using online_store.Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace online_store.Test.Controllers
{
    public class CostumerTest : TestBase
    {
        [Fact]
        public void GetProductsOfCostumerByName()
        {
            var product = "Bag Stand";
            var resourcePath = $"api/Costumer/searchByProduct?product={product}";

            var response = StatusCodeValidator.MakeRequestWithToken(client, HttpMethod.Get, resourcePath, string.Empty, UserToken.Token);
            var products = JsonSerializer.Deserialize<List<SearchCostumerDTO>>(response, serializerOptions);

            var firstProduct = products.FirstOrDefault();

            Assert.NotNull(products);
            Assert.True(firstProduct.ProductName.Contains(product));
        }

        [Fact]
        public void ValidateSearchCostumerByProductNameToken()
        {
            var product = "Bag Stand";
            var resourcePath = $"api/Costumer/searchByProduct?product={product}";

            var response = StatusCodeValidator.GetStatusCode(client, HttpMethod.Get, resourcePath, string.Empty, string.Empty);

            Assert.Equal(HttpStatusCode.Unauthorized, response);
        }
    }
}
