using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.OrderDetails
{
    public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommand, RemoveOrderDetailCommandResult>
    {
        private readonly IOrderDetailRepository _repository;
        public RemoveOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<RemoveOrderDetailCommandResult> Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var value = await _repository.GetByIdAsync(request.Id);
                if (value == null)
                {
                    return new RemoveOrderDetailCommandResult
                    {
                        Success = false,
                        Message = "Sipariş detayı bulunamadı.",
                        Errors = new List<string> { "Invalid Order Detail Id" }
                    };
                }
                await _repository.DeleteAsync(value);
                return new RemoveOrderDetailCommandResult
                {
                    Success = true,
                    Message = "Sipariş detayı başarıyla silindi.",
                    EntityId = request.Id
                };
            }
            catch (Exception ex)
            {
                return new RemoveOrderDetailCommandResult
                {
                    Success = false,
                    Message = "Silme sırasında bir hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
