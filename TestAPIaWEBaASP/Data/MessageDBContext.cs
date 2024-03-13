using Microsoft.EntityFrameworkCore;

namespace TestAPIaWEBaASP.Data
{
    public class MessageDBContext: DbContext, ImessageDB
    {
        public MessageDBContext(DbContextOptions<MessageDBContext> options)
           : base(options)
        {
        }

        public DbSet<MessageDB> MessageDB { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
