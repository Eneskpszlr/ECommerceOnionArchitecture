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
    public class UpdateCategoryCommandHandler
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommand request)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                if (entity == null)
                {
                    return new UpdateCategoryCommandResult
                    {
                        Success = false,
                        Message = "Kategori bulunamadı."
                    };
                }

                entity.CategoryName = request.CategoryName;
                entity.Description = request.Description;
                entity.UpdatedDate = DateTime.Now;
                entity.Status = Domain.Enums.DataStatus.Updated;

                await _repository.SaveChangesAsync();

                return new UpdateCategoryCommandResult
                {
                    Success = true,
                    Message = "Kategori başarıyla güncellendi.",
                    EntityId = entity.Id
                };
            }
            catch (Exception ex)
            {
                return new UpdateCategoryCommandResult
                {
                    Success = false,
                    Message = "Kategori güncellenirken hata oluştu.",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
