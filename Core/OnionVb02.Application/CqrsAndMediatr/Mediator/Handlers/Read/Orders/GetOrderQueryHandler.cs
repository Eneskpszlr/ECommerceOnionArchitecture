using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.Orders
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<GetOrderQueryResult>>
    {
        private readonly IOrderRepository _repository;

        public GetOrderQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            List<Order> values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderQueryResult
            {
                Id = x.Id,
                ShippingAddress = x.ShippingAddress
            }).ToList();
        }
    }
}
