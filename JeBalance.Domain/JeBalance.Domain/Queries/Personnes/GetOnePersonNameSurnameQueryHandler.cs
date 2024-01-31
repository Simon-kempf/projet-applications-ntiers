using JeBalance.Domain.Model;
using JeBalance.Domain.Queries;
using MediatR;
using JeBalance.Domain.Repositories;

namespace JeBalance.Domain.Queries;

public class GetOnePersonneNameSurnameQueryHandler : IRequestHandler<GetOnePersonneNameSurnameQuery, Personne>
{
    private readonly IPersonneRepository _repository;

    public GetOnePersonneNameSurnameQueryHandler(IPersonneRepository repository) => _repository = repository;

    public Task<Personne> Handle(GetOnePersonneNameSurnameQuery query, CancellationToken cancellationToken)
    {
        string adresse = (new Adresse(query.CodePostal!,
        query.NomDeCommune!,
        query.NomDeVoie!,
        query.NumeroDeVoie!)).toString()!;
        return _repository.GetOne(query.Nom!, query.Prenom!,adresse);
    }
}
