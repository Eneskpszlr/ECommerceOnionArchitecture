using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class RemoveOrderCommand : IRequest<RemoveOrderCommandResult>
    {
        public RemoveOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
