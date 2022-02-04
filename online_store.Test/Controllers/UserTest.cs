using online_store.Core.DTOs;
using online_store.Test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace online_store.Test.Controllers
{
    public class UserTest : TestBase
    {
        private string resourcePath = "api/User/login";

        private UserResponseDTO LoginUser(string username, string password)
        {
            var user = new UserDTO { Username = username, Password = password };

            var serializedUser = JsonSerializer.Serialize(user);
            var responseBody = StatusCodeValidator.MakeRequestWithoutToken(client, HttpMethod.Post, resourcePath, serializedUser);

            return JsonSerializer.Deserialize<UserResponseDTO>(responseBody, serializerOptions);
        }

        [Fact]
        public void VerifyLogin()
        {
            var username = "Diego";
            var password = "Diego123";
            var userResponseDto = LoginUser(username, password);

            Assert.NotNull(userResponseDto);
            Assert.True(userResponseDto.Ok);
        }

        [Fact]
        public void VerifyLoginWithBadCredentials()
        {
            var username = "asd";
            var password = "dadwads";

            var user = new UserDTO { Username = username, Password = password };
            var serializedUser = JsonSerializer.Serialize(user);

            var response = StatusCodeValidator.GetStatusCode(client, HttpMethod.Post, resourcePath, serializedUser, string.Empty);

            Assert.Equal(HttpStatusCode.BadRequest, response);
        }
    }
}
