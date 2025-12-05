using MediatR;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.WriteResults.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands
{
    public class CreateOrderDetailCommand
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
