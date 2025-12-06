using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Interfaces;

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
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
                throw new NotFoundException("Kullanıcı Profili bulunamadı.");

            await _repository.DeleteAsync(value);

            return new RemoveAppUserProfileCommandResult
            {
                EntityId = request.Id
            };
        }
    }
}
