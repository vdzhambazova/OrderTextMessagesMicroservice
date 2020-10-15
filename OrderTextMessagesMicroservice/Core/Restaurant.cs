using System.ComponentModel.DataAnnotations;

namespace OrderTextMessagesMicroservice
{
    public class Restaurant
    {
        public Restaurant(int id, string name, string cuisine, string location, string deliveryTime)
        {
            this.Id = id;
            this.Name = name;
            this.Cuisine = cuisine;
            this.Location = location;
            this.DeliveryTime = deliveryTime;
        }

        public int Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        public string Cuisine { get; set; }

        public string Location { get; set; }

        [Required, StringLength(10)]
        public string DeliveryTime { get; set; }
    }
}