﻿//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Core.Specifications
{
    /// <summary>
    /// Defines the <see cref="INoteSpecification" />.
    /// </summary>
    public interface ITodoSpecificationVisitor : BuildingBlock.Specification.ISpecificationVisitor<ITodoSpecificationVisitor, Modules.Todo.Core.Entities.TodoAggregate>
    {
        void Visit(TodoById spec);

        void Visit(TodoByState spec);

        void Visit(GetAllTodos spec);

        void Visit(TodoByDescription spec);
    }
}