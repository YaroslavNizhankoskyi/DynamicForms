using Application.Helpers.Exceptions;
using Application.Interfaces;
using Application.Models.Dto;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Calls.Forms.Create
{
    public record CreateFormCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public bool Visibility { get; init; }
        public string Name { get; init; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public List<InputDto> Inputs { get; set; }
        public List<SelectDto> Selects { get; set; }
    }

    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, Guid>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IDomainDbContext _dbContext;

        public CreateFormCommandHandler(IUserService userService,
            IMapper mapper,
            IDomainDbContext dbContext
            )
        {
            this._userService = userService;
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrentUserDetails();

            var form = _mapper.Map<Form>(request);

            form.CreatorId = user.DomainId;
            _dbContext.Forms.Add(form);

            if ((await _dbContext.SaveChangesAsync(cancellationToken)) > 0)
            {
                var inputs = _mapper.Map<List<InputQuestion>>(request.Inputs)
                    .Select(x =>
                    {
                        x.FormId = form.Id;
                        return x;
                    });
                var selects = _mapper.Map<List<SelectQuestion>>(request.Selects)
                        .Select(x =>
                        {
                            x.FormId = form.Id;
                            return x;
                        });

                _dbContext.InputQuestions.AddRange(inputs);
                _dbContext.SelectQuestions.AddRange(selects);

                if ((await _dbContext.SaveChangesAsync(cancellationToken)) > 0)
                {
                    return form.Id;
                }
            }

            throw new InternalServerError("Could not create form");
        }
    }
}
