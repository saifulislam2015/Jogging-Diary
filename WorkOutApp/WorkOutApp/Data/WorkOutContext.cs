using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkOutApp.Models
{
    public class WorkOutContext : DbContext
    {
        public WorkOutContext (DbContextOptions<WorkOutContext> options)
            : base(options)
        {
        }

        public DbSet<WorkOutApp.Models.WorkOut> WorkOut { get; set; }
    }
}
