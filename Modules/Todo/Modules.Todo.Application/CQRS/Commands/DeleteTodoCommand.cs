//Copyright 2020 - 2020  

namespace Modules.Todo.Application.CQRS.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Modules.Todo.Core.Repositories;

    /// <summary>
    /// Defines the <see cref="DeleteTodoCommand" />.
    /// </summary>
    public class DeleteTodoCommand : IRequest<bool>
    {
        public DeleteTodoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    /// <summary>
    /// Defines the <see cref="DeleteTodoHandler" />.
    /// </summary>
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, bool>
    {
        private readonly IMediator m_mediator;

        private readonly ITodoRepository m_repo;

        public DeleteTodoHandler(ITodoRepository repo, IMediator mediator)
        {
            m_repo = repo;
            m_mediator = mediator;
        }

        public async Task<bool> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = await m_repo.Get(request.Id);

            await m_repo.Delete(entity);

            return true;
        }
    }
}
