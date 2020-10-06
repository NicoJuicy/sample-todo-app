using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Todo.Infrastructure.Sql.Entity
{

    public class Todo
    {

        public string Description { get; set; }

        public DateTime? CompletedOn { get; set; }

        [Key]
        public Guid Id { get; set; }

        [Index()]
        public bool IsCompleted { get; set; }

        public DateTime On { get; set; }
    }
}
