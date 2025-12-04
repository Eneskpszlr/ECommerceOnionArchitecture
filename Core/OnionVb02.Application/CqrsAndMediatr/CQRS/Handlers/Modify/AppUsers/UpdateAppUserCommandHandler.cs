using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUsers
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
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateAppUserCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı bulunamadı."
                    };
                }

                entity.UserName = request.UserName;
                entity.Password = request.Password;
                entity.UpdatedDate = DateTime.Now;
                entity.Status = Domain.Enums.DataStatus.Updated;

                await _repository.SaveChangesAsync();

                return new UpdateAppUserCommandResult
                {
                    Success = true,
                    Message = "Kullanıcı başarıyla güncellendi.",
                    EntityId = entity.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateAppUserCommandResult
                {
                    Success = false,
                    Message = "Kullanıcı güncellenirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }

        }
    }
}
