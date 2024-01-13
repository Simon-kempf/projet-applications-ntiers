using JeBalance.Domain.Model;
using MediatR;

namespace ParkNGo.Domain.Queries;

public class GetOnePersonneQuery : IRequest<Personne>
{
    public int Id { get; }

    public GetOnePersonneQuery(int id) => Id = id;
}
