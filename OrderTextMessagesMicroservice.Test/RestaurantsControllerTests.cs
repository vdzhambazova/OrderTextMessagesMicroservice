using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using OrderTextMessagesMicroservice.Core;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;


namespace OrderTextMessagesMicroservice.Test
{
    public class RestaurantControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }

        public RestaurantControllerTests(WebApplicationFactory<Startup> fixture)
        {
            this.Client = fixture.CreateClient();
        }

        [Fact]
        public async Task GetShouldRertrieveRestaurants()
        {
            var response = await Client.GetAsync("/restaurants");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var restaurants = JsonConvert.DeserializeObject<Restaurant[]>(await response.Content.ReadAsStringAsync());
            var pizzaLabRestaurant = new Restaurant(1, "Pizza Lab", "italian", "ul Graf Ingatiev", "10 min");

            Assert.Equal(JsonConvert.SerializeObject(pizzaLabRestaurant), JsonConvert.SerializeObject(restaurants[0]));
            Assert.Equal(6, restaurants.Length);
        }
    }
}