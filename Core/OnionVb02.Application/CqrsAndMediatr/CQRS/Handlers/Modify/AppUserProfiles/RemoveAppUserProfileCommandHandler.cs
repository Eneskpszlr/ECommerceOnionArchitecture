using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUserProfiles
{
    public class RemoveAppUserProfileCommandHandler
    {
        private readonly IAppUserProfileRepository _repository;
        public RemoveAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveAppUserProfileCommandResult> Handle(RemoveAppUserProfileCommand request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new RemoveAppUserProfileCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı profili bulunamadı.",
                    };
                }

                await _repository.DeleteAsync(entity);

                return new RemoveAppUserProfileCommandResult
                {
                    Success = true,
                    Message = "Kullanıcı profili başarıyla silindi.",
                    EntityId = request.Id
                };
            }
            catch (Exception ex)
            {
                return new RemoveAppUserProfileCommandResult
                {
                    Success = false,
                    Message = "Kullanıcı profili silinirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
