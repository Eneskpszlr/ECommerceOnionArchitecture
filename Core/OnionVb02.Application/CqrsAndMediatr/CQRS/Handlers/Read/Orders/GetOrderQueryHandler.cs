using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Orders
{
    public class GetOrderQueryHandler
    {
        private readonly IOrderRepository _repository;

        public GetOrderQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderQueryResult>> Handle()
        {
            List<Order> values = await _repository.GetAllAsync();

            return values.Select(x => new GetOrderQueryResult
            {
                ShippingAddress = x.ShippingAddress,
                Id = x.Id
            }).ToList();
        }
    }
}
