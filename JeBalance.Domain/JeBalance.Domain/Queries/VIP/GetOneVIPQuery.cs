using JeBalance.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.VIP
{
	public class GetOneVIPQuery : IRequest<Personne>
	{
		public int Id { get; }

		public GetOneVIPQuery(int id) => Id = id;
	}
}
