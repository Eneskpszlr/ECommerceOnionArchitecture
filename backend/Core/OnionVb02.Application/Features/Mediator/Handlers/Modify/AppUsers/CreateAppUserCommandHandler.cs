using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUsers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CreateAppUserCommandResult>
    {
        private readonly IAppUserRepository _repository;

        public CreateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateAppUserCommandResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new AppUser
            {
                UserName = request.UserName,
                Password = request.Password,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _repository.CreateAsync(entity);

            return new CreateAppUserCommandResult
            {
                EntityId = entity.Id
            };
        }
    }
}
