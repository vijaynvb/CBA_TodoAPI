using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

//using Microsoft.EntityFrameworkCore;
using TodoAPI.DTO;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    // instead of entityframeworkcore dbcontext, use IdentityDbContext
    public class TodoDBContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = TodoDb; Trusted_Connection = True; MultipleActiveResultSets = true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<TodoAPI.Models.Todo> Todo { get; set; } = default!;

    }
}
