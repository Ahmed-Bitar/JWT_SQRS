using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.CQRS.ClintQueries
{
    public record  GetClintByIdQuerire : IRequest<Doctor>
    {
        public int Id { get; }

        public GetClintByIdQuerire(int id)
        {
            Id = id;
        }
    }
}
