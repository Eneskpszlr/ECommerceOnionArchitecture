using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.WriteResults
{
    public class BaseCommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? EntityId { get; set; }
        public List<string> Errors { get; set; }
    }
}
