using JeBalance.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.VIP
{
	public class FindVIPsQuery : IRequest<(IEnumerable<Personne> Results, int Total)>
	{
		public (int Limit, int Offset) Pagination { get; }

		public FindVIPsQuery(int limit, int offset)
		{
			Pagination = (limit, offset);
		}
	}
}
