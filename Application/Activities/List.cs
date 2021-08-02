using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    //the way you use mediatR is nested classes
    public class List
    {
        public class Query : IRequest<List<Activity>> { }
        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            //handler handles requests
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                //the cancelation token being passed in allows the cancelation of a long running request
                return await _context.Activities.ToListAsync();
            }
        }
    }
}