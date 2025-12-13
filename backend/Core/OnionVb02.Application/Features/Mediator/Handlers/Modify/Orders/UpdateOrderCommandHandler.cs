using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Orders
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResult>
    {
        private readonly IOrderRepository _repository;
        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderCommand command)
        {
            Order value = await _repository.GetByIdAsync(command.Id);

            value.ShippingAddress = command.ShippingAddress;
            value.AppUserId = command.AppUserId;
            value.UpdatedDate = DateTime.Now;
            value.Status = Domain.Enums.DataStatus.Updated;
            await _repository.SaveChangesAsync();

        }

        public async Task<UpdateOrderCommandResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
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
