using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.Read.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductQueryResult>
    {
        private readonly IProductRepository _repository;
        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetProductQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetProductQueryResult
            {
                Id = value.Id,
                ProductName = value.ProductName,
                UnitPrice = value.UnitPrice
            };
        }
    }
}
