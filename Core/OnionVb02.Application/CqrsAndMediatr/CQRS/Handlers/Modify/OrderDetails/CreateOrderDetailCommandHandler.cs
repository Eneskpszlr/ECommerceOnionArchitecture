using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.OrderDetails
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<CreateOrderDetailCommandResult> Handle(CreateOrderDetailCommand request)
        {
                var orderDetail = new OrderDetail
                {
                    ProductId = request.ProductId,
                    OrderId = request.OrderId,
                    CreatedDate = DateTime.Now,
                    Status = Domain.Enums.DataStatus.Inserted
                };

                await _repository.CreateAsync(orderDetail);

                return new CreateOrderDetailCommandResult
                {
                    EntityId = orderDetail.Id
                };
        }
    }
}
