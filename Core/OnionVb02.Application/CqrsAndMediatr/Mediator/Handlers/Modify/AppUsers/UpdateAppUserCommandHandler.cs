using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUsers
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, UpdateAppUserCommandResult>
    {
        private readonly IAppUserRepository _repository;

        public UpdateAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateAppUserCommandResult> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var value = await _repository.GetByIdAsync(request.Id);

                if (value == null)
                {
                    return new UpdateAppUserCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı bulunamadı.",
                        Errors = new List<string> { "Invalid User Id" }
                    };
                }

                value.UserName = request.UserName;
                value.Password = request.Password;
                value.Status = Domain.Enums.DataStatus.Updated;
                value.UpdatedDate = DateTime.Now;

                await _repository.SaveChangesAsync();

                return new UpdateAppUserCommandResult
                {
                    Success = true,
                    Message = "Kullanıcı başarıyla güncellendi.",
                    EntityId = value.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateAppUserCommandResult
                {
                    Success = false,
                    Message = "Güncelleme sırasında bir hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
