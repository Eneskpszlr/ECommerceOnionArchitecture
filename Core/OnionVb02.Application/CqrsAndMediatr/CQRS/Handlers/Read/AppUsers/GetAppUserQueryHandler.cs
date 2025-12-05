using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUsers
{
    public class GetAppUserQueryHandler
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery query)
        {
            List<AppUser> values = await _repository.GetAllAsync();

            return values.Select(x => new GetAppUserQueryResult
            {
                UserName = x.UserName,
                Id = x.Id
            }).ToList();
        }
    }
}
