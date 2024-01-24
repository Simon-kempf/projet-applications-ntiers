using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using System.Linq.Expressions;

namespace JeBalance.Domain.Queries;

public class FindPersonnesSpecification : Specification<Personne>
{
    private readonly string? _nameSearch;
    private readonly string? _surnameSearch;
    private readonly int? _id;
    private readonly Statut _statut;

    public FindPersonnesSpecification(string? nom, string? prenom,  int? id, Statut? statut)
    {
        _nameSearch = nom?.Trim()?.ToLower();
        _surnameSearch = prenom?.Trim()?.ToLower();
        _id = id ?? 1;
        _statut = statut ?? Statut.NONE;
    }

    public override Expression<Func<Personne, bool>> ToExpression()
    {
        return (_nameSearch == null || _surnameSearch == null)
            ? (_id == null ? personne => personne.Statut == _statut : personne => personne.Id == _id)
            : (personne => personne.Nom!.Value.Contains(_nameSearch) && personne.Prenom!.Value.Contains(_surnameSearch));
    }
}