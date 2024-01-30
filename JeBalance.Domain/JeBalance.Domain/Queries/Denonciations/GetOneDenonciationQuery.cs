using JeBalance.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Queries.Denonciations
{
	public class GetOneDenonciationQuery : IRequest<Denonciation>
	{
		public int Id { get; }

		public GetOneDenonciationQuery(int id) => Id = id;
	}
}
