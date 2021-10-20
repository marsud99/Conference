using Abstractions;
using Conference.Data;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conference.Application.Queries
{
    public class GetConferences
    {

       

        public class Query : IRequest<List<Model>>
        {


        }

        public class QueryHandler : IRequestHandler<Query, List<Model>>
        {
            private readonly ConferenceDatabase _dbContext;

            public QueryHandler(ConferenceDatabase dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<List<Model>> Handle(Query request, CancellationToken cancellationToken)
            {   
                var result = _dbContext.Conferences.Select(x => new Model
                { Name = x.Name,
                ConferenceTypeId = x.ConferenceTypeId,
                CategoryId = x.CategoryId,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                LocationId = x.LocationId,
                OrganizerEmail = x.OrganizerEmail

                }).Take(5)
                    .ToList();



                return Task.FromResult(result);
            }
        }

        public class Model
        {
            public int Id { get; set; }
            public int ConferenceTypeId { get; set; }
            public int LocationId { get; set; }
            public string OrganizerEmail { get; set; }
            public int CategoryId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Name { get; set; }
        }
    }
}
