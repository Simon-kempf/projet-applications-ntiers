using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
    public class Denonciation : IDenonciation
    {
        public Denonciation() : base(0)
        {

        }

        public Denonciation(DateTime horodatage, Personne informateur, Personne suspect, Delit delit, string? pays) : base(0)
        {
            Horodatage = horodatage;
            Informateur = informateur;
            informateur.Statut = Statut.INFORMATEUR;
            Suspect = suspect;
            suspect.Statut = Statut.SUSPECT;
            Delit = delit;

            if(pays != null) { PaysEvasion = new PaysEvasion(pays); }
        }


		public Denonciation(DateTime horodatage, int id, Personne informateur, Personne suspect, Delit delit, string? pays, Reponse reponse) : base(id)
        {
            Horodatage = horodatage;
            Informateur = informateur;
            informateur.Statut = Statut.INFORMATEUR;
            Suspect = suspect;
            suspect.Statut = Statut.SUSPECT;
            Delit = delit;
            Reponse = reponse;

            if (pays != null) { PaysEvasion = new PaysEvasion(pays); }
        }

		public Denonciation(DateTime horodatage, Personne informateur, Personne suspect, Delit delit, string? pays, Reponse reponse) : base(0)
		{
			Horodatage = horodatage;
			Informateur = informateur;
			informateur.Statut = Statut.INFORMATEUR;
			Suspect = suspect;
			suspect.Statut = Statut.SUSPECT;
			Delit = delit;
			Reponse = reponse;

			if (pays != null) { PaysEvasion = new PaysEvasion(pays); }
		}
	}
}
