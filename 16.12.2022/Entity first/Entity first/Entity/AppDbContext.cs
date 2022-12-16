using Entity_first.Core.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_first.Entity
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SOO30PD;Database=CodeFirstDb;Trusted_Connection=True;");
        }

        public DbSet<Employee> employees { get; set; }
    }
}
