using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUserProfiles
{
    public class CreateAppUserProfileCommandHandler : IRequestHandler<CreateAppUserProfileCommand, CreateAppUserProfileCommandResult>
    {
        private readonly IAppUserProfileRepository _repository;

        public CreateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<CreateAppUserProfileCommandResult> Handle(CreateAppUserProfileCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var appUserProfile = new AppUserProfile
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    CreatedDate = DateTime.Now,
                    Status = Domain.Enums.DataStatus.Inserted
                };

                await _repository.CreateAsync(appUserProfile);

                return new CreateAppUserProfileCommandResult
                {
                    Success = true,
                    Message = "Kullanıcı profili başarıyla oluşturuldu.",
                    EntityId = appUserProfile.Id
                };
            }
            catch (Exception ex)
            {
                return new CreateAppUserProfileCommandResult
                {
                    Success = false,
                    Message = "Kullanıcı profili oluşturulurken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
