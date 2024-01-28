using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Commands.DenonciationCommands
{
    public class CreateDenonciationCommand : IRequest<int>
    {
        public Denonciation Denonciation { get; }

		public CreateDenonciationCommand(
            string NomInformateur,
			string PrenomInformateur,
			int CodePostalInformateur,
			string NomDeCommuneInformateur,
			int NumeroDeVoieInformateur,
			string NomDeVoieInformateur,
			string NomSuspect,
			string PrenomSuspect,
			int CodePostalSuspect,
			string NomDeCommuneSuspect,
			int NumeroDeVoieSuspect,
			string NomDeVoieSuspect,
			Delit Delit,
            string? PaysEvasion
			) => Denonciation = new Denonciation(DateTime.Now,
			                                                    new Personne(NomInformateur, PrenomInformateur, Statut.INFORMATEUR, new Adresse(CodePostalInformateur, NomDeCommuneInformateur, NomDeVoieInformateur, NumeroDeVoieInformateur)),
			                                                    new Personne(NomSuspect, PrenomSuspect, Statut.SUSPECT, new Adresse(CodePostalSuspect, NomDeCommuneSuspect, NomDeVoieSuspect, NumeroDeVoieSuspect)),
			                                                    Delit,
			                                                    PaysEvasion,
			                                                    new Reponse());
    }
}
