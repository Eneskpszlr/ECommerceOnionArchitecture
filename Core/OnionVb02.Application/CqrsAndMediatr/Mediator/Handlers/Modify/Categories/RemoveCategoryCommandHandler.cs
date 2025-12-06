using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.CategoryResults;
using OnionVb02.Application.Exceptions;
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
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
                throw new NotFoundException("Kategori bulunamadı.");
            await _repository.DeleteAsync(value);
            return new RemoveCategoryCommandResult
            {
                EntityId = request.Id
            };
        }
    }
}
