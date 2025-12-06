using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.ProductResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Products
{
    public class RemoveProductCommandHandler
    {
        private readonly IProductRepository _repository;
        public RemoveProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveProductCommandResult> Handle(RemoveProductCommand request)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new NotFoundException("Ürün bulunamadı.");

            await _repository.DeleteAsync(entity);

            return new RemoveProductCommandResult
            {
                EntityId = request.Id
            };
        }
    }
}
