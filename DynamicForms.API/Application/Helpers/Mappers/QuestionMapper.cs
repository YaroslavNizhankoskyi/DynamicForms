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
                .ForMember(m => m.Type,
                    src => src.MapFrom(s => MapInputType(s.Type)));

            CreateMap<SelectDto, SelectQuestion>()
                .ForMember(m => m.Options,
                    src => src.MapFrom(s => s.Options.Aggregate(
                        (a, b) => a + ";" + b)));
        }

        public static InputType MapInputType(string value)
        {
            var inputType = value.Replace("Input", "");

            return inputType.ToEnum<InputType>(); ;
        }
    }
}
