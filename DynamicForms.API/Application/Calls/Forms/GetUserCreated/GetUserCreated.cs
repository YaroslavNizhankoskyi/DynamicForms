using Application.Calls.Forms.Get;
using Application.Interfaces;
using Application.Models.Dto;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Calls.Forms.GetUserCreated
{
    public record GetUserCreated : GetFormsQuery;

    public class GetUserCreatedHandler : GetFormsQueryHandler<GetUserCreated>
    {
        private readonly IDomainDbContext _dbContext;
        private readonly ICurrentUserService _currentUser;

        public GetUserCreatedHandler(IDomainDbContext dbContext, ICurrentUserService currentUser) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._currentUser = currentUser;
        }

        public override Task<List<Form>> Filter(IQueryable<Form> forms)
        {
            return forms
                .Where(x => x.CreatorId == _currentUser.GetUserId())
                .ToListAsync();
        }

        public override List<FormDetails> GetFormsWithDetails(List<Form> forms)
        {
            var mappedForms = base.GetFormsWithDetails(forms);

            foreach(var form in mappedForms)
            {
                var userPassed = _dbContext.FormSubmits
                    .Where(x => x.UserId == _currentUser.GetUserId()
                    && x.FormId == form.Id)
                    .Any();

                form.UserPassed = userPassed;
            }

            return mappedForms;
        }

    }
}
