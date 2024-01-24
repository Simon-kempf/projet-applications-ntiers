using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;

namespace JeBalance.Domain.Repositories;

public interface IPersonneRepository : Repository<Personne>
{
    Task<bool> Create(Personne personne);

    Task<int> CreateAll(IEnumerable<Personne> newCurrentPersons);

    Task<(IEnumerable<Personne> Results, int Total)> Find(
        int limit,
        int offset,
        params Specification<Personne>[] specifications);
    
    Task<bool> HasAny(params Specification<Personne>[] specifications);
    
    Task<IEnumerable<Personne>> FindAll(params Specification<Personne>[] specifications);

    Task<int> RemoveAll(params Specification<Personne>[] specifications);
}
