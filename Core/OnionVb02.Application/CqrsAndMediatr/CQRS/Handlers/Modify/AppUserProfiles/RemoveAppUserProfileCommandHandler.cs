using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.CategoryResults;
using OnionVb02.Application.Exceptions;
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
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new NotFoundException("Kullanıcı profili bulunamadı.");

            await _repository.DeleteAsync(entity);

            return new RemoveAppUserProfileCommandResult
            {
                EntityId = request.Id
            };
        }
    }
}
