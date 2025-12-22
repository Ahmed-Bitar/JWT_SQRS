using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PROGECT_LIB.CQRS.ClintCommand;
using PROGECT_LIB.Data.Model;
using PROGECT_LIB.Repo;

namespace PROGECT_LIB.CQRS.ClintHandlers
{
    public record InsertClintCommandHandler : IRequestHandler<InsertClientCommand, Client>
    {
        public IBaseRepo<Client> _baseRepo { get; }

        public InsertClintCommandHandler(IBaseRepo<Client> _baseRepo)
        {
            this._baseRepo = _baseRepo;
        }
        public async Task<Client> Handle(InsertClientCommand request, CancellationToken cancellationToken)
        {
            await _baseRepo.InsertItem(request.Client);
            return await Task.FromResult(request.Client);
        }
    }
}
