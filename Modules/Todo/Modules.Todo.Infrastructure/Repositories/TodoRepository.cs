//Copyright 2020 - 2020 Nico Sap 

namespace Modules.Todo.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BuildingBlock.Specification;
    using Marten;
    using Marten.Linq.SoftDeletes;
    using Modules.Todo.Core.Entities;
    using Modules.Todo.Core.Repositories;
    using Modules.Todo.Core.Specifications;

    /// <summary>
    /// Defines the <see cref="TodoRepository" />.
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        private readonly IMapper m_mapper;

        private readonly Specifications.TodoSpecificationVisitor m_specVisitor;

        private readonly IDocumentSession m_session;

        public TodoRepository(IDocumentStore documentStore, IDocumentSession session, IMapper mapper)
        {
            m_mapper = mapper;
            m_session = session;
            m_specVisitor = new Specifications.TodoSpecificationVisitor();
        }

        public async Task Delete(TodoAggregate item)
        {
            var _item = m_mapper.Map<Documents.TodoDocument>(item);

            m_session.Delete(_item);
            await m_session.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TodoAggregate>> Get(ISpecification<TodoAggregate, ITodoSpecificationVisitor> spec)
        {
            var expr = m_specVisitor.ConvertSpecToExpression(spec);

            var items = await m_session.Query<Documents.TodoDocument>().Where(expr).ToListAsync();
            return m_mapper.Map<List<TodoAggregate>>(items.OrderBy(dl => dl.On).ToList());
        }

        public async Task<TodoAggregate> Get(Guid id)
        {
            var item = await m_session.Query<Documents.TodoDocument>().FirstOrDefaultAsync(el => el.Id == id);
            return m_mapper.Map<TodoAggregate>(item);
        }

        public async Task Save(TodoAggregate item)
        {
            var _item = m_mapper.Map<Documents.TodoDocument>(item);
            m_session.Store<Documents.TodoDocument>(_item);
            await m_session.SaveChangesAsync();
        }

        public async Task Update(TodoAggregate item)
        {
            var _item = m_mapper.Map<Documents.TodoDocument>(item);
            m_session.Update<Documents.TodoDocument>(_item);
            await m_session.SaveChangesAsync();
        }

    }
}
