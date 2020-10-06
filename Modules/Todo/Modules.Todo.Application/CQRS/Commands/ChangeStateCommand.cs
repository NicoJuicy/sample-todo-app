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

    public class ChangeStateCommand : IRequest
    {

        public ChangeStateCommand(Guid id, bool activeState)
        {
            Id = id;
            ActiveState = activeState;

        }
        public Guid Id { get; }
        public bool ActiveState { get; }
    }

    public class ChangeStateHandler : IRequestHandler<ChangeStateCommand, Unit>
    {
        private readonly ITodoRepository m_repo;
        private readonly IMediator m_mediator;

        public ChangeStateHandler(ITodoRepository repo, IMediator mediator)
        {
            m_repo = repo;
            m_mediator = mediator;
        }

        public async Task<Unit> Handle(ChangeStateCommand request, CancellationToken cancellationToken)
        {

            var entity = await m_repo.Get(request.Id);
            if (request.ActiveState)
            {
                entity.Open();
            }
            else
            {
                entity.Complete();
            }

            await m_repo.Update(entity);

            entity.Events.ToList().ForEach(e => m_mediator.Publish(e));
            entity.ClearEvents();

            return new Unit();
        }
    }

}
