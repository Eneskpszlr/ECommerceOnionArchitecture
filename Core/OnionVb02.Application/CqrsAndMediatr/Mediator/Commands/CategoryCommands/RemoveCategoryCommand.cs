using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.CategoryResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest<RemoveCategoryCommandResult>
    {
        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
