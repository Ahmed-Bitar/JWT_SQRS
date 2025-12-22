using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PROGECT_LIB.CQRS.ClintQueries;
using PROGECT_LIB.Data.DbContext;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.CQRS.ClintHandlers
{
    public record GetClintByIdQuerireHandler : IRequestHandler<GetClintByIdQuerire, Doctor>
    {
        private readonly AppDbContext _context;

        public GetClintByIdQuerireHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Handle(GetClintByIdQuerire request, CancellationToken cancellationToken)
        {
            var book = await _context.Doctors.Where(b => b.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            return book;
        }
    }
}
