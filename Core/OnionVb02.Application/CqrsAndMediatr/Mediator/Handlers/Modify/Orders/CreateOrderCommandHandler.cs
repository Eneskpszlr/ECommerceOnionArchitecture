using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderCommandResult>
    {
        private readonly IOrderRepository _repository;
        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = new Order
                {
                    ShippingAddress = request.ShippingAddress,
                    AppUserId = request.AppUserId,
                    CreatedDate = DateTime.Now,
                    Status = Domain.Enums.DataStatus.Inserted
                };

                await _repository.CreateAsync(order);

                return new CreateOrderCommandResult
                {
                    Success = true,
                    Message = "Sipariş başarıyla oluşturuldu.",
                    EntityId = order.Id
                };
            }
            catch (Exception ex)
            {
                return new CreateOrderCommandResult
                {
                    Success = false,
                    Message = "Sipariş oluşturulurken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
