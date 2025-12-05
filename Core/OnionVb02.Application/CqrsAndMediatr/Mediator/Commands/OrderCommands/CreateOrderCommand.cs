using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults.OrderResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<CreateOrderCommandResult>
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}
