using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using OnionVb02.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Categories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand command,CancellationToken cancellationToken)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = command.CategoryName,
                    Description = command.Description,
                    CreatedDate = DateTime.Now,
                    Status = Domain.Enums.DataStatus.Inserted
                };

                await _repository.CreateAsync(category);

                return new CreateCategoryCommandResult
                {
                    Success = true,
                    Message = "Kategori başarıyla oluşturuldu.",
                    EntityId = category.Id
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