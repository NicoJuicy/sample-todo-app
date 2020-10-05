//Copyright 2020 - 2020  

namespace Modules.Todo.Application.CQRS.Queries
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using global::AutoMapper;
    using MediatR;
    using Modules.Todo.Application.CQRS.Queries.Dto;
    using Modules.Todo.Core.Repositories;

    /// <summary>
    /// Defines the <see cref="GetDetailedNoteHandler" />.
    /// </summary>
    public class GetTodoHandler : IRequestHandler<GetTodoQuery, TodoResult>
    {
        private readonly IMapper m_mapper;

        private readonly ITodoRepository m_notesRepository;

        public GetTodoHandler(ITodoRepository notesRepository, IMapper mapper)
        {
            m_notesRepository = notesRepository;
            m_mapper = mapper;
        }

        public async Task<TodoResult> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var byIdSpec = new Core.Specifications.TodoById(request.TodoId);
            var items = await m_notesRepository.Get(byIdSpec);

            if (!items.Any())
                throw new NullReferenceException($"Note with {request.TodoId} not found");

            var item = items.SingleOrDefault();

            return m_mapper.Map<TodoResult>(item);
        }
    }

    /// <summary>
    /// Defines the <see cref="GetDetailedNoteQuery" />.
    /// </summary>
    public class GetTodoQuery : IRequest<TodoResult>
    {
        public Guid TodoId { get; set; }
    }
}
