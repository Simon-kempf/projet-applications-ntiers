using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLServer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Repositories
{
	public class VIPRepositorySQLS : IVIPRepository
	{
		private readonly DatabaseContext _context;
		public VIPRepositorySQLS(DatabaseContext databaseContext)
		{
			_context = databaseContext;
		}
		public Task<int> Count(Specification<Personne> specification)
		{
			return Task.FromResult(_context.Personnes
			.Where(specification.IsSatisfiedBy)
			.Count());
		}
		public async Task<bool> Create(int id)
		{
			try
			{
				PersonneSQLS vip = _context.Personnes.First(vip =>
					vip.Id == id);
				if (vip == null)
					return false;
				vip.estVIP = 1;
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> Delete(int id)
		{
			try
			{
				var vip = _context.Personnes.First(vip =>
					vip.Id == id);
				if (vip == null)
					return true;
				vip.estVIP = 0;
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		public Task<(IEnumerable<Personne> Results, int Total)> Find(
			int limit,
			int offset,
			Specification<Personne> specification)
		{
			var results = _context.Personnes
			.Apply(specification.ToSQLSExpression<Personne, PersonneSQLS>())
			.Skip(offset)
			.Take(limit)
			.AsEnumerable()
			.Select(vip => vip.ToDomain());
			return Task.FromResult((results, _context.Personnes.Count()));
		}

		public async Task<Personne> GetOne(int id)
		{
			var vip = await _context.Personnes.FirstAsync(vip => (vip.Id == id && vip.estVIP == 1));
			return vip.ToDomain();
		}
		public Task<bool> HasAny(Specification<Personne> specification)
		{
			return _context.Personnes.AnyAsync(vip =>
		   specification.IsSatisfiedBy(vip));
		}

	}
}
