using JeBalance.Domain.Model;
using MediatR;
using ParkNGo.Domain.Repositories;

namespace ParkNGo.Domain.Queries;

public class FindPersonnesQueryHandler : IRequestHandler<FindPersonnesQuery, (IEnumerable<Personne> Results, int Total)>
{
    private readonly IPersonneRepository _repository;

    public FindPersonnesQueryHandler(IPersonneRepository repository) => _repository = repository;

    public Task<(IEnumerable<Personne> Results, int Total)> Handle(FindPersonnesQuery query, CancellationToken cancellationToken)
    {
        return _repository.Find(
            query.Pagination.Limit, 
            query.Pagination.Offset,
            query.Specification);
    }
}
