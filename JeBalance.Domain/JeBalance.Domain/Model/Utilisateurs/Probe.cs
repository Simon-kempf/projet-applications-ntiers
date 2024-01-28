using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model.Utilisateurs
{
    public class Probe : Personne
    {
        public Probe(string nom, string prenom) : base(0)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.NONE;
        }
        public Probe(int id, string nom, string prenom) :
       base(id)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.NONE;
        }
    }
}
