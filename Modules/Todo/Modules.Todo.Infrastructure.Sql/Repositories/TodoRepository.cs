using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BuildingBlock.Specification;
using Modules.Todo.Core.Entities;
using Modules.Todo.Core.Repositories;
using Modules.Todo.Core.Specifications;

namespace Modules.Todo.Infrastructure.Sql.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext m_dbContext;
        private readonly IMapper m_mapper;
        private readonly Specifications.TodoSpecificationVisitor m_specVisitor;

        public TodoRepository(TodoDbContext dbContext, IMapper mapper)
        {
            m_dbContext = dbContext;
            m_mapper = mapper;
            m_specVisitor = new Specifications.TodoSpecificationVisitor();
        }
        public async Task Delete(TodoAggregate item)
        {
            var entity = m_dbContext.Todos.Where(dl => dl.Id == item.Id).FirstOrDefault();
            m_dbContext.Todos.Remove(entity);

            await m_dbContext.SaveChangesAsync();
        }

        public async Task<TodoAggregate> Get(Guid id)
        {
            var entity = await m_dbContext.Todos.AsNoTracking().Where(dl => dl.Id == id).FirstOrDefaultAsync();
            return m_mapper.Map<TodoAggregate>(entity);
        }

        public async Task<IReadOnlyList<TodoAggregate>> Get(ISpecification<TodoAggregate, ITodoSpecificationVisitor> spec)
        {
            var expr = m_specVisitor.ConvertSpecToExpression(spec);

            var items = await m_dbContext.Todos.AsNoTracking().Where(expr).ToListAsync();
            return m_mapper.Map<List<TodoAggregate>>(items.OrderBy(dl => dl.On).ToList());
        }

        public async Task Save(TodoAggregate item)
        {
            var entity = m_mapper.Map<Entity.Todo>(item);
            m_dbContext.Todos.Add(entity);
            await m_dbContext.SaveChangesAsync();
        }

        public async Task Update(TodoAggregate item)
        {
            var entity = m_mapper.Map<Entity.Todo>(item);
            var originalEntity = await m_dbContext.Todos.FindAsync(entity.Id);
            m_dbContext.Entry<Entity.Todo>(originalEntity).CurrentValues.SetValues(entity);
    
            await m_dbContext.SaveChangesAsync();
        }
    }
}
