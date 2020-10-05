//Copyright 2020 - 2020  

namespace Modules.Todo.Core.Specifications
{
    using BuildingBlock.Specification;
    using Modules.Todo.Core.Entities;

    /// <summary>
    /// Defines the <see cref="TodoByState" />.
    /// </summary>
    public class TodoByState : ISpecification<Modules.Todo.Core.Entities.TodoAggregate, ITodoSpecificationVisitor>
    {
        public TodoByState(bool state)
        {
            State = state;
        }
        public bool State { get; private set; }
        public void Accept(ITodoSpecificationVisitor visitor) => visitor.Visit(this);

        public bool IsSatisfiedBy(TodoAggregate item) => item.IsActive == State;
    }
}
