using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests
{
    public class LibraryControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;
        private readonly WebApplicationFactory<Startup> _factory;

        public LibraryControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = factory.CreateClient();
            
        }

        //[Fact]
        //public async Task BasicTest()
        //{
        //    return Task<>
        //}


    }
}
