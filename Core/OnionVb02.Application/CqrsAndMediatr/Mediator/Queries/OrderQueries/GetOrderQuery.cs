using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries
{
    public class GetOrderQuery : IRequest<List<GetOrderQueryResult>>
    {
    }
}
