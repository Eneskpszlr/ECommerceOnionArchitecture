using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands
{
    public class RemoveAppUserProfileCommand
    {
        public RemoveAppUserProfileCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
