using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
