using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands
{
    public class CreateAppUserCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
