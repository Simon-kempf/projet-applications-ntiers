using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Repositories
{
	internal class PersonneRepositorySQLS : IPersonneRepository
	{
		public Task<bool> Create(Personne personne)
		{
			throw new NotImplementedException();
		}

		public Task<int> CreateAll(IEnumerable<Personne> newCurrentPersons)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<(IEnumerable<Personne> Results, int Total)> Find(int limit, int offset, params Specification<Personne>[] specifications)
		{
			throw new NotImplementedException();
		}

		public Task<(IEnumerable<Personne> Results, int Total)> Find(int limit, int offset, Specification<Personne> specification)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Personne>> FindAll(params Specification<Personne>[] specifications)
		{
			throw new NotImplementedException();
		}

		public Task<Personne> GetOne(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> HasAny(params Specification<Personne>[] specifications)
		{
			throw new NotImplementedException();
		}

		public Task<int> RemoveAll(params Specification<Personne>[] specifications)
		{
			throw new NotImplementedException();
		}

		public Task<int> Update(int id, Personne T)
		{
			throw new NotImplementedException();
		}

		Task<int> Repository<Personne>.Create(Personne T)
		{
			throw new NotImplementedException();
		}
	}
}
