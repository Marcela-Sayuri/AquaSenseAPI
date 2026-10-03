using Microsoft.AspNetCore.Mvc.Testing;

namespace AquaSenseAPI.Tests
{
    public class ConsumoControllerTests :
        IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ConsumoControllerTests(
            WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsHttpStatusCode200()
        {
            var response = await _client.GetAsync("/api/Consumo");

            response.EnsureSuccessStatusCode();
        }
    }
}