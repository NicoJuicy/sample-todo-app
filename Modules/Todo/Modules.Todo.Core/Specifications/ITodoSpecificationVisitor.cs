//Copyright 2020 - 2020  

namespace Modules.Todo.Core.Specifications
{
    /// <summary>
    /// Defines the <see cref="INoteSpecification" />.
    /// </summary>
    public interface ITodoSpecificationVisitor : BuildingBlock.Specification.ISpecificationVisitor<ITodoSpecificationVisitor, Modules.Todo.Core.Entities.TodoAggregate>
    {
        void Visit(TodoById spec);

        void Visit(TodoByCompletedState spec);

        void Visit(GetAllTodos spec);

        void Visit(TodoByDescription spec);
    }
}
