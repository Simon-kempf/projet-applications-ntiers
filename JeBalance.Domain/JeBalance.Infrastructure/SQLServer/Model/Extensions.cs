using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Model.Utilisateurs;
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
                denonciation.Informateur.ToDomainPersonne(),
				denonciation.Suspect.ToDomainPersonne(),
                (Delit)denonciation.Delit,
                denonciation.PaysEvasion,
				denonciation.Reponse.ToDomain()
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
				PaysEvasion = denonciation.PaysEvasion!.Value,
				Reponse = denonciation.Reponse!.ToSQLS()
			};
		}

		public static string ToSQLSPersonne(this Personne personne)
		{
			if (personne == null)
				return "";
			return personne.Id + ";" 
				+ personne.Nom!.Value + ";" 
				+ personne.Prenom!.Value + ";" 
				+ personne.Statut.ToString() + ";"
				+ personne.Adresse.toSQLS();
		}

		public static Personne ToDomainPersonne(this string personne)
		{
			if (personne == "")
				return null;
			
			string[] composantes = personne.Split(";");
			Adresse adresse = new Adresse(int.Parse(composantes[4]), 
				composantes[5],
				composantes[6],
				int.Parse(composantes[7]));

			return new Personne(
				int.Parse(composantes[0]),
				composantes[1],
				composantes[2],
				(Statut)Enum.Parse(typeof(Statut), composantes[3]),
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
			personne.Adresse.toDomain());
		}
		public static PersonneSQLS ToSQLS(this Personne personne)
		{
			return new PersonneSQLS
			{
				Id = personne.Id,
				Nom = personne.Nom!.Value,
				Prenom = personne.Prenom!.Value,
                Statut = (int)personne.Statut!,
				Adresse = personne.Adresse.toSQLS()
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
					: int.Parse(composantes[1]);//TODO

			return new Reponse(date, type, retribution);
		}


		public static string ToSQLS(this Reponse reponse)
		{
			if (reponse == null)
				return "";
			return (reponse.Horodatage).ToString() + ";" + reponse.Retribution + ";" + ((int)reponse.Type).ToString();
		}

		/*
		public static VIP ToDomain(this VIPSQLS vip)
		{
			return new VIP(
				vip.Id,
				vip.Nom,
				vip.Prenom);
		}
		public static VIPSQLS ToSQLS(this VIP vip)
		{
			return new VIPSQLS
			{
				Id = vip.Id,
				Nom = vip.Nom!.Value,
				Prenom = vip.Prenom!.Value,
				Statut = 4
			};
		}

		public static IQueryable<T> Apply<T>(this IQueryable<T> query, Expression<Func<T, bool>> predicate)
		{
			return query.Where(predicate);
		}

		public static Expression<Func<InfraType, bool>> ToSQLSExpression<DomainType, InfraType>(this Specification<DomainType> specification)
		where InfraType : DomainType
		{
			var expression = specification.ToExpression();
			var param = Expression.Parameter(typeof(InfraType));
			return Expression.Lambda<Func<InfraType, bool>>(
				expression.Body.Replace(expression.Parameters[0], param),
				param);

		}

		private static Expression Replace(this Expression expression,
		Expression searchEx, Expression replaceEx)
		{
			return new ReplaceVisitor(searchEx, replaceEx).Visit(expression);
		}

		internal class ReplaceVisitor : ExpressionVisitor
		{
			private readonly Expression _from, _to;
			public ReplaceVisitor(Expression from, Expression to)
			{
				_from = from;
				_to = to;
			}
			public override Expression Visit(Expression node)
			{
				return node == _from ? _to : base.Visit(node);
			}
		}*/

	}
}
