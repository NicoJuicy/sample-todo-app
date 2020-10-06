//Copyright 2020 - 2020  

namespace Modules.Todo.Core.Specifications
{
    using BuildingBlock.Specification;
    using Modules.Todo.Core.Entities;

    /// <summary>
    /// Defines the <see cref="TodoByCompletedState" />.
    /// </summary>
    public class TodoByCompletedState : ISpecification<Modules.Todo.Core.Entities.TodoAggregate, ITodoSpecificationVisitor>
    {
        public TodoByCompletedState(bool completedState)
        {
            CompletedState = completedState;
        }
        public bool CompletedState { get; private set; }
        public void Accept(ITodoSpecificationVisitor visitor) => visitor.Visit(this);

        public bool IsSatisfiedBy(TodoAggregate item) => item.IsCompleted == CompletedState;
    }
}
