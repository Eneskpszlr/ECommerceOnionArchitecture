using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.ProductResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands
{
    public class RemoveProductCommand
    {
        public RemoveProductCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
