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
                new Personne(denonciation.Informateur!.Id, null, null),
                new Personne(denonciation.Suspect!.Id, null, null),
                (Delit)denonciation.Delit,
                denonciation.PaysEvasion!.Value
            );
        }
        public static DenonciationSQLS ToSQLS(this Denonciation denonciation)
        {
            return new DenonciationSQLS
            {
                Id = denonciation.Id,
                IdInformateur = denonciation.Informateur!.Id,
                IdSuspect = denonciation.Suspect!.Id,
                Delit = (int)denonciation.Delit!.Value,
                StatutInfo = (int)denonciation.Informateur!.Statut,
                StatutSuspect = (int)denonciation.Suspect!.Statut,
                Horodatage = denonciation.Horodatage!.Value
            };
        }

		public static Personne ToDomain(this PersonneSQLS personne)
		{
			return new Personne(
			personne.Id,
			personne.Nom,
			personne.Prenom,
            (Statut)personne.Statut);
		}
		public static PersonneSQLS ToSQLS(this Personne personne)
		{
			return new PersonneSQLS
			{
				Id = personne.Id,
				Nom = personne.Nom!.Value,
				Prenom = personne.Prenom!.Value,
                Statut = (int)personne.Statut!
			};
		}

		public static Reponse ToDomain(this ReponseSQLS reponse)
		{
			return new Reponse(
				reponse.Horodatage,
				reponse.Id,
				(Domain.Model.Type)reponse.Type,
				reponse.Retribution);
		}
		public static ReponseSQLS ToSQLS(this Reponse reponse)
		{
			return new ReponseSQLS
			{
				Horodatage = reponse.Horodatage,
				Id = reponse.Id,
				Type = (int)reponse.Type,
				Retribution = reponse.Retribution!.Value
			};
		}

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
		}

	}
}
