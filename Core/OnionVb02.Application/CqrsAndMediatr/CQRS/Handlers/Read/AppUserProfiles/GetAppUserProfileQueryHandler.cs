using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.AppUserProfileResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.AppUserProfileProfiles
{
    public class GetAppUserProfileQueryHandler
    {
        private readonly IAppUserProfileRepository _repository;

        public GetAppUserProfileQueryHandler(IAppUserProfileRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAppUserProfileQueryResult>> Handle()
        {
            List<AppUserProfile> values = await _repository.GetAllAsync();

            return values.Select(x => new GetAppUserProfileQueryResult
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id
            }).ToList();
        }
    }
}
