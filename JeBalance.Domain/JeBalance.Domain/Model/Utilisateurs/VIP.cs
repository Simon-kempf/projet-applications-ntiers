using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Model.Utilisateurs
{
    public class VIP : Personne
    {
        public VIP(string nom, string prenom) : base(0)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.VIP;
        }
        public VIP(int id, string nom, string prenom) :
       base(id)
        {
            Nom = new Nom(nom);
            Prenom = new Prenom(prenom);
            Statut = Statut.VIP;
        }

		public VIP() : base(0) {}
	}
}
