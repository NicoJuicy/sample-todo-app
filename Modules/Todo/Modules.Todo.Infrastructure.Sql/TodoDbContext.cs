using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Todo.Infrastructure.Sql
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext() : base("DefaultConnection")
        {

        }
        public TodoDbContext(string connString) : base(connString)
        {

        }
        public DbSet<Entity.Todo> Todos { get; set; }
    }
}
