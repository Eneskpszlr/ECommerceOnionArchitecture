using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.OrderDetailResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdQueryResult>
    {
        public int Id { get; set; }
        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}
