//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Core.Specifications
{
    using System;
    using BuildingBlock.Specification;
    using Modules.Todo.Core.Entities;

    /// <summary>
    /// Defines the <see cref="NoteById" />.
    /// </summary>
    public class TodoById : ISpecification<TodoAggregate, ITodoSpecificationVisitor>
    {
        public TodoById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public void Accept(ITodoSpecificationVisitor visitor) => visitor.Visit(this);

        public bool IsSatisfiedBy(TodoAggregate item) => item.Id == Id;
    }
}
