using Microsoft.AspNetCore.Mvc.Testing;

namespace AquaSenseAPI.Tests
{
    public class RelatorioControllerTests :
        IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public RelatorioControllerTests(
            WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsHttpStatusCode200()
        {
            var response =
                await _client.GetAsync("/api/Relatorio/dashboard");

            response.EnsureSuccessStatusCode();
        }
    }
}