using MediatR;
using Modules.Todo.Application.CQRS.Queries;
using Modules.Todo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modules.Todo.Application.CQRS.Commands
{

    public class ChangeCompletedStateCommand : IRequest
    {

        public ChangeCompletedStateCommand(Guid id, bool completedState)
        {
            Id = id;
            CompletedState = completedState;

        }
        public Guid Id { get; }
        public bool CompletedState { get; }
    }

    public class ChangeCompletedStateHandler : IRequestHandler<ChangeCompletedStateCommand, Unit>
    {
        private readonly ITodoRepository m_repo;
        private readonly IMediator m_mediator;

        public ChangeCompletedStateHandler(ITodoRepository repo, IMediator mediator)
        {
            m_repo = repo;
            m_mediator = mediator;
        }

        public async Task<Unit> Handle(ChangeCompletedStateCommand request, CancellationToken cancellationToken)
        {

            var entity = await m_repo.Get(request.Id);
            if (request.CompletedState)
            {
                entity.Complete();
            }
            else
            {
                entity.Open();
            }

            await m_repo.Update(entity);

            entity.Events.ToList().ForEach(e => m_mediator.Publish(e));
            entity.ClearEvents();

            return new Unit();
        }
    }

}
