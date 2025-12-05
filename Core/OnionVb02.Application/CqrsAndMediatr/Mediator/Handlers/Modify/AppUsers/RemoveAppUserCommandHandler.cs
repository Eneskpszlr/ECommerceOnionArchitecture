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
    public class RemoveAppUserCommandHandler : IRequestHandler<RemoveAppUserCommand, RemoveAppUserCommandResult>
    {
        private readonly IAppUserRepository _repository;

        public RemoveAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveAppUserCommandResult> Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var value = await _repository.GetByIdAsync(request.Id);

                if (value == null)
                {
                    return new RemoveAppUserCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı bulunamadı.",
                        Errors = new List<string> { "Invalid User Id" }
                    };
                }

                await _repository.DeleteAsync(value);

                return new RemoveAppUserCommandResult
                {
                    Success = true,
                    Message = "Kullanıcı başarıyla silindi.",
                    EntityId = request.Id
                };
            }
            catch (Exception ex)
            {
                return new RemoveAppUserCommandResult
                {
                    Success = false,
                    Message = "Silme sırasında bir hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
