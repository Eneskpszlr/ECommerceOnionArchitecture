using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.CategoryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResult>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}
