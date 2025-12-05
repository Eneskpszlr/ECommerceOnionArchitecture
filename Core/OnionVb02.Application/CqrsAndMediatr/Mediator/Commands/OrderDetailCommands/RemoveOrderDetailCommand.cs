using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderDetailResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand : IRequest<RemoveOrderDetailCommandResult>
    {
        public RemoveOrderDetailCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
