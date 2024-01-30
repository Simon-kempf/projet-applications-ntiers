using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JeBalance.Domain.Queries.Denonciations
{
	public class FindDenonciationsNonTraiteesQueryHandler : IRequestHandler<FindDenonciationsNonTraiteesQuery, (IEnumerable<Denonciation> Results, int Total)>
	{
		private readonly IDenonciationRepository _repository;

		public FindDenonciationsNonTraiteesQueryHandler(IDenonciationRepository repository) => _repository = repository;
		public Task<(IEnumerable<Denonciation> Results, int Total)> Handle(FindDenonciationsNonTraiteesQuery query, CancellationToken cancellationToken)
		{
			return _repository.Find(
				query.Pagination.Limit,
				query.Pagination.Offset,
				query.Specification);
		}
	}
}
