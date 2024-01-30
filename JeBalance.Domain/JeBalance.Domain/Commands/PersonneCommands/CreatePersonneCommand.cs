using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.PersonneCommands
{
    public class CreatePersonneCommand : IRequest<int>
    {
        public Personne Personne { get; }

        public CreatePersonneCommand(string nom, string prenom, Statut statut, int codePostal, string nomDeCommune, string nomDeVoie, int numeroDeVoie)
		{
			Adresse adresse = new Adresse(codePostal, nomDeCommune, nomDeVoie, numeroDeVoie);
			Personne = new Personne(nom, prenom, statut, adresse);
		}
    }
}
