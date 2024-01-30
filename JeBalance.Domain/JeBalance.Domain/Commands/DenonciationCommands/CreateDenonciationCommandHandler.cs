using JeBalance.Domain.Repositories;
using MediatR;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
    public class CreatePersonneCommandHandler : IRequestHandler<CreateDenonciationCommand, int>
    {
        private readonly IDenonciationRepository _denonciationRepository;
		private readonly IPersonneRepository _personneRepository;

		public CreatePersonneCommandHandler(IDenonciationRepository denonciationRepository, IPersonneRepository personneRepository)
        {
			_denonciationRepository = denonciationRepository;
            _personneRepository = personneRepository;
		}

        public async Task<int> Handle(CreateDenonciationCommand command, CancellationToken cancellationToken)
        {
            int idInformateur = await _personneRepository.Create(command.Denonciation.Informateur!);
            int idSuspect = await _personneRepository.Create(command.Denonciation.Suspect!);
            command.Denonciation.Informateur!.Id = idInformateur;
			command.Denonciation.Suspect!.Id = idSuspect;
			return await _denonciationRepository.Create(command.Denonciation);
        }
    }
}
