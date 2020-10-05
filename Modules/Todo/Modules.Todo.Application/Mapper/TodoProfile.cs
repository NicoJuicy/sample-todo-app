//Copyright 2020 - 2020  

namespace Modules.Todo.Application.Mapper
{
    using global::AutoMapper;

    /// <summary>
    /// Defines the <see cref="NoteProfile" />.
    /// </summary>
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            var map = CreateMap<Core.Entities.TodoAggregate, CQRS.Queries.Dto.TodoResult>()
                 .ForMember(el => el.Id, opt => opt.MapFrom(src => src.Id.Value))
                 .ForMember(el => el.IsActive, opt => opt.MapFrom(src => src.IsActive))
                 .ForMember(el => el.On, opt => opt.MapFrom(src => src.On))
                 .ForMember(el => el.Description, opt => opt.MapFrom(src => src.Description));

            map.ReverseMap();
        }
    }
}
