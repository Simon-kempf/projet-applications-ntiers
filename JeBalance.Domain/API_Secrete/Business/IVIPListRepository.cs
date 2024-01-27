using JeBalance.Domain.Model;

namespace API_Secrete.Business
{
    public interface IVIPListRepository
    {
        Personne? Rechercher(int id);

        void Supprimer(int id);

        void Ajouter(Personne person);
        IReadOnlyCollection<Personne> Lister();
    }
}
