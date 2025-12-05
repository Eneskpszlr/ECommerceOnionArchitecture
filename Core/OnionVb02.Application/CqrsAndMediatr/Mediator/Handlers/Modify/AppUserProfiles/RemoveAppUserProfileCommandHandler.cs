using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.AppUserProfiles
{
    public class RemoveAppUserProfileCommandHandler : IRequestHandler<RemoveAppUserProfileCommand, RemoveAppUserProfileCommandResult>
    {
        private readonly IAppUserProfileRepository _repository;
        public RemoveAppUserProfileCommandHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveAppUserProfileCommandResult> Handle(RemoveAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var value = await _repository.GetByIdAsync(request.Id);

                if (value == null)
                {
                    return new RemoveAppUserProfileCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı profili bulunamadı.",
                        Errors = new List<string> { "Invalid User Id" }
                    };
                }

                await _repository.DeleteAsync(value);

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
                    Message = "Silme sırasında bir hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
