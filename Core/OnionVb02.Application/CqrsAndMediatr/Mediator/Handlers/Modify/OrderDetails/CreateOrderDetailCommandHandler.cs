using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetails
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreateOrderDetailCommandResult>
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateOrderDetailCommandResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new OrderDetail
                {
                    ProductId = request.ProductId,
                    OrderId = request.OrderId,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                await _repository.CreateAsync(entity);

                return new CreateOrderDetailCommandResult
                {
                    Success = true,
                    Message = "Sipariş detayı başarıyla oluşturuldu.",
                    EntityId = entity.Id
                };
            }
            catch (Exception ex)
            {
                return new CreateOrderDetailCommandResult
                {
                    Success = false,
                    Message = "Sipariş detayı oluşturulurken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
