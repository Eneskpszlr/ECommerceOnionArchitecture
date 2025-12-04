using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.AppUsers
{
    public class RemoveAppUserCommandHandler : IRequestHandler<RemoveAppUserCommand, RemoveAppUserCommandResult>
    {
        private readonly IAppUserRepository _repository;
        public RemoveAppUserCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAppUserCommand command)
        {
            AppUser appUser = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(appUser);
        }

        public async Task<RemoveAppUserCommandResult> Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new RemoveAppUserCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı bulunamadı.",
                    };
                }

                await _repository.DeleteAsync(entity);

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
                    Message = "Kullanıcı silinirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
