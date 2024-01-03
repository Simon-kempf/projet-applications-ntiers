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
