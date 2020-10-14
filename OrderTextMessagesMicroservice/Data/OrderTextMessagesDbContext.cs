using Microsoft.EntityFrameworkCore;

namespace OrderTextMessagesMicroservice.Data
{
    public class OrderTextMessagesDbContext : DbContext
    {
        public OrderTextMessagesDbContext(DbContextOptions<OrderTextMessagesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
    }
}
