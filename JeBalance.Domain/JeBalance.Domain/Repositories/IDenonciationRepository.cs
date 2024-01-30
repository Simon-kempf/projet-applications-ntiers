using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Repositories
{
	public interface IDenonciationRepository : Repository<Denonciation>
	{
		public Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset, Specification<Denonciation> specification);
		Task<int> Update(int id, Reponse reponse);

	}
}
