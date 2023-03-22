using Application.Models.Dto;
using AutoMapper;
using Domain;

namespace Application.Helpers.Mappers
{
    internal class QuestionMapper : Profile
    {
        public QuestionMapper()
        {
            CreateMap<InputDto, InputQuestion>()
                .ForMember(m => m.InputType,
                    src => src.MapFrom(s => s.Type.ToEnum<InputType>()));

            CreateMap<SelectDto, SelectQuestion>()
                .ForMember(m => m.Options,
                    src => src.MapFrom(s => s.Options.Aggregate(
                        (a, b) => a + ";" + b)))
                .ForMember(m => m.SelectType,
                    src => src.MapFrom(s => s.Type.ToEnum<SelectType>()));
        }
    }
}
