using Application.Calls.Forms.Get;
using Application.Interfaces;
using Application.Models;
using Application.Models.Dto;
using Domain;

namespace Application.Calls.Forms.GetUserCreated
{
    public record GetUserCreatedForms : GetAllFormsQuery;

    public class GetUserCreatedFormsHandler : GetFormsQueryHandler<GetUserCreatedForms>
    {
        private readonly IDomainDbContext _dbContext;
        private readonly IUserService _userService;
        private UserDetails user;

        public GetUserCreatedFormsHandler(IDomainDbContext dbContext, IUserService userService) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._userService = userService;
        }

        public override async Task<List<Form>> Filter(IQueryable<Form> forms)
        {
            this.user = await _userService.GetCurrentUserDetails();

            var t = forms
                .Where(x => x.CreatorId == this.user.DomainId)
                .ToList();

            return t;
        }

        public override async Task<List<FormDetails>> GetFormsWithDetails(List<Form> forms)
        {
            var mappedForms = await base.GetFormsWithDetails(forms);

            foreach (var form in mappedForms)
            {
                var userPassed = _dbContext.FormSubmits
                    .Where(x => x.UserId == this.user.DomainId
                    && x.FormId == form.Id)
                    .Any();

                form.UserPassed = userPassed;
            }

            return mappedForms;
        }

    }
}
