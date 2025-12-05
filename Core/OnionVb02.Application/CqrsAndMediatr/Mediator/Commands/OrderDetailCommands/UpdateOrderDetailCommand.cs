using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderDetailResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand : IRequest<UpdateOrderDetailCommandResult>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
