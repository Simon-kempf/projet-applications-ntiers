using JeBalance.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.PersonneCommands
{
    public class UpdatePersonneCommand : IRequest<int>
    {
        public int Id { get; }
        public Personne Personne { get; }

        public UpdatePersonneCommand(int id, string nom, string prenom, Statut statut, int estVIP, int estCalomniateur, Role role, int codePostal, string nomDeCommune, string nomDeVoie, int numeroDeVoie)
        {
            Id = id;
            bool vip = (estVIP == 1) ? true : false;
            bool calomniateur = (estCalomniateur == 1) ? true : false;
            Adresse adresse = new Adresse(codePostal, nomDeCommune, nomDeVoie, numeroDeVoie);
            Personne = new Personne(id, nom, prenom, statut, vip, calomniateur, role, adresse);
        }
    }
}
