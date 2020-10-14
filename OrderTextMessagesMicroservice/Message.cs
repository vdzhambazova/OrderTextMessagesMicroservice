using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderTextMessagesMicroservice
{
    public class Message
    {
        public Message(string restaurantName, string deliveryTime)
        {
            this.RestaurantName = restaurantName;
            this.DeliveryTime = deliveryTime;
        }

        public int Id { get; set; }

        public string RestaurantName { get; set; }

        public string DeliveryTime { get; set; }
    }
}
