using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestAPIaWEBaASP.Data
{
    public interface ImessageDB
    {
        DbSet<MessageDB> MessageDB { get; set; }

        Task<int> SaveChangesAsync();

    }
}
