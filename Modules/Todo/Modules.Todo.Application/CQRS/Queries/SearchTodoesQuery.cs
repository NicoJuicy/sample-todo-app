//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Application.CQRS.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using BuildingBlock.Specification;
    using BuildingBlock.Specification.Extensions;
    using global::AutoMapper;
    using MediatR;
    using Modules.Todo.Application.CQRS.Queries.Dto;
    using Modules.Todo.Core.Repositories;
    using Modules.Todo.Core.Specifications;

    /// <summary>
    /// Defines the <see cref="GetActiveNotesHandler" />.
    /// </summary>
    public class SearchTodoesHandler : IRequestHandler<SearchTodoesQuery, IReadOnlyList<TodoResult>>
    {
        private readonly IMapper m_mapper;

        private readonly ITodoRepository m_notesRepository;

        public SearchTodoesHandler(ITodoRepository notesRepository, IMapper mapper)
        {
            m_notesRepository = notesRepository;
            m_mapper = mapper;
        }

        public async Task<IReadOnlyList<TodoResult>> Handle(SearchTodoesQuery request, CancellationToken cancellationToken)
        {

            ISpecification<Modules.Todo.Core.Entities.TodoAggregate, ITodoSpecificationVisitor> filter;

            if (!request.State.HasValue)
            {
                filter = new Core.Specifications.GetAllTodos();
            }
            else
            {
                filter = new Core.Specifications.TodoByState(request.State.Value);
            }

            if (!string.IsNullOrEmpty(request.Q))
            {
                filter = filter.And(new Core.Specifications.TodoByDescription(request.Q));
            }


            var items = await m_notesRepository.Get(filter);

            return m_mapper.Map<IReadOnlyList<TodoResult>>(items);
        }
    }

    /// <summary>
    /// Defines the <see cref="GetNotesByStateQuery" />.
    /// </summary>
    public class SearchTodoesQuery : IRequest<IReadOnlyList<TodoResult>>
    {
        public SearchTodoesQuery(bool? state, string q)
        {
            State = state;
            Q = q;
        }

        public bool? State { get; private set; }
        public string Q { get; private set; }
    }
}
