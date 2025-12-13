using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderDetailResults;
using OnionVb02.Application.Exceptions;
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
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Sipariş Detayı bulunamadı.");
            await _repository.DeleteAsync(value);
            return new RemoveOrderDetailCommandResult
            {
                EntityId = request.Id
            };
        }
    }
}
