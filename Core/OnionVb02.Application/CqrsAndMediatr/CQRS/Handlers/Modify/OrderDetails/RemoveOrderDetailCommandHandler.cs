using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.OrderDetails
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository _repository;
        public RemoveOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveOrderDetailCommandResult> Handle(RemoveOrderDetailCommand request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new RemoveOrderDetailCommandResult
                    {
                        Success = false,
                        Message = "Sipariş Detayı bulunamadı.",
                    };
                }

                await _repository.DeleteAsync(entity);

                return new RemoveOrderDetailCommandResult
                {
                    Success = true,
                    Message = "Sipariş Detayı başarıyla silindi.",
                    EntityId = request.Id
                };
            }
            catch (Exception ex)
            {
                return new RemoveOrderDetailCommandResult
                {
                    Success = false,
                    Message = "Sipariş Detayı silinirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
