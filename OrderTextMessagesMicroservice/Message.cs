using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required, StringLength(30)]
        public string RestaurantName { get; set; }

        [Required, StringLength(10)]
        public string DeliveryTime { get; set; }
    }
}
