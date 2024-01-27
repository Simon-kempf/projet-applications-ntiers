using JeBalance.Domain.Model;
using JeBalance.Domain.Contracts;
using System.Linq.Expressions;

namespace JeBalance.Domain.Queries.VIP
{
	public class FindVIPsSpecification : Specification<Personne>
	{
		private readonly string? _nameSearch;
		private readonly string? _surnameSearch;

		public FindVIPsSpecification(string? nameSearch, string? surnameSearch) 
		{
			_nameSearch = nameSearch?.Trim()?.ToLower();
			_surnameSearch = surnameSearch?.Trim()?.ToLower();
		}

		public override Expression<Func<Personne, bool>> ToExpression()
		{
			return _nameSearch == null
				? vip => vip.Prenom!.Value == _surnameSearch
				: (_surnameSearch == null
					? vip => vip.Nom!.Value == _nameSearch
					: vip => vip.Nom!.Value == _nameSearch && vip.Prenom!.Value == _surnameSearch
				);
				}
	}
}
