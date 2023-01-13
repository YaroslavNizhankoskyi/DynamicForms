using Application.Interfaces;

namespace Application.Calls.Forms.Get
{
    public record GetAllFormsQuery : GetFormsQuery;

    public class GetAllFormsQueryHandler : GetFormsQueryHandler<GetAllFormsQuery>
    {
        public GetAllFormsQueryHandler(IDomainDbContext dbContext) : base(dbContext)
        {
        }
    }
}
