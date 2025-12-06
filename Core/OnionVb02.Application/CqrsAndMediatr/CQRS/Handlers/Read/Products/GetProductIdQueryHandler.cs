using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.ProductResults;
using OnionVb02.Application.Exceptions;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read.Products
{
    public class GetProductIdQueryHandler
    {
        private readonly IProductRepository _repository;

        public GetProductIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query)
        {

            Product value = await _repository.GetByIdAsync(query.Id);

            if (value == null)
                throw new NotFoundException("Ürün bulunamadı");

            return new GetProductByIdQueryResult
            {
                ProductName = value.ProductName,
                UnitPrice = value.UnitPrice,
                Id = value.Id
            };
        }
    }
}
