using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.ProductResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands
{
    public class UpdateProductCommand
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
