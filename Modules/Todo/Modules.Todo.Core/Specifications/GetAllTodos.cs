using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Todo.Core.Specifications
{
    using BuildingBlock.Specification;
    using Modules.Todo.Core.Entities;
    public class GetAllTodos : ISpecification<Modules.Todo.Core.Entities.TodoAggregate, ITodoSpecificationVisitor>
    {
        public GetAllTodos()
        {
        }
        public void Accept(ITodoSpecificationVisitor visitor) => visitor.Visit(this);

        public bool IsSatisfiedBy(TodoAggregate item) => true;
    }

}
