//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Infrastructure.Specifications
{
    using System;
    using System.Linq.Expressions;
    using BuildingBlock.Specification;
    using BuildingBlock.Specification.Visitors;
    using Modules.Todo.Core.Entities;
    using Modules.Todo.Core.Specifications;
    using Modules.Todo.Infrastructure.Documents;

    /// <summary>
    /// Defines the <see cref="NoteSpecificationVisitorPattern" />.
    /// </summary>
    public class TodoSpecificationVisitor : EFExpressionVisitor<TodoDocument, ITodoSpecificationVisitor, Core.Entities.TodoAggregate>, ITodoSpecificationVisitor
    {
        public override Expression<Func<TodoDocument, bool>> ConvertSpecToExpression(ISpecification<TodoAggregate, ITodoSpecificationVisitor> spec)
        {
            spec.Accept(this);
            return this.Expr;
        }

        public void Visit(TodoByState spec) => Expr = expr => expr.IsActive == spec.State;
        public void Visit(TodoByDescription spec) => Expr = expr => expr.Description.Contains(spec.Q);
        public void Visit(TodoById spec) => Expr = expr => expr.Id == spec.Id;
        public void Visit(GetAllTodos spec) => Expr = expr => true;
    }
}
