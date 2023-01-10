using Application.Calls.Forms.Create;
using AutoMapper;
using Domain;

namespace Application.Helpers.Mappers
{
    internal class FormMapper : Profile
    {
        public FormMapper()
        {
            CreateMap<CreateFormCommand, Form>()
                .ForMember(x => x.InputQuestions, src => src.Ignore())
                .ForMember(x => x.SelectQuestions, src => src.Ignore())
                .ForMember(x => x.DateCreated, src => src.MapFrom(
                    s => DateTimeOffset.Now));
        }
    }
}
