using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Repositories
{
	public interface IVIPRepository : Repository<Personne>
	{
		public Task<(IEnumerable<Personne> Results, int Total)> Find(int limit, int offset, Specification<Personne> specification);
		public Task<bool> Create(int id);
	}
}
