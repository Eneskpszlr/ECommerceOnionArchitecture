using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.ProductResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands
{

    public class CreateProductCommand : IRequest<CreateProductCommandResult>
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}
