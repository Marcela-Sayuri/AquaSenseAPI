using Microsoft.AspNetCore.Mvc.Testing;

namespace AquaSenseAPI.Tests
{
    public class VazamentoControllerTests :
        IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public VazamentoControllerTests(
            WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsHttpStatusCode200()
        {
            var response = await _client.GetAsync("/api/Vazamento");

            response.EnsureSuccessStatusCode();
        }
    }
}