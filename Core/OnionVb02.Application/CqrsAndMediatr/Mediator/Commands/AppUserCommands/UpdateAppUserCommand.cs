using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.AppUserResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands
{
    public class UpdateAppUserCommand : IRequest<UpdateAppUserCommandResult>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
