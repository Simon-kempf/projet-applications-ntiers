using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Model
{
    public static class Extensions
    {
        public static Denonciation ToDomain(this DenonciationSQLS denonciation)
        {
            return new Denonciation(
                denonciation.Horodatage,
				denonciation.Id,
                denonciation.Informateur!.ToDomainPersonne(),
				denonciation.Suspect!.ToDomainPersonne(),
                (Delit)denonciation.Delit,
                denonciation.PaysEvasion,
				denonciation.Reponse!.ToDomain(),
				denonciation.EstTraitee
			);
        }

		public static DenonciationSQLS ToSQLS(this Denonciation denonciation)
		{
			return new DenonciationSQLS
			{
				Id = denonciation.Id,
				Informateur = denonciation.Informateur!.ToSQLSPersonne(),
				Suspect = denonciation.Suspect!.ToSQLSPersonne(),
				Delit = (int)denonciation.Delit!.Value,
				StatutInfo = (int)denonciation.Informateur!.Statut,
				StatutSuspect = (int)denonciation.Suspect!.Statut,
				Horodatage = denonciation.Horodatage!.Value,
				PaysEvasion = denonciation.Delit == (Delit)2 ? denonciation.PaysEvasion!.Value : "Non applicable",
				Reponse = denonciation.Reponse!.ToSQLS(),
				EstTraitee = denonciation.EstTraitee
			};
		}

		public static string ToSQLSPersonne(this Personne personne)
		{
			if (personne == null)
				return "";
			int estVIP = personne.estVIP ? 1 : 0;
			int estCalomniateur = personne.estCalomniateur ? 1 : 0;
			return personne.Id + ";" 
				+ personne.Nom!.Value + ";" 
				+ personne.Prenom!.Value + ";" 
				+ personne.Statut.ToString() + ";"
				+ estVIP.ToString() + ";"
				+ estCalomniateur.ToString() + ";"
				+ personne.Role.ToString() + ";"
				+ personne.Adresse.toSQLS();
		}

		public static Personne ToDomainPersonne(this string personne)
		{
			if (personne == "")
				return null;
			
			string[] composantes = personne.Split(";");
			Adresse adresse = new Adresse(int.Parse(composantes[7]), 
				composantes[8],
				composantes[9],
				int.Parse(composantes[10]));

			bool estVIP = composantes[4] == "1" ? true : false;
			bool estCalomniateur = composantes[5] == "1" ? true : false;

			return new Personne(
				int.Parse(composantes[0]),
				composantes[1],
				composantes[2],
				(Statut)Enum.Parse(typeof(Statut), composantes[3]),
				estVIP,
				estCalomniateur,
				(Role)Enum.Parse(typeof(Role), composantes[6]),
				adresse);
		}

		public static string toSQLS(this Adresse adresse)
		{
			return adresse.toString();
		}

		public static Adresse toDomain(this string adresse)
		{
			string[] composantes = adresse.Split(";");
			Adresse result = new Adresse(int.Parse(composantes[0]),
				composantes[1],
				composantes[2],
				int.Parse(composantes[3]));
			return result;
		}

		public static Personne ToDomain(this PersonneSQLS personne)
		{
			return new Personne(
			personne.Id,
			personne.Nom,
			personne.Prenom,
			(Statut)personne.Statut,
			personne.estVIP == 1,
			personne.estCalomniateur == 1,
			(Role)personne.Role,
			personne.Adresse.toDomain()) ;
		}
		public static PersonneSQLS ToSQLS(this Personne personne)
		{
			return new PersonneSQLS
			{
				Id = personne.Id,
				Nom = personne.Nom!.Value,
				Prenom = personne.Prenom!.Value,
                Statut = (int)personne.Statut!,
				Adresse = personne.Adresse.toSQLS(),
				estVIP = personne.estVIP ? 1 : 0,
				estCalomniateur = personne.estCalomniateur ? 1 : 0,
				Role = (int)personne.Role!
			};
		}

		public static Reponse ToDomain(this String reponse)
		{
			if (reponse == "")
				return new Reponse();
			string[] composantes = reponse.Split(";");

			DateTime date = (composantes[0] == null) 
				? new DateTime() 
				: DateTime.Parse(composantes[0]);
			Domain.Model.Type type = (composantes[2] == null) 
					? 0 
					: (Domain.Model.Type)Enum.Parse(typeof(Domain.Model.Type), composantes[2]);
			int retribution = (composantes[1] == null)
					? 0
					: int.Parse(composantes[1]);

			return new Reponse(date, type, retribution);
		}


		public static string ToSQLS(this Reponse reponse)
		{
			if (reponse == null)
				return "";
			return (reponse.Horodatage).ToString() + ";" + reponse.Retribution + ";" + ((int)reponse.Type).ToString();
		}
	}
}
