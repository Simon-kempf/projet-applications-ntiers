using API.Business;
using JeBalance.Domain.Model;
using JeBalance.Domain.Model.Utilisateurs;

namespace API.DataAccess
{
    public class DenonciationRepository : IDenonciationRepository
    {
        private readonly List<Denonciation> _donnees = new();

        public DenonciationRepository()
        {
            var denonciation = new Denonciation(new Personne("Machin", "Bidule"), new Personne("Truc", "Chose"), Delit.EvasionFiscale, "France");
            _donnees.Add(denonciation);
        }

        public Denonciation? Rechercher(int id)
        {
            return _donnees.FirstOrDefault(d => d.Id == id);
        }

        public IReadOnlyCollection<Denonciation> Lister()
        {
            return _donnees;
        }
    }
}
