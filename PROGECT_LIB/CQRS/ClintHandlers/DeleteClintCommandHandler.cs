using MediatR;
using Microsoft.EntityFrameworkCore;
using PROGECT_LIB.CQRS.ClintCommand;
using PROGECT_LIB.Data;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.CQRS.ClintHandlers
{
    public class DeleteClintCommandHandler: IRequestHandler<DeleteClientCommand, Client>
    {
        private readonly AppDbContext _context;

        public DeleteClintCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync(cancellationToken);

            return client;
        }
    }
}
