using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Products
{
    public class UpdateProductCommandHandler
    {
        private readonly IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateProductCommandResult
                    {
                        Success = false,
                        Message = "Ürün bulunamadı."
                    };
                }

                entity.ProductName = request.ProductName;
                entity.UnitPrice = request.UnitPrice;
                entity.CategoryId = request.CategoryId;
                entity.UpdatedDate = DateTime.Now;
                entity.Status = Domain.Enums.DataStatus.Updated;

                await _repository.SaveChangesAsync();

                return new UpdateProductCommandResult
                {
                    Success = true,
                    Message = "Ürün başarıyla güncellendi.",
                    EntityId = entity.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateProductCommandResult
                {
                    Success = false,
                    Message = "Ürün güncellenirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
