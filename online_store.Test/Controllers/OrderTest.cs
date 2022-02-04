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
    public class OrderTest : TestBase
    {
        private static readonly string resourcePath = "api/Order";

        [Fact]
        public void GetOrderssWithoutToken()
        {
            var statusCode = StatusCodeValidator.GetStatusCode(client, HttpMethod.Get, resourcePath, string.Empty, string.Empty);
            Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
        }
    }
}
