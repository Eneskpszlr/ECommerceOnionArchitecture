using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.ProductResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands
{
    public class RemoveProductCommand : IRequest<RemoveProductCommandResult>
    {
        public RemoveProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

}
