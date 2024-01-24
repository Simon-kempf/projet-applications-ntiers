using JeBalance.Domain.Model;
using MediatR;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Queries;

public class GetOnePersonneQueryHandler : IRequestHandler<GetOnePersonneQuery, Personne>
{
    private readonly IPersonneRepository _repository;

    public GetOnePersonneQueryHandler(IPersonneRepository repository) => _repository = repository;

    public Task<Personne> Handle(GetOnePersonneQuery query, CancellationToken cancellationToken) => _repository.GetOne(query.Id);
}
