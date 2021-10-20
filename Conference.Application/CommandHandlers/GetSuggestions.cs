using Conference.Data;
using Conference.PublishedLanguage.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Application.CommandHandlers
{
    public class GetSuggestions : IRequestHandler<GetSuggestionsCommand>
    {
        private readonly IMediator _mediator;
        private readonly ConferenceDatabase _database;

        public GetSuggestions(IMediator mediator , ConferenceDatabase database)
        {
            _mediator = mediator;
            _database = database;
        }
        public Task<Unit> Handle(GetSuggestionsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
