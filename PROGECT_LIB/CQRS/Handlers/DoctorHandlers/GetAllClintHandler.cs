using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PROGECT_LIB.CQRS.Quires.DoctorQuires;
using PROGECT_LIB.Data.Model;
using PROGECT_LIB.Repo;

namespace PROGECT_LIB.CQRS.Handlers.DoctorHandlers
{
    public class GetAllClintHandler : IRequestHandler<GetAllDoctorQuires, List<Doctor>>
    {
        private readonly IBaseRepo<Doctor> _repo;

        public GetAllClintHandler(IBaseRepo<Doctor> repo)
        {
            _repo = repo;
        }

 

        public Task<List<Doctor>> Handle(GetAllDoctorQuires request, CancellationToken cancellationToken)
        {
            var books = _repo.GetAllItems();
            return Task.FromResult(books);
        }
    }
}
