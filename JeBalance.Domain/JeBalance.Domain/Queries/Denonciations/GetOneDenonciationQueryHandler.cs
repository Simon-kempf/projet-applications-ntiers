using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using MediatR;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.Queries.Denonciations;

namespace JeBalance.Domain.Queries;

public class GetOneDenonciationQueryHandler : IRequestHandler<GetOneDenonciationQuery, Denonciation>
{
    private readonly IDenonciationRepository _repository;

    public GetOneDenonciationQueryHandler(IDenonciationRepository repository) => _repository = repository;

    public Task<Denonciation> Handle(GetOneDenonciationQuery query, CancellationToken cancellationToken) => _repository.GetOne(query.Id);
}
