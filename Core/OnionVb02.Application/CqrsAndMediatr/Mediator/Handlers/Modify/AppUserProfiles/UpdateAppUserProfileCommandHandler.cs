using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfiles
{
    public class UpdateAppUserProfileCommandHandler : IRequestHandler<UpdateAppUserProfileCommand, UpdateAppUserProfileCommandResult>
    {
        private readonly IAppUserProfileRepository _repository;
        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<UpdateAppUserProfileCommandResult> Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var value = await _repository.GetByIdAsync(request.Id);
                if (value == null)
                {
                    return new UpdateAppUserProfileCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı profili bulunamadı.",
                        Errors = new List<string> { "Invalid User Profile Id" }
                    };
                }
                value.FirstName = request.FirstName;
                value.LastName = request.LastName;
                value.Status = DataStatus.Updated;
                value.UpdatedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return new UpdateAppUserProfileCommandResult
                {
                    Success = true,
                    Message = "Kullanıcı profili başarıyla güncellendi.",
                    EntityId = value.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateAppUserProfileCommandResult
                {
                    Success = false,
                    Message = "Güncelleme sırasında bir hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
