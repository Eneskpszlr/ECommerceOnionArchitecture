using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.OrderDetails
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository _repository;
        public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderDetailCommandResult> Handle(UpdateOrderDetailCommand request)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new NotFoundException("Sipariş detayı bulunamadı.");

            entity.OrderId = entity.OrderId;
            entity.ProductId = entity.ProductId;
            entity.UpdatedDate = DateTime.Now;
            entity.Status = Domain.Enums.DataStatus.Updated;

            await _repository.SaveChangesAsync();

            return new UpdateOrderDetailCommandResult
            {
                EntityId = entity.Id
            };
        }
    }
}
