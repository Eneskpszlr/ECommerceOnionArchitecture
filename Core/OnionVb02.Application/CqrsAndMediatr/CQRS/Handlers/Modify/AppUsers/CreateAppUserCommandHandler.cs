using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUsers
{
    public class CreateAppUserCommandHandler
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateAppUserCommandResult> Handle(CreateAppUserCommand request)
        {
            var appUser = new AppUser
            {
                UserName = request.UserName,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted,
                Password = request.Password
            };

            await _repository.CreateAsync(appUser);

            return new CreateAppUserCommandResult
            {
                EntityId = appUser.Id
            };
        }
    }
}
