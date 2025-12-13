using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdQueryResult>
    {
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
