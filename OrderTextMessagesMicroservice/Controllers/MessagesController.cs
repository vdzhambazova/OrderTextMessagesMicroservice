using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderTextMessagesMicroservice.Data;

namespace OrderTextMessagesMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly OrderTextMessagesDbContext context;

        public MessagesController(OrderTextMessagesDbContext context)
        {
            this.context = context;
        }

        // GET: /messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> Get()
        {
            return await this.context.Messages.ToListAsync();
        }

        // GET: /messages
        [HttpGet]
        [Route("log")]
        public async Task<ActionResult<IEnumerable<Message>>> GetLog()
        {
            var result = await this.context.Messages.ToListAsync();
            return this.Ok(result.Skip(Math.Max(0, result.Count() - 50)));
        }

        // POST: /messages
        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message message)
        {
            if (ModelState.IsValid)
            {
                this.context.Messages.Add(message);
                await this.context.SaveChangesAsync();

                return this.CreatedAtAction(nameof(Get), message);
            }

            return this.BadRequest();
        }
    }
}
