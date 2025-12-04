using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest<UpdateOrderCommandResult>
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
