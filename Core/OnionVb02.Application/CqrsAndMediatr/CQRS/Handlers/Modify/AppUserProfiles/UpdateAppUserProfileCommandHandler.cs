using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUserProfiles
{
    public class UpdateAppUserProfileCommandHandler
    {
        private readonly IAppUserProfileRepository _repository;
        public UpdateAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateAppUserProfileCommandResult> Handle(UpdateAppUserProfileCommand request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateAppUserProfileCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı profili bulunamadı."
                    };
                }

                entity.FirstName = request.FirstName;
                entity.AppUserId = request.AppUserId;
                entity.LastName = request.LastName;
                entity.UpdatedDate = DateTime.Now;
                entity.Status = Domain.Enums.DataStatus.Updated;

                await _repository.SaveChangesAsync();

                return new UpdateAppUserProfileCommandResult
                {
                    Success = true,
                    Message = "Kullanıcı profili başarıyla güncellendi.",
                    EntityId = entity.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateAppUserProfileCommandResult
                {
                    Success = false,
                    Message = "Kullanıcı profili güncellenirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
