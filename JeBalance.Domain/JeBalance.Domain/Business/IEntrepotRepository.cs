namespace JeBalance.Domain.Business
{
    public interface IEntrepotRepository
    {
        Entrepot? Rechercher(int id);

        IReadOnlyCollection<Entrepot> Lister();
    }
}
