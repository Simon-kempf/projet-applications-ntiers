using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Repositories;

public interface IPersonneRepository : Repository<Personne>
{
    Task<int> Create(Personne personne);

    Task<int> CreateAll(IEnumerable<Personne> newCurrentPersons);

    public Task<Personne> GetOne(string nom,string prenom, string adresse);

    Task<(IEnumerable<Personne> Results, int Total)> Find(int limit, int offset, Specification<Personne> specifications);
    
    Task<bool> HasAny(Specification<Personne> specifications);
    
    Task<IEnumerable<Personne>> FindAll(params Specification<Personne>[] specifications);

}
