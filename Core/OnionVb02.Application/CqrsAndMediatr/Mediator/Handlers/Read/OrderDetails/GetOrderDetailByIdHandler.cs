using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.OrderDetails
{
    public class GetOrderDetailByIdHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
    {
        private readonly IOrderDetailRepository _repository;
        public GetOrderDetailByIdHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            OrderDetail value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                return null;
            return new GetOrderDetailByIdQueryResult
            {
                Id = value.Id,
                ProductId = value.ProductId,
                OrderId = value.OrderId
            };
        }
    }
}
