using API.Business;
using JeBalance.Domain.Model.Utilisateurs;

namespace API.DataAccess
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly List<Categorie> _donnees = new();

        public CategorieRepository()
        {
            var vip = new Categorie("VIP");

            vip.AjouterPersonne(new VIP("Jean", "Michel"));

            _donnees.Add(vip);
        }

        public Categorie? Rechercher(string nom)
        {
            return _donnees.FirstOrDefault(c => c.Nom == nom);
        }

        public IReadOnlyCollection<Categorie> Lister()
        {
            return _donnees;
        }
    }
}
