using System.ComponentModel.DataAnnotations;

namespace OrderTextMessagesMicroservice
{
    public class Message
    {
        public int Id { get; set; }

        [Required, StringLength(30)]
        public string RestaurantName { get; set; }

        [Required, StringLength(10)]
        public string DeliveryTime { get; set; }
    }
}
