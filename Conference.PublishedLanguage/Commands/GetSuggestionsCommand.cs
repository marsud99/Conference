using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference.PublishedLanguage.Commands
{
   public class GetSuggestionsCommand : IRequest
    {
        public int Id { get; set; }
        public int ConferenceTypeId { get; set; }
        public int Number { get; set; }
    }
}
