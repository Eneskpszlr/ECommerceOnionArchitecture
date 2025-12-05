using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.ProductResults;
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
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new RemoveProductCommandResult
                    {
                        Success = false,
                        Message = "Ürün bulunamadı.",
                    };
                }

                await _repository.DeleteAsync(entity);

                return new RemoveProductCommandResult
                {
                    Success = true,
                    Message = "Ürün başarıyla silindi.",
                    EntityId = request.Id
                };
            }
            catch (Exception ex)
            {
                return new RemoveProductCommandResult
                {
                    Success = false,
                    Message = "Ürün silinirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
