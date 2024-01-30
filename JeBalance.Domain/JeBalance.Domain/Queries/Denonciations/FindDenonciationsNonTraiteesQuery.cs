using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.Denonciations
{
	public class FindDenonciationsNonTraiteesQuery : IRequest<(IEnumerable<Denonciation> Results, int Total)>
	{
		public (int Limit, int Offset) Pagination { get; }
		public FindNonTraiteesSpecification Specification { get; }

		public FindDenonciationsNonTraiteesQuery(int limit, int offset) {
			Pagination = (limit, offset);
			Specification = new FindNonTraiteesSpecification();
		}

	}
}
