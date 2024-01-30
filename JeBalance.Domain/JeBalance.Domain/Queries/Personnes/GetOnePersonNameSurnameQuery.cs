using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using MediatR;

namespace JeBalance.Domain.Queries;

public class GetOnePersonneNameSurnameQuery : IRequest<Personne>
{

    public string? Nom { get; }

    public string? Prenom { get; }

    public int CodePostal { get; }

    public string? NomDeCommune { get; }

    public string? NomDeVoie { get; }

    public int NumeroDeVoie { get; }

    public GetOnePersonneNameSurnameQuery(string nom, string prenom,int codePostal,string nomDeCommune, string nomDeVoie, int numeroDeVoie)
    {
        Nom = nom;
        Prenom = prenom;
        CodePostal = codePostal;
        NomDeCommune = nomDeCommune;
        NomDeVoie = nomDeVoie;
        NumeroDeVoie = numeroDeVoie;
    }


}
