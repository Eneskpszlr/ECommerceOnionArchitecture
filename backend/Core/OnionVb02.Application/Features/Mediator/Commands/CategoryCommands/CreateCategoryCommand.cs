using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.CategoryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResult>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
