using JeBalance.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JeBalance.Domain.Queries.VIP
{
	public class FindVIPsQueryHandler : IRequestHandler<FindVIPsQuery, (IEnumerable<Model.Utilisateurs.VIP> Results, int Total)>
	{
		private readonly IVIPRepository _repository;

		public FindVIPsQueryHandler(IVIPRepository repository) => _repository = repository;
		public Task<(IEnumerable<Model.Utilisateurs.VIP> Results, int Total)> Handle(FindVIPsQuery query, CancellationToken cancellationToken)
		{
			return _repository.Find(
				query.Pagination.Limit,
				query.Pagination.Offset,
				query.Specification);
		}
	}
}
