using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.AppUserProfileResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUserProfileProfiles
{
    public class GetAppUserProfileIdQueryHandler
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileIdQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserProfileByIdQueryResult> Handle(GetAppUserProfileByIdQuery query)
        {

            AppUserProfile value = await _repository.GetByIdAsync(query.Id);

            if (value == null)
                throw new NotFoundException("Kullanıcı Profili bulunamadı");

            return new GetAppUserProfileByIdQueryResult
            {
                FirstName = value.FirstName,
                LastName = value.LastName,
                Id = value.Id
            };
        }
    }
}
