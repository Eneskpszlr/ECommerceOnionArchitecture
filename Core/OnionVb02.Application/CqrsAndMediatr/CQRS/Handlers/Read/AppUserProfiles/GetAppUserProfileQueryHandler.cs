using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.AppUserProfileResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUserProfileProfiles
{
    public class GetAppUserProfileQueryHandler
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAppUserProfileQueryResult>> Handle(GetAppUserProfileQuery query)
        {
            List<AppUserProfile> values = await _repository.GetAllAsync();

            if (values == null)
                throw new NotFoundException("Kullanıcı Profili bulunamadı");

            return values.Select(x => new GetAppUserProfileQueryResult
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id
            }).ToList();
        }
    }
}
