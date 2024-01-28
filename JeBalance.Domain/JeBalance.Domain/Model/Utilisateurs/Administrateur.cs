using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model.Utilisateurs
{
    public class Administrateur : Personne
    {
        public Administrateur(string nom, string prenom) : base(0)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.ADMINISTRATEUR;
        }
        public Administrateur(int id, string nom, string prenom) :
       base(id)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.ADMINISTRATEUR;
        }
    }
}
