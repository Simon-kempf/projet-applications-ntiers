using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.ValueObjects;
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
            string adresseInformateur = new Adresse(command.Denonciation.Informateur!.Adresse.CodePostal.Value,
                                                    command.Denonciation.Informateur!.Adresse.NomDeCommune.Value,
                                                    command.Denonciation.Informateur!.Adresse.NomDeVoie.Value,
                                                    command.Denonciation.Informateur!.Adresse.NumeroDeVoie.Value).toString();
			
            string adresseSuspect = new Adresse(command.Denonciation.Suspect!.Adresse.CodePostal.Value,
													command.Denonciation.Suspect!.Adresse.NomDeCommune.Value,
													command.Denonciation.Suspect!.Adresse.NomDeVoie.Value,
													command.Denonciation.Suspect!.Adresse.NumeroDeVoie.Value).toString();
			try
			{
				var informateur = await _personneRepository.GetOne(command.Denonciation.Informateur.Nom!.Value,
																	command.Denonciation.Informateur.Prenom!.Value,
																	adresseInformateur
																	);
				if (informateur.estCalomniateur)
				{
					return -1;
				}
			}
			catch( Exception ex )
			{
				var _ = await _personneRepository.Create(command.Denonciation.Informateur!);
			}
			try
			{
				var supect = await _personneRepository.GetOne(command.Denonciation.Suspect.Nom!.Value,
																	command.Denonciation.Suspect.Prenom!.Value,
																	adresseSuspect
																	);
				if (supect.estVIP)
				{
					var informateur = await _personneRepository.GetOne(command.Denonciation.Informateur.Nom!.Value,
																	command.Denonciation.Informateur.Prenom!.Value,
																	adresseInformateur
																	);

					await _personneRepository.Update(informateur.Id, new Personne(informateur.Id, informateur.Nom!.Value, informateur.Prenom!.Value, informateur.Statut, informateur.estVIP, true, informateur.Role, informateur.Adresse));
					return -1;
				}
			}
			catch ( Exception ex )
			{
				var _ = await _personneRepository.Create(command.Denonciation.Suspect!);
			}
			
			command.Denonciation.Informateur = await _personneRepository.GetOne(command.Denonciation.Informateur.Nom!.Value,
																	command.Denonciation.Informateur.Prenom!.Value,
																	adresseInformateur
																	);
			command.Denonciation.Suspect = await _personneRepository.GetOne(command.Denonciation.Suspect.Nom!.Value,
																	command.Denonciation.Suspect.Prenom!.Value,
																	adresseSuspect
																	);

			return await _denonciationRepository.Create(command.Denonciation);
        }
    }
}
