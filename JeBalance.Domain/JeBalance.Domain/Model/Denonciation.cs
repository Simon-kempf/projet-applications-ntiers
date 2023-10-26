using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
    internal class Denonciation : Entity
    {
        private Personne Informateur { get; }
        private Personne Suspect { get; }
        private Delit Delit { get; }
        private PaysEvasion? PaysEvasion { get; }
        private Reponse? Reponse { get; }
        public Denonciation(Personne informateur, Personne suspect, Delit delit, string? pays) : base(0)
        {
            Informateur = informateur;
            informateur.Statut = Statut.INFORMATEUR;
            Suspect = suspect;
            suspect.Statut = Statut.SUSPECT;
            Delit = delit;

            if(pays != null) { PaysEvasion = new PaysEvasion(pays); }
        }

        public Denonciation(int id, Personne informateur, Personne suspect, Delit delit, string? pays) : base(id)
        {
            Informateur = informateur;
            informateur.Statut = Statut.INFORMATEUR;
            Suspect = suspect;
            suspect.Statut = Statut.SUSPECT;
            Delit = delit;

            if (pays != null) { PaysEvasion = new PaysEvasion(pays); }
        }
    }
}
