using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetails
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
                var value = await _repository.GetByIdAsync(request.Id);
                if (value == null)
                {
                    return new UpdateOrderDetailCommandResult
                    {
                        Success = false,
                        Message = "Sipariş detayı bulunamadı.",
                        Errors = new List<string> { "Invalid Order Detail Id" }
                    };
                }
                value.ProductId = request.ProductId;
                value.OrderId = request.OrderId;
                value.Status = DataStatus.Updated;
                value.UpdatedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return new UpdateOrderDetailCommandResult
                {
                    Success = true,
                    Message = "Sipariş detayı başarıyla güncellendi.",
                    EntityId = value.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateOrderDetailCommandResult
                {
                    Success = false,
                    Message = "Güncelleme sırasında bir hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
