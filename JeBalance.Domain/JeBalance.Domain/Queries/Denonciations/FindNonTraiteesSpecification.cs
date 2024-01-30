using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using System.Linq.Expressions;

namespace JeBalance.Domain.Queries.Denonciations
{
	public class FindNonTraiteesSpecification : Specification<Denonciation>
	{
		public FindNonTraiteesSpecification()
		{
		}

		public override Expression<Func<Denonciation, bool>> ToExpression()
		{
			return denonciation => !denonciation.EstTraitee;
		}
	}
}