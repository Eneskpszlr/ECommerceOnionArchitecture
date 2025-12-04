using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.OrderDetails
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IOrderDetailRepository _repository;

        public GetOrderDetailQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            List<OrderDetail> values = await _repository.GetAllAsync();

            return values.Select(x => new GetOrderDetailQueryResult
            {
                ProductId = x.ProductId,
                OrderId = x.OrderId,
                Id = x.Id
            }).ToList();
        }
    }
}
