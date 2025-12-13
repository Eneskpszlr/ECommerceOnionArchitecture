using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderDetailResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;
using OnionVb02.Domain.Interfaces;

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
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Sipariş Detayı bulunamadı.");
            value.ProductId = request.ProductId;
            value.OrderId = request.OrderId;
            value.Status = DataStatus.Updated;
            value.UpdatedDate = DateTime.Now;
            await _repository.SaveChangesAsync();
            return new UpdateOrderDetailCommandResult
            {
                EntityId = value.Id
            };
        }
    }
}
