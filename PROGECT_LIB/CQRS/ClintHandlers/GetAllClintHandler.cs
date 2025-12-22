using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PROGECT_LIB.CQRS.ClintQueries;
using PROGECT_LIB.Data.Model;
using PROGECT_LIB.Repo;

namespace PROGECT_LIB.CQRS.ClintHandlers
{
    public class GetAllClintHandler : IRequestHandler<GettAlClintsQueries, List<Doctor>>
    {
        private readonly IBaseRepo<Doctor> _repo;

        public GetAllClintHandler(IBaseRepo<Doctor> repo)
        {
            _repo = repo;
        }

 

        public Task<List<Doctor>> Handle(GettAlClintsQueries request, CancellationToken cancellationToken)
        {
            var books = _repo.GetAllItems();
            return Task.FromResult(books);
        }
    }
}
