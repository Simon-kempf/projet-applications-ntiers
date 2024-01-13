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
        public Denonciation(DateTime horodatage, IPersonne informateur, IPersonne suspect, Delit delit, string? pays) : base(0)
        {
            Horodatage = horodatage;
            Informateur = informateur;
            informateur.Statut = Statut.INFORMATEUR;
            Suspect = suspect;
            suspect.Statut = Statut.SUSPECT;
            Delit = delit;

            if(pays != null) { PaysEvasion = new PaysEvasion(pays); }
        }

        public Denonciation(DateTime horodatage, int id, IPersonne informateur, IPersonne suspect, Delit delit, string? pays) : base(id)
        {
            Horodatage = horodatage;
            Informateur = informateur;
            informateur.Statut = Statut.INFORMATEUR;
            Suspect = suspect;
            suspect.Statut = Statut.SUSPECT;
            Delit = delit;

            if (pays != null) { PaysEvasion = new PaysEvasion(pays); }
        }

        public void repondre(Reponse reponse)
        {
            Reponse = reponse;
        }
    }
}
