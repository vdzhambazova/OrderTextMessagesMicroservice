using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrderTextMessagesMicroservice.Controllers;
using OrderTextMessagesMicroservice.Core;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace OrderTextMessagesMicroservice.Test
{
    public class MessagesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }

        public MessagesControllerTests(WebApplicationFactory<Startup> fixture)
        {
            this.Client = fixture.CreateClient();
            
        }

        [Fact]
        public async Task GetShouldRertrieveLogs()
        {
            var response = await Client.GetAsync("/messages");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var messages = JsonConvert.DeserializeObject<Message[]>(await response.Content.ReadAsStringAsync());
            var hummusBarMessage = new Message("Thank you for ordering from Hummus bar! You will recieve your order in 45 min.", "0");

            Assert.Equal(JsonConvert.SerializeObject(hummusBarMessage), JsonConvert.SerializeObject(messages[0]));
        }

        [Fact]
        public async Task PostShouldRertrieveLogs()
        {
            var order = new Order("Mr Pizza", "45 min", "359886099277");
            var orderJson = JsonConvert.SerializeObject(order);
            var buffer = System.Text.Encoding.UTF8.GetBytes(orderJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await Client.PostAsync("/messages", byteContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
