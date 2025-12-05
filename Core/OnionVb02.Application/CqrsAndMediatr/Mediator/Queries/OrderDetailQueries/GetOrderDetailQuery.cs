using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery : IRequest<List<GetOrderDetailQueryResult>>
    {
    }
}
