using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PROGECT_LIB.Data.Model;

namespace PROGECT_LIB.CQRS.ClintCommand
{
    public class DeleteClientCommand : IRequest<Client>
    {
        public int Id { get; set; }
    }
}
