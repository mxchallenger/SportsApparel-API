using Catalyte.Apparel.Data.SeedData;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Test.Integration.Utilities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Integration
{
    [Collection("Sequential")]
    public class ProductIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        private readonly ProductFactory _factory;

        private readonly List<string> _categories;

        private readonly List<string> _types;

        public ProductIntegrationTests(CustomWebApplicationFactory testFactory)
        {
            _factory = new ProductFactory();
            _categories = _factory._categories;
            _types = _factory._types;
            _client = testFactory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetProducts_Returns200()
        {
            var response = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProductById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/products/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<ProductDTO>();
            Assert.Equal(1, content.Id);
        }
        [Fact]
        public async Task GetProductById_GivenNonexistentId_Throws404()
        {
            var response = await _client.GetAsync("/products/1005");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetAllUniqueCategories_Returns200()
        {
            var response = await _client.GetAsync("/products/categories");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<string>>();
            var expected = _categories.Count;
            var actual = content.Count;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task GetAllUniqueTypes_Returns200()
        {
            var response = await _client.GetAsync("/products/types");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<string>>();
            var expected = _types.Count;
            var actual = content.Count;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task GetProductsByAllFiltersAsync_Returns200AndCorrectPropertyValues()
        {
            var response = await _client.GetAsync("/products/filters/?brand=Nike&category=Baseball");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            var expected = "Nike";
            var result = content.Find(delegate (ProductDTO product)
            {
                return product.Brand == "Nike" && product.Category == "Baseball";
            });
            var actual = result.Brand;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public async Task GetProductsByAllFiltersAsync_Returns400IfMinIsGreaterThanMax()
        {
            var response = await _client.GetAsync("/products/filters/?min=50&max=40");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task GetActiveProductsAsync_Returns200AndActive()
        {
            var response = await _client.GetAsync("/products/active");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<ProductDTO>>();
            var expected = true;
            var result = content.Find(delegate (ProductDTO product)
            {
                return product.Active == true;
            });
            var actual = result.Active;
            Assert.Equal(expected, actual);
        }
    }
}
