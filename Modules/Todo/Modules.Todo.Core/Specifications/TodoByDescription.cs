using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Todo.Core.Specifications
{
    using BuildingBlock.Specification;
    using Modules.Todo.Core.Entities;

    /// <summary>
    /// Defines the <see cref="TodoByState" />.
    /// </summary>
    public class TodoByDescription : ISpecification<Modules.Todo.Core.Entities.TodoAggregate, ITodoSpecificationVisitor>
    {
        public TodoByDescription(string q)
        {
            Q = q;
        }
        public string Q { get; private set; }
        public void Accept(ITodoSpecificationVisitor visitor) => visitor.Visit(this);

        public bool IsSatisfiedBy(TodoAggregate item) => item.Description.Contains(Q);
    }
}
