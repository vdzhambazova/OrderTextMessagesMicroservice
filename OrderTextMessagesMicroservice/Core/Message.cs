using System.ComponentModel.DataAnnotations;

namespace OrderTextMessagesMicroservice.Core
{
    public class Message
    {
        public Message(string textMessage, string statusCode)
        {
            TextMessage = textMessage;
            StatusCode = statusCode;
        }

        public int Id { get; set; }

        [Required, StringLength(200)]
        public string TextMessage { get; set; }

        [Required]
        public string StatusCode { get; set; }
    }
}
