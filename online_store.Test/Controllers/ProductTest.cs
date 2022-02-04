using online_store.Core.DTOs;
using online_store.Core.Models;
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
    public class ProductTest : TestBase
    {
        [Fact]
        public void GetProductsWithoutTokenTest()
        {
            var resourcePath = "api/Product";
            var statusCode = StatusCodeValidator.GetStatusCode(client, HttpMethod.Get, resourcePath, string.Empty, string.Empty);
            Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
        }

        [Fact]
        public void PostProductTest()
        {
            var resourcePath = "api/Product";
            var CategoryId = 1;
            var Name = "Test Product";

            Random rnd = new Random();
            var product = new Product { CategoryId = CategoryId, Name = Name , Id = rnd.Next(10601, 999999) };
            var serializedProduct = JsonSerializer.Serialize(product);

            var response = StatusCodeValidator.GetStatusCode(client, HttpMethod.Post, resourcePath, serializedProduct, UserToken.Token);

            Assert.Equal(HttpStatusCode.OK, response);
        }

        [Fact]
        public void GetBestProductsTest()
        {
            var resourcePath = "api/Product/best";

            var response = StatusCodeValidator.MakeRequestWithToken(client, HttpMethod.Get, resourcePath, string.Empty, UserToken.Token);
            var bestProducts = JsonSerializer.Deserialize<List<ProductDTO>>(response, serializerOptions);
            
            Assert.NotNull(bestProducts);
            Assert.Equal(10, bestProducts.Count);
        }

        [Fact]
        public void GetByNameTest()
        {
            var name = "Bag Stand";
            var resourcePath = $"api/Product/searchByName?name={name}";

            var response = StatusCodeValidator.MakeRequestWithToken(client, HttpMethod.Get, resourcePath, string.Empty, UserToken.Token);
            var products = JsonSerializer.Deserialize<List<SearchProductDTO>>(response, serializerOptions);

            var firstProduct = products.FirstOrDefault();

            Assert.NotNull(products);
            Assert.True(firstProduct.Name.Contains(name));
        }

        [Fact]
        public void GetByCategoryTest()
        {
            var category = "Leannon";
            var resourcePath = $"api/Product/searchByCategory?category={category}";

            var response = StatusCodeValidator.MakeRequestWithToken(client, HttpMethod.Get, resourcePath, string.Empty, UserToken.Token);
            var products = JsonSerializer.Deserialize<List<SearchProductDTO>>(response, serializerOptions);

            var firstProduct = products.FirstOrDefault();

            Assert.NotNull(products);
            Assert.True(firstProduct.CategoryName.Contains(category));

        }
    }
}
