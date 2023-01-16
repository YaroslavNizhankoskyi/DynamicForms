using Application.Interfaces;
using Application.Models.Dto;
using Domain;
using MediatR;

namespace Application.Calls.Forms.Get
{
    public record GetFormsQuery() : IRequest<List<FormDetails>>;

    public abstract class GetFormsQueryHandler<T> : IRequestHandler<T, List<FormDetails>>
        where T : GetFormsQuery
    {
        private readonly IDomainDbContext _dbContext;

        public GetFormsQueryHandler(IDomainDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<FormDetails>> Handle(T request, CancellationToken cancellationToken)
        {
            var filteredForms = await Filter(_dbContext.Forms.AsQueryable());

            var mappedForms = await GetFormsWithDetails(filteredForms);

            return mappedForms;
        }

        public virtual Task<List<Form>> Filter(IQueryable<Form> forms)
        {
            return Task.FromResult(forms.ToList());
        }

        public virtual Task<List<FormDetails>> GetFormsWithDetails(List<Form> forms)
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

            return Task.FromResult(createdForms);
        }
    }
}
