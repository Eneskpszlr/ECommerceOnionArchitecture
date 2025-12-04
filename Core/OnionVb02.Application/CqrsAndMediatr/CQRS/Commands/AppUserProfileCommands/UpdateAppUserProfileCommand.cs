using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands
{
    public class UpdateAppUserProfileCommand : IRequest<UpdateAppUserProfileCommandResult>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}
