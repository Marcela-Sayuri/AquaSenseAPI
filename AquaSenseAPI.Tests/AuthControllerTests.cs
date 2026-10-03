using Microsoft.AspNetCore.Mvc.Testing;

namespace AquaSenseAPI.Tests
{
    public class AuthControllerTests :
        IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuthControllerTests(
            WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Login_ReturnsHttpStatusCode200()
        {
            var response =
                await _client.PostAsync("/api/Auth/login", null);

            response.EnsureSuccessStatusCode();
        }
    }
}