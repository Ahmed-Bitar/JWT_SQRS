using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.CQRS.Quires.DoctorQuires
{
    public class GetDoctorByIdQuerire : IRequest<Doctor>
    {
        public int Id { get; }

        public GetDoctorByIdQuerire(int id)
        {
            Id = id;
        }
    }
}
