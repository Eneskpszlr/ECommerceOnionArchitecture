using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.OrderDetails
{
    public class GetOrderDetailIdQueryHandler
    {
        private readonly IOrderDetailRepository _repository;

        public GetOrderDetailIdQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {

            OrderDetail value = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                ProductId = value.ProductId,
                OrderId = value.OrderId,
                Id = value.Id
            };
        }
    }
}
