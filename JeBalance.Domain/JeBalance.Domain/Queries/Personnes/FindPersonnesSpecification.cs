using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using System.Linq.Expressions;

namespace JeBalance.Domain.Queries;

public class FindPersonnesSpecification : Specification<Personne>
{
    private readonly string? _nameSearch;
    private readonly string? _surnameSearch;
    private readonly int _codePostalSearch;
    private readonly string? _nomDeCommuneSearch;
    private readonly string? _nomDeVoieSearch;
    private readonly int _numeroDeVoieSearch;

    public FindPersonnesSpecification(string? nom, string? prenom)
    {
        _nameSearch = nom?.Trim()?.ToLower();
        _surnameSearch = prenom?.Trim()?.ToLower();
    }

    public override Expression<Func<Personne, bool>> ToExpression()
    {
        return (_nameSearch == null || _surnameSearch == null || _codePostalSearch ==0|| _nomDeCommuneSearch == null || _nomDeVoieSearch == null || _numeroDeVoieSearch == 0)
            ? Personne => false
            : (personne => personne.Nom!.Value.Contains(_nameSearch) && personne.Prenom!.Value.Contains(_surnameSearch) && personne.Adresse.CodePostal.Value == _codePostalSearch && personne.Adresse.NomDeCommune.Value.Contains(_nomDeCommuneSearch) && personne.Adresse.NomDeVoie.Value.Contains(_nomDeVoieSearch) && personne.Adresse.NumeroDeVoie.Value == _numeroDeVoieSearch);
    }
}