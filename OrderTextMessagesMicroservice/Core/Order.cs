using System.ComponentModel.DataAnnotations;

namespace OrderTextMessagesMicroservice.Core
{
    public class Order
    {
        public Order(string restaurantName, string deliveryTime, string customerPhoneNumber)
        {
            this.RestaurantName = restaurantName;
            this.DeliveryTime = deliveryTime;
            this.CustomerPhoneNumber = customerPhoneNumber;
        }

        [Required, StringLength(30)]
        public string RestaurantName { get; set; }

        [Required, StringLength(10)]
        public string DeliveryTime { get; set; }

        [Required, StringLength(15)]
        public string CustomerPhoneNumber { get; set; }
    }
}
