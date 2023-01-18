using Application.Calls.Forms.Filters;
using Application.Calls.Forms.Get;
using Application.Interfaces;
using Application.Models.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Calls.Forms.GetPublic
{
    public record GetPublicForms : GetAllFormsQuery;

    public class GetPublicFormsHandler : GetFormsQueryHandler<GetPublicForms>
    {
        private readonly IDomainDbContext _dbContext;
        private readonly IUserService _userService;

        public GetPublicFormsHandler(IDomainDbContext dbContext,
            IUserService userService) : base(dbContext)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public override Task<List<Form>> Filter(IQueryable<Form> forms)
        {
            return Task.FromResult(forms
                .GetPublic(Visibility.Public)
                .ToList());
        }

        public override async Task<List<FormDetails>> GetFormsWithDetails(List<Form> forms)
        {
            var mappedForms = await base.GetFormsWithDetails(forms);

            var user = await _userService.GetCurrentUserDetails();

            foreach (var form in mappedForms)
            {
                var userPassed = _dbContext.FormSubmits
                    .Where(x => x.UserId == user.DomainId
                    && x.FormId == form.Id)
                    .Any();

                form.UserPassed = userPassed;
            }

            return mappedForms;
        }
    }
}
