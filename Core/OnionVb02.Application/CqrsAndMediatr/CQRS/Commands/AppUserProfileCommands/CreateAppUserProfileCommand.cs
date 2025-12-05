using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.AppUserProfileResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands
{
    public class CreateAppUserProfileCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}
