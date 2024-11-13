using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext (DbContextOptions<TodoDBContext> options)
            : base(options)
        {
        }

        public DbSet<TodoAPI.Models.Todo> Todo { get; set; } = default!;

        public DbSet<TodoAPI.Models.User>? User { get; set; }
    }
}
