using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Orders
{
    public class UpdateOrderCommandHandler
    {
        private readonly IOrderRepository _repository;
        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateOrderCommandResult> Handle(UpdateOrderCommand request)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new NotFoundException("Sipariş bulunamadı.");

            entity.ShippingAddress = request.ShippingAddress;
            entity.AppUserId = request.AppUserId;
            entity.UpdatedDate = DateTime.Now;
            entity.Status = Domain.Enums.DataStatus.Updated;

            await _repository.SaveChangesAsync();

            return new UpdateOrderCommandResult
            {
                EntityId = entity.Id
            };
        }
    }
}
