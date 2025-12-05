using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.ProductResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<GetProductQueryResult>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
