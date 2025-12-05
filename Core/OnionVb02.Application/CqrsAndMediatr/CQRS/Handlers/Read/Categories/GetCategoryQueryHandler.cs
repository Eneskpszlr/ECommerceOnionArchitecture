using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.CategoryResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Categories
{
    public class GetCategoryQueryHandler
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        //Todo : Mapper profiles icin ödev
        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery query)
        {
            List<Category> values = await _repository.GetAllAsync();

            return values.Select(x => new GetCategoryQueryResult
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                Id = x.Id
            }).ToList();
        }
    }
}
