using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands
{
    public class RemoveAppUserCommand : IRequest<RemoveAppUserCommandResult>
    {
        public RemoveAppUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
