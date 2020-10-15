using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderTextMessagesMicroservice.Core;
using OrderTextMessagesMicroservice.Data;
using OrderTextMessagesMicroservice.NexmoSmsApi;

namespace OrderTextMessagesMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderTextMessagesDbContext context;

        public OrdersController(OrderTextMessagesDbContext context)
        {
            this.context = context;
        }

        // GET: /orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetLog()
        {
            var result = await this.context.Messages.ToListAsync();
            var errors = result.Where(x => x.StatusCode != "0");
            var messages = result.Skip(Math.Max(0, result.Count() - 50));

            var logMessages = new Logs(errors, messages);
            return this.Ok(logMessages);
        }

        // POST: /orders
        [HttpPost]
        public async Task<ActionResult<Message>> Post(Order order)
        {
            if (ModelState.IsValid)
            {
                var message = SmsSender.Execute(order.RestaurantName, order.DeliveryTime, order.CustomerPhoneNumber);
                this.context.Messages.Add(message);
                await this.context.SaveChangesAsync();

                return this.CreatedAtAction(nameof(GetLog), message);

            }

            return this.BadRequest();
        }
    }
}
