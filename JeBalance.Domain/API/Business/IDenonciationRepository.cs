using JeBalance.Domain.Model;

namespace API.Business
{
    public interface IDenonciationRepository
    {
        Denonciation? Rechercher(int id);

        IReadOnlyCollection<Denonciation> Lister();

        void Ajouter(Denonciation denonciation);
    }
}
