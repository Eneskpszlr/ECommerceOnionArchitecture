using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Categories
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, RemoveCategoryCommandResult>
    {
        private readonly ICategoryRepository _repository;
        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<RemoveCategoryCommandResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var value = await _repository.GetByIdAsync(request.Id);
                if (value == null)
                {
                    return new RemoveCategoryCommandResult
                    {
                        Success = false,
                        Message = "Kategori bulunamadı.",
                        Errors = new List<string> { "Invalid Category Id" }
                    };
                }
                await _repository.DeleteAsync(value);
                return new RemoveCategoryCommandResult
                {
                    Success = true,
                    Message = "Kategori başarıyla silindi.",
                    EntityId = request.Id
                };
            }
            catch (Exception ex)
            {
                return new RemoveCategoryCommandResult
                {
                    Success = false,
                    Message = "Silme sırasında bir hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
