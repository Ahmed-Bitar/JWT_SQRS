using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using PROGECT_LIB.CQRS.ClintCommand;
using PROGECT_LIB.Data.Model;
using PROGECT_LIB.Repo;

namespace PROGECT_LIB.CQRS.ClintHandlers
{
    public class UpdateClintCommandHandler : IRequestHandler<UpdateClientCommand, Client>
    {
        private readonly IBaseRepo<Client> _repo;

        public UpdateClintCommandHandler(IBaseRepo<Client> repo)
        {
            _repo = repo;
        }


        public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var updatedBook = await _repo.UpdateItem(request.Client);
            return updatedBook;
        }
    }

}
