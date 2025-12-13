using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.ProductResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class UpdateProductCommand : IRequest<UpdateProductCommandResult>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }

}
