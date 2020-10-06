//Copyright 2020 - 2020  

namespace Modules.Todo.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BuildingBlock.Specification;
    using Modules.Todo.Core.Entities;

    /// <summary>
    /// Defines the <see cref="ISqlTodoRepository" />.
    /// </summary>
    public interface ISqlTodoRepository
    {
        Task Delete(Guid id);

        Task<TodoAggregate> Get(Guid id);
        Task<IReadOnlyList<Modules.Todo.Core.Entities.TodoAggregate>> Get(ISpecification<TodoAggregate, Modules.Todo.Core.Specifications.ITodoSpecificationVisitor> spec);
        Task Save(TodoAggregate item);
        Task Delete(TodoAggregate item);

        //Task Update(TodoAggregate item);

        Task<bool> UpdateCompletedState(Guid id, bool completedState);
        Task<bool> UpdateDescription(Guid id, string description);
    }
}
