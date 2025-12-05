using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.AppUserProfileResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries
{
    public class GetAppUserProfileByIdQuery : IRequest<GetAppUserProfileByIdQueryResult>
    {
        public int Id { get; set; }
        public GetAppUserProfileByIdQuery(int id)
        {
            Id = id;
        }
    }
}
