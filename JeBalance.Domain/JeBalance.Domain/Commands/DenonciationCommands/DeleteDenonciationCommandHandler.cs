using JeBalance.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
    public class DeletePersonneCommandHandler : IRequestHandler<DeleteDenonciationCommand, bool>
    {
        private readonly IDenonciationRepository _repository;

        public DeletePersonneCommandHandler(IDenonciationRepository repository) => _repository = repository;

        public Task<bool> Handle(DeleteDenonciationCommand command, CancellationToken cancellationToken)
        {
            return _repository.Delete(command.Id);
        }
    }
}
