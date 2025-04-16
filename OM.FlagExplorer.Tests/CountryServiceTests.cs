using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace OM.FlagExplorer.Tests
{
    [TestClass]
    public sealed class CountryServiceTests
    {
        private readonly HttpClient _httpClient;

        public CountryServiceTests()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public async Task GetAllCountries_ReturnsSuccessAndList()
        {
            // Arrange
            var url = "https://localhost:7157/api/countries";

            // Act
            var response = await _httpClient.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(!string.IsNullOrWhiteSpace(content), "Response content should not be empty");

            var countries = JsonSerializer.Deserialize<object[]>(content);
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Length > 0, "Country list should not be empty");
        }
    }
}
