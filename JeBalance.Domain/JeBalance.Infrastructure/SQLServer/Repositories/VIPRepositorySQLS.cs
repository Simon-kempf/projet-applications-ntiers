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
			return Task.FromResult(_context.VIPs
			.Where(specification.IsSatisfiedBy)
			.Count());
		}
		public async Task<int> Create(Personne vip)
		{
			PersonneSQLS vipToSave = vip.ToSQLS();
			await _context.VIPs.AddAsync(vipToSave);
			await _context.SaveChangesAsync();
			return vipToSave.Id;
		}

		public async Task<bool> Delete(int id)
		{
			try
			{
				var vip = await _context.VIPs.FirstOrDefaultAsync(vip =>
					vip.Id == id);
				if (vip == null)
					return true;
				_context.Remove(vip);
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
			var results = _context.VIPs
			.Where(specification.IsSatisfiedBy)
			.Skip(offset)
			.Take(limit)
			.AsEnumerable()
			.Select(vip => vip.ToDomain());
			return Task.FromResult((results, _context.VIPs.Count()));
		}

		public async Task<Personne> GetOne(int id)
		{
			var vip = await _context.VIPs.FirstAsync(vip => vip.Id == id);
			return vip.ToDomain();
		}
		public Task<bool> HasAny(Specification<Personne> specification)
		{
			return _context.VIPs.AnyAsync(vip =>
		   specification.IsSatisfiedBy(vip));
		}
		
		public async Task<int> Update(int id, Personne vip)
		{
			var vipToUpdate = _context.VIPs.First(vip => vip.Id == id);
			vipToUpdate.Nom = vip.Nom!.Value;
			vipToUpdate.Prenom = vip.Prenom!.Value;
			await _context.SaveChangesAsync();
			return id;
		}

	}
}
