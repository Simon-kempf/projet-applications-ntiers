using API_Secrete.Business;
using JeBalance.Domain.Model;
using JeBalance.Domain.Model.Utilisateurs;

namespace API_Secrete.DataAccess
{
    public class VIPListRepository : IVIPListRepository
    {
        private readonly VIPList _donnees = new();

        public VIPListRepository()
        {
            Ajouter(new VIP(0, "Jean", "Michel"));
            Ajouter(new VIP(1, "Bertrand", "Richard"));
            Ajouter(new VIP(2, "Claude", "François"));
        }

        public Personne? Rechercher(int id)
        {
            return _donnees.RechercherVIP(id);
        }

        public IReadOnlyCollection<Personne> Lister()
        {
            return _donnees.Vips;
        }

        public void Ajouter(Personne person)
        {
            _donnees.AjouterVIP(person);
        }

        public void Supprimer(int id)
        {
            var person = Rechercher(id);
            if(person != null)
            {
                _donnees.SupprimerVIP(person);
            }
        }
    }
}
