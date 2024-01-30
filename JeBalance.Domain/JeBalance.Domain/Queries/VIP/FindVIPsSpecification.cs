using JeBalance.Domain.Model;
using JeBalance.Domain.Contracts;
using System.Linq.Expressions;

namespace JeBalance.Domain.Queries.VIP
{
	public class FindVIPsSpecification : Specification<Personne>
	{

		public FindVIPsSpecification() 
		{
		}

		public override Expression<Func<Personne, bool>> ToExpression()
		{
			return personne => personne.estVIP;
		}
	}
}
