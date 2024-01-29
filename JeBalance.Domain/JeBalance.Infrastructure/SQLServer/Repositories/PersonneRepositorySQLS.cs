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
	public class PersonneRepositorySQLS : IPersonneRepository
	{

		private readonly DatabaseContext _context;
		public PersonneRepositorySQLS(DatabaseContext databaseContext)
		{
			_context = databaseContext;
		}

		public async Task<int> Create(Personne personne)
		{
			var personneToSave = personne.ToSQLS();
			await _context.Personnes.AddAsync(personneToSave);
			await _context.SaveChangesAsync();
			return personneToSave.Id;
		}

		public Task<int> Count(Specification<Personne> specification)
		{
			return Task.FromResult(_context.Personnes
			.Where(specification.IsSatisfiedBy)
			.Count());
		}


		public Task<int> CreateAll(IEnumerable<Personne> newCurrentPersons)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> Delete(int id)
		{
			try
			{
				var personne = await _context.Personnes.FirstOrDefaultAsync(personne =>
			   personne.Id == id);
				if (personne == null)
					return true;
				_context.Remove(personne);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public Task<(IEnumerable<Personne> Results, int Total)> Find(int limit, int offset, Specification<Personne> specification)
		{
			var results = _context.Personnes
			.Where(specification.IsSatisfiedBy)
			.Skip(offset)
			.Take(limit)
			.Select(personne => personne.ToDomain());
			return Task.FromResult((results, _context.Personnes.Count()));
		}

		public Task<IEnumerable<Personne>> FindAll(params Specification<Personne>[] specifications)
		{
			throw new NotImplementedException();
		}

		public async Task<Personne> GetOne(int id)
		{
			var personne = await _context.Personnes.FirstAsync(personne => personne.Id == id);
			return personne.ToDomain();
		}

		public Task<bool> HasAny(Specification<Personne> specifications)
		{
			return _context.Personnes.AnyAsync(personne => specifications.IsSatisfiedBy(personne));
		}

		public async Task<int> Update(int id, Personne personne)
		{
			var personneToUpdate = _context.Personnes.First(place => place.Id == id);
			personneToUpdate.Nom = personne.Nom!.Value;
			personneToUpdate.Prenom = personne.Prenom!.Value;
			personneToUpdate.Statut = (int)personne.Statut;
			personneToUpdate.Adresse = personne.Adresse.toSQLS();
			personneToUpdate.estVIP = personne.estVIP ? 1 : 0;
			personneToUpdate.estCalomniateur = personne.estCalomniateur ? 1 : 0;
			personneToUpdate.Role = (int)personne.Role;
			await _context.SaveChangesAsync();
			return id;
		}
	}
}
