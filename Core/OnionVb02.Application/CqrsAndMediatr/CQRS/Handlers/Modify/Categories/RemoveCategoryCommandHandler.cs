using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify.Categories
{
    public class RemoveCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<RemoveCategoryCommandResult> Handle(RemoveCategoryCommand request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new RemoveCategoryCommandResult
                    {
                        Success = false,
                        Message = "Kategori bulunamadı.",
                    };
                }

                await _repository.DeleteAsync(entity);

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
                    Message = "Kategori silinirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
