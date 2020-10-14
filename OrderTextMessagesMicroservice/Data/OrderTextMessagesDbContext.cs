using Microsoft.EntityFrameworkCore;

namespace OrderTextMessagesMicroservice.Data
{
    public class OrderTextMessagesDbContext : DbContext
    {
        public OrderTextMessagesDbContext(DbContextOptions<OrderTextMessagesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
