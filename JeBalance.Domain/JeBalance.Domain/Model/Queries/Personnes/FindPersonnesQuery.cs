using JeBalance.Domain.Model;
using MediatR;

namespace ParkNGo.Domain.Queries;

public class FindPersonnesQuery : IRequest<(IEnumerable<Personne> Results, int Total)>
{
    public (int Limit, int Offset) Pagination { get; }
    public FindPersonnesSpecification Specification { get; }

    public FindPersonnesQuery(int limit, int offset, string? nom, string? prenom, int? id, Statut? statut)
    {
        Pagination = (limit, offset);
        Specification = new FindPersonnesSpecification(nom, prenom, id, statut);
    }
}
