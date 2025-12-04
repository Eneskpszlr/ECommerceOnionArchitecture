using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUsers
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
            try
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
                    Success = true,
                    Message = "Kullanıcı başarıyla oluşturuldu.",
                    EntityId = appUser.Id
                };
            }
            catch (Exception ex)
            {
                return new CreateAppUserCommandResult
                {
                    Success = false,
                    Message = "Kullanıcı oluşturulurken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
