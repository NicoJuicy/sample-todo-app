//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

namespace Modules.Todo.Api.Mapper
{
    using global::AutoMapper;

    /// <summary>
    /// Defines the <see cref="NoteProfile" />.
    /// </summary>
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            var map = CreateMap<Application.CQRS.Queries.Dto.TodoResult, Api.Dto.TodoDto>();
            map.ReverseMap();
        }
    }
}
