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
        public TodoDbContext() : base("Data Source=DESKTOP-JH34EEG\\SQLEXPRESS;Initial Catalog=Temp.Todo;Integrated Security=True")//"DefaultConnection")
        {

        }
        public TodoDbContext(string connString) : base(connString)
        {

        }
        public DbSet<Entity.Todo> Todos { get; set; }
    }
}
