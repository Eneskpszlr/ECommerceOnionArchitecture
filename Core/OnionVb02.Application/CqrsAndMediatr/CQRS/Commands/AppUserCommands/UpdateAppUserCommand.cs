using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserResults;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands
{
    public class UpdateAppUserCommand : IRequest<UpdateAppUserCommandResult>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
