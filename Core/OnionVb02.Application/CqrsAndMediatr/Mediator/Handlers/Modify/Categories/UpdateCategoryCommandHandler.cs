using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Enums;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResult>
    {
        private readonly ICategoryRepository _repository;
        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var value = await _repository.GetByIdAsync(request.Id);
                if (value == null)
                {
                    return new UpdateCategoryCommandResult
                    {
                        Success = false,
                        Message = "Kategori bulunamadı.",
                        Errors = new List<string> { "Invalid Category Id" }
                    };
                }
                value.CategoryName = request.CategoryName;
                value.Description = request.Description;
                value.Status = DataStatus.Updated;
                value.UpdatedDate = DateTime.Now;
                await _repository.SaveChangesAsync();
                return new UpdateCategoryCommandResult
                {
                    Success = true,
                    Message = "Kategori başarıyla güncellendi.",
                    EntityId = value.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateCategoryCommandResult
                {
                    Success = false,
                    Message = "Güncelleme sırasında bir hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
