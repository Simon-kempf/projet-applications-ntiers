namespace API.Business
{
    public interface ICategorieRepository
    {
        Categorie? Rechercher(string nom);

        IReadOnlyCollection<Categorie> Lister();
    }
}
