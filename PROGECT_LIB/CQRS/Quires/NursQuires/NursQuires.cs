using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.CQRS.Quires.NursQuires
{
    public class GetAllNurseQuires : IRequest<List<Doctor>>;

}
