using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.AppUserResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUsers
{
    public class GetAppUserIdQueryHandler
    {
        private readonly IAppUserRepository _repository;

        public GetAppUserIdQueryHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAppUserByIdQueryResult> Handle(GetAppUserByIdQuery query)
        {

            AppUser value = await _repository.GetByIdAsync(query.Id);
            return new GetAppUserByIdQueryResult
            {
                UserName = value.UserName,
                Id = value.Id
            };
        }
    }
}
