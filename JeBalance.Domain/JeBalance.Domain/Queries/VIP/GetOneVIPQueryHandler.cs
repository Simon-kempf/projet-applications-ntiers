using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.VIP
{
	internal class GetOneVIPQueryHandler : IRequestHandler<GetOneVIPQuery, Personne>
	{
		private readonly IVIPRepository _repository;

		public GetOneVIPQueryHandler(IVIPRepository repository) => _repository = repository;
		public Task<Personne> Handle(GetOneVIPQuery query, CancellationToken cancellationToken)
		{
			return _repository.GetOne(query.Id);
		}
	}
}
