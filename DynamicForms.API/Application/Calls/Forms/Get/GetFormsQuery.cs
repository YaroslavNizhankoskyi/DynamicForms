using Application.Interfaces;
using Application.Models.Dto;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Calls.Forms.Get
{
    public record GetFormsQuery() : IRequest<List<FormDetails>>;
    
    public class GetFormsQueryHandler<T> : IRequestHandler<T, List<FormDetails>>
        where T : GetFormsQuery
    {
        private readonly IDomainDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFormsQueryHandler(IDomainDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<FormDetails>> Handle(T request, CancellationToken cancellationToken)
        {
            var filteredForms = await Filter(_dbContext.Forms.AsQueryable());

            var mappedForms = GetFormsWithDetails(filteredForms);

            return mappedForms;
        }

        public virtual Task<List<Form>> Filter(IQueryable<Form> forms)
        {
            return Task.FromResult(forms.ToList());
        }

        public virtual List<FormDetails> GetFormsWithDetails(List<Form> forms)
        {
            var submits = _dbContext.FormSubmits.ToList();

            var createdForms = forms
                .Select(x =>
                    new FormDetails
                    {
                        Id = x.Id,
                        Name = x.Name,
                        SubmitsCount = submits.Where(s => s.FormId == x.Id)
                                        .Count(),
                        UserPassed = null
                    })
                .ToList();

            return createdForms;
        }
    }
}
