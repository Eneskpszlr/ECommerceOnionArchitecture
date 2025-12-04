using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Orders
{
    public class GetOrderIdQueryHandler
    {
        private readonly IOrderRepository _repository;

        public GetOrderIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery query)
        {

            Order value = await _repository.GetByIdAsync(query.Id);
            return new GetOrderByIdQueryResult
            {
                ShippingAddress = value.ShippingAddress,
                Id = value.Id
            };
        }
    }
}
