using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PROGECT_LIB.CQRS.Command.DoctorCommand;
using PROGECT_LIB.Data.Model;
using PROGECT_LIB.Repo;

namespace PROGECT_LIB.CQRS.Handlers.DoctorHandlers
{
    public record InsertClintCommandHandler : IRequestHandler<InsertClientCommand, Doctor>
    {
        public IBaseRepo<Doctor> _baseRepo { get; }

        public InsertClintCommandHandler(IBaseRepo<Doctor> _baseRepo)
        {
            this._baseRepo = _baseRepo;
        }
        public async Task<Doctor> Handle(InsertClientCommand request, CancellationToken cancellationToken)
        {
            await _baseRepo.InsertItem(request.Client);
            return await Task.FromResult(request.Client);
        }
    }
}
