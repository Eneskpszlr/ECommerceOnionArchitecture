using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.ProductResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Products
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, RemoveProductCommandResult>
    {
        private readonly IProductRepository _repository;
        public RemoveProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveProductCommandResult> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new NotFoundException("Kategori bulunamadı.");

            await _repository.DeleteAsync(entity);

            return new RemoveProductCommandResult
            {
                EntityId = request.Id
            };
        }
    }
}
