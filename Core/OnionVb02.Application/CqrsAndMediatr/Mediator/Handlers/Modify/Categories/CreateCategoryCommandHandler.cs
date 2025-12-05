using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Modify.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Category
                {
                    CategoryName = request.CategoryName,
                    Description = request.Description,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                await _repository.CreateAsync(entity);

                return new CreateCategoryCommandResult
                {
                    Success = true,
                    Message = "Kategori başarıyla oluşturuldu.",
                    EntityId = entity.Id
                };
            }
            catch (Exception ex)
            {
                return new CreateCategoryCommandResult
                {
                    Success = false,
                    Message = "Kategori oluşturulurken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
