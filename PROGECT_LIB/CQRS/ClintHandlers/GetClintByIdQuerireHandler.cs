using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PROGECT_LIB.CQRS.ClintQueries;
using PROGECT_LIB.Data;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.CQRS.ClintHandlers
{
    public record GetClintByIdQuerireHandler : IRequestHandler<GetClintByIdQuerire, Client>
    {
        private readonly AppDbContext _context;

        public GetClintByIdQuerireHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Client> Handle(GetClintByIdQuerire request, CancellationToken cancellationToken)
        {
            var book = await _context.Clients.Where(b => b.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            return book;
        }
    }
}
