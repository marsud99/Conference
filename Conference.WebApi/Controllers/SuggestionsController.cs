using Conference.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SuggestionsController : ControllerBase
    {
        private readonly MediatR.IMediator _mediator;

        public SuggestionsController(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetConferences")]
        public async Task<List<GetConferences.Model>> GetConferences(CancellationToken cancellationToken)
        {
            var query = new GetConferences.Query();
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }
    }
}
