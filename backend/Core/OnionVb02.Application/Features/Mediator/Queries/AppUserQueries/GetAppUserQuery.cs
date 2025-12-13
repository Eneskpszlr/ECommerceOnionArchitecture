using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.AppUserResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries
{
    public class GetAppUserQuery : IRequest<List<GetAppUserQueryResult>>
    {
    }
}
