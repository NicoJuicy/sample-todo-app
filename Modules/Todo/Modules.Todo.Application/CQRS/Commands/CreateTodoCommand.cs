//Copyright 2020 - 2020  

namespace Modules.Todo.Application.CQRS.Commands
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using MediatR;
    using Modules.Todo.Application.CQRS.Queries.Dto;
    using Modules.Todo.Core.Entities;
    using Modules.Todo.Core.Repositories;

    /// <summary>
    /// Defines the <see cref="DeleteTodoCommand" />.
    /// </summary>
    public class CreateTodoCommand : IRequest<TodoResult>
    {
        public CreateTodoCommand(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="DeleteTodoHandler" />.
    /// </summary>
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, TodoResult>
    {
        private readonly IMapper m_mapper;

        private readonly IMediator m_mediator;

        private readonly ITodoRepository m_repo;

        public CreateTodoHandler(ITodoRepository repo, IMediator mediator, IMapper mapper)
        {
            m_repo = repo;
            m_mediator = mediator;
            m_mapper = mapper;
        }

        public async Task<TodoResult> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var entity = TodoAggregate.Create(request.Description);
            await m_repo.Save(entity);

            entity.Events.ToList().ForEach(e => m_mediator.Publish(e));
            entity.ClearEvents();


            return m_mapper.Map<TodoResult>(entity);
        }
    }
}
