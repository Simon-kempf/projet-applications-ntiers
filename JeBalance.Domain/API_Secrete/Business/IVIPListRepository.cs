using JeBalance.Domain.Model;

namespace API_Secrete.Business
{
    public interface IVIPListRepository
    {
        IPersonne? Rechercher(int id);

        void Supprimer(int id);

        void Ajouter(IPersonne person);
        IReadOnlyCollection<IPersonne> Lister();
    }
}
