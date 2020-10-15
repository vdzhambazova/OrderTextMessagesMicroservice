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

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> Get()
        {
            return await this.context.Messages.ToListAsync();
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetLast50Messages()
        {
            var result = await this.context.Messages.ToListAsync();
            return Ok(result.Skip(Math.Max(0, result.Count() - 50)));
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<ActionResult<Message>> Post(Message message)
        {
            if (ModelState.IsValid)
            {
                this.context.Messages.Add(message);
                await this.context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), message);
            }

            return BadRequest();
        }
    }
}
