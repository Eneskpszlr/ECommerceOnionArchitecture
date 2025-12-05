using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Orders
{
    public class RemoveOrderCommandHandler
    {
        private readonly IOrderRepository _repository;
        public RemoveOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderCommandResult> Handle(RemoveOrderCommand request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateOrderCommandResult
                    {
                        Success = false,
                        Message = "Sipariş bulunamadı.",
                    };
                }

                await _repository.DeleteAsync(entity);

                return new UpdateOrderCommandResult
                {
                    Success = true,
                    Message = "Sipariş başarıyla silindi.",
                    EntityId = request.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateOrderCommandResult
                {
                    Success = false,
                    Message = "Sipariş silinirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
