//Copyright 2020 - 2020 Nico Sap - <nico@sapico.me>

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
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => new AggregateId( src.Id)))
                .ForMember(dst => dst.On, opt => opt.MapFrom(src => src.On))
                .ForMember(dst => dst.FinishedOn, opt => opt.MapFrom(src => src.FinishedOn))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.IsActive, opt => opt.MapFrom(src => src.IsActive));


            CreateMap<Core.Entities.TodoAggregate, Documents.TodoDocument>()
               .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id.Value))
               .ForMember(dst => dst.On, opt => opt.MapFrom(src => src.On))
               .ForMember(dst => dst.FinishedOn, opt => opt.MapFrom(src => src.FinishedOn))
               .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dst => dst.IsActive, opt => opt.MapFrom(src => src.IsActive));

        }
    }
}
