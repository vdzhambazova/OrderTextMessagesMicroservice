using System.Collections.Generic;

namespace OrderTextMessagesMicroservice.Core
{
    public class Logs
    {
        public Logs(IEnumerable<Message> errors, IEnumerable<Message> messages)
        {
            this.Errors = errors;
            this.Messages = messages;
        }

        public IEnumerable<Message> Errors { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
