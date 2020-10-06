//Copyright 2020 - 2020  

namespace Modules.Todo.Infrastructure.Mapper
{
    using BuildingBlock.Domain.Aggregate;
    using global::AutoMapper;

    /// <summary>
    /// Defines the <see cref="TodoProfile" />.
    /// </summary>
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Documents.TodoDocument, Core.Entities.TodoAggregate>()
           .ForMember(dst => dst.Id, opt => opt.MapFrom(src => new AggregateId(src.Id)))
           .ForMember(dst => dst.On, opt => opt.MapFrom(src => src.On))
           .ForMember(dst => dst.CompletedOn, opt => opt.MapFrom(src => src.CompletedOn))
           .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dst => dst.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted));


            CreateMap<Core.Entities.TodoAggregate, Documents.TodoDocument>()
               .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id.Value))
               .ForMember(dst => dst.On, opt => opt.MapFrom(src => src.On))
               .ForMember(dst => dst.CompletedOn, opt => opt.MapFrom(src => src.CompletedOn))
               .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dst => dst.IsCompleted, opt => opt.MapFrom(src => src.IsCompleted));

        }
    }
}
