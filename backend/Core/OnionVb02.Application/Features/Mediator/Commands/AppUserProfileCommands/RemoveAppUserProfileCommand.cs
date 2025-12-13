using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.AppUserProfileResults;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands
{
    public class RemoveAppUserProfileCommand :IRequest<RemoveAppUserProfileCommandResult>
    {
        public RemoveAppUserProfileCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
