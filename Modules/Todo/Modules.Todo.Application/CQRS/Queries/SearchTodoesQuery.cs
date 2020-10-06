//Copyright 2020 - 2020  

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

            if (!request.CompletedState.HasValue)
            {
                filter = new Core.Specifications.GetAllTodos();
            }
            else
            {
                filter = new Core.Specifications.TodoByCompletedState(request.CompletedState.Value);
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
        public SearchTodoesQuery(bool? completedState, string q)
        {
            CompletedState = completedState;
            Q = q;
        }

        public bool? CompletedState { get; private set; }
        public string Q { get; private set; }
    }
}
