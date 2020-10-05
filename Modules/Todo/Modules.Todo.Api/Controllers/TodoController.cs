//Copyright 2020 - 2020  

namespace Modules.Todo.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;
    using AutoMapper;
    using MediatR;
    using Modules.Todo.Api.Dto;

    /// <summary>
    /// Defines the <see cref="TodoController" />.
    /// </summary>
    //[RoutePrefix("api/todos")]

    public class TodoController : ApiController
    {
        private readonly IMapper m_mapper;

        private readonly IMediator m_mediator;

        public TodoController(IMediator mediator, IMapper mapper)
        {
            m_mediator = mediator;
            m_mapper = mapper;
        }
        [HttpGet]
        [Route("api/todo/list")]
        public async Task<List<Dto.TodoDto>> Index(bool? isActive = null, string q = null)
        {
            var request = new Modules.Todo.Application.CQRS.Queries.SearchTodoesQuery(isActive, q);
            var items = await m_mediator.Send(request);

            var response = m_mapper.Map<List<Dto.TodoDto>>(items);

            return response;
        }

        [HttpPut]
        [Route("api/todo/close")]
        public async Task<bool> Close(Guid id)
        {
            try
            {
                var request = new Modules.Todo.Application.CQRS.Commands.ChangeStateCommand(id, false);
                await m_mediator.Send(request);

                return true;

            }
            catch (Exception ex)
            {
                //Logging
                return false;
            }
        }

        [Route("api/todo/create")]
        [HttpPost]
        public async Task<Dto.TodoDto> Create(CreateTodoDto data)
        {
            var request = new Modules.Todo.Application.CQRS.Commands.CreateTodoCommand(data.Description);
            var response = await m_mediator.Send(request);

            return m_mapper.Map<Dto.TodoDto>(response);
        }

        [HttpDelete]
        [Route("api/todo/delete")]
        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var request = new Modules.Todo.Application.CQRS.Commands.DeleteTodoCommand(id);
                await m_mediator.Send(request);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                return false;
            }
        }



        [HttpPut]
        [Route("api/todo/open")]
        public async Task<bool> Open(Guid id)
        {
            try
            {
                var request = new Modules.Todo.Application.CQRS.Commands.ChangeStateCommand(id, true);
                await m_mediator.Send(request);

                return true;
            }
            catch (Exception ex)
            {
                //Logging
                return false;
            }
        }
    }
}
