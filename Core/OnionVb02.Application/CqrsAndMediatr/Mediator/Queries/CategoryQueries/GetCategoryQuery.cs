using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.CategoryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
    {
    }
}
