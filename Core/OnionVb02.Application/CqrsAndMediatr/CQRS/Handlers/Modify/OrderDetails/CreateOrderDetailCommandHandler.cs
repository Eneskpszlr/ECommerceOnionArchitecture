using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.OrderDetails
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreateOrderDetailCommandResult>
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductId = command.ProductId,
                CreatedDate = DateTime.Now,
                Status = Domain.Enums.DataStatus.Inserted,
                OrderId = command.OrderId
            });
        }

        public async Task<CreateOrderDetailCommandResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            try
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
                    Success = true,
                    Message = "Sipariş Detayı başarıyla oluşturuldu.",
                    EntityId = orderDetail.Id
                };
            }
            catch (Exception ex)
            {
                return new CreateOrderDetailCommandResult
                {
                    Success = false,
                    Message = "Sipariş Detayı oluşturulurken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
