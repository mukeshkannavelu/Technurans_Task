using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace Technurans_Task.Models.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>opts):base(opts)
        {
                
        }
        public DbSet<Task> Employee_Details { get; set; }
    }
}
