using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
    public class CreatePersonneCommandHandler : IRequestHandler<CreateDenonciationCommand, int>
    {
        private readonly IDenonciationRepository _repository;

        public CreatePersonneCommandHandler(IDenonciationRepository repository) => _repository = repository;

        public Task<int> Handle(CreateDenonciationCommand command, CancellationToken cancellationToken)
        {
            return _repository.Create(command.Denonciation);
        }
    }
}
