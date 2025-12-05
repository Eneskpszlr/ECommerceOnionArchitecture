using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Products
{
    public class GetProductQueryHandler
    {
        private readonly IProductRepository _repository;

        public GetProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery query)
        {
            List<Product> values = await _repository.GetAllAsync();

            return values.Select(x => new GetProductQueryResult
            {
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                Id = x.Id
            }).ToList();
        }
    }
}
