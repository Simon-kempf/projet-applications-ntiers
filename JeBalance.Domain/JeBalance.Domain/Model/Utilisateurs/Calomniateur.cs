using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model.Utilisateurs
{
    public class Calomniateur : Personne
    {
        public Calomniateur(string nom, string prenom) : base(0)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.CALOMNIATEUR;
        }
        public Calomniateur(int id, string nom, string prenom) :
       base(id)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.CALOMNIATEUR;
        }
    }
}
