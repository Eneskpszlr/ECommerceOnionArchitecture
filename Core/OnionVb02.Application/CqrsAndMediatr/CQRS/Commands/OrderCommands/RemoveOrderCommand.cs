using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands
{
    public class RemoveOrderCommand : IRequest<UpdateOrderCommandResult>
    {
        public RemoveOrderCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
