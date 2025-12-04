using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.OrderDetails
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, UpdateOrderDetailCommandResult>
    {
        private readonly IOrderDetailRepository _repository;
        public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderDetailCommandResult> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateOrderDetailCommandResult
                    {
                        Success = false,
                        Message = "Sipariş Detayı bulunamadı."
                    };
                }

                entity.OrderId = entity.OrderId;
                entity.ProductId = entity.ProductId;
                entity.UpdatedDate = DateTime.Now;
                entity.Status = Domain.Enums.DataStatus.Updated;

                await _repository.SaveChangesAsync();

                return new UpdateOrderDetailCommandResult
                {
                    Success = true,
                    Message = "Sipariş Detayı başarıyla güncellendi.",
                    EntityId = entity.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateOrderDetailCommandResult
                {
                    Success = false,
                    Message = "Sipariş Detayı güncellenirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
