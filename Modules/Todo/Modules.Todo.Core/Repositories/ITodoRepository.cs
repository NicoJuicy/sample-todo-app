//Copyright 2020 - 2020  

namespace Modules.Todo.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BuildingBlock.Specification;
    using Modules.Todo.Core.Entities;

    /// <summary>
    /// Defines the <see cref="ITodoRepository" />.
    /// </summary>
    public interface ITodoRepository
    {
        Task<TodoAggregate> Get(Guid id);
        Task<IReadOnlyList<Modules.Todo.Core.Entities.TodoAggregate>> Get(ISpecification<TodoAggregate, Modules.Todo.Core.Specifications.ITodoSpecificationVisitor> spec);
        Task Update(TodoAggregate item);
        Task Save(TodoAggregate item);
        Task Delete(TodoAggregate item);
    }
}
