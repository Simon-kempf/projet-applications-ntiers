using JeBalance.Domain.Contracts;
using JeBalance.Domain.Model;
using JeBalance.Domain.Repositories;
using JeBalance.Infrastructure.SQLServer;
using JeBalance.Infrastructure.SQLServer.Model;
using Microsoft.EntityFrameworkCore;

namespace JeBalance.Infrastructure.SQLServer.Repositories;
public class DenonciationRepositorySQLS : IDenonciationRepository
{
    private readonly DatabaseContext _context;
    public DenonciationRepositorySQLS(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }
    public Task<int> Count(Specification<Denonciation> specification)
    {
        return Task.FromResult(_context.Denonciations
        .Where(specification.IsSatisfiedBy)
        .Count());
    }
    public async Task<int> Create(Denonciation denonciation)
    {
        var denonciationToSave = denonciation.ToSQLS();
        await _context.Denonciations.AddAsync(denonciationToSave);
        await _context.SaveChangesAsync();
        return denonciationToSave.Id;
    }
    public async Task<bool> Delete(int id)
    {
        try
        {
            var denonciation = await _context.Denonciations.FirstOrDefaultAsync(denonciation =>
            denonciation.Id == id);
            if (denonciation == null)
                return true;
            _context.Remove(denonciation);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset, Specification<Denonciation> specification)
    {
        var dbSet = _context.Denonciations
        .Where(specification.IsSatisfiedBy)
        .Skip(offset)
        .Take(limit)
        .Select(denonciation => denonciation);
        IEnumerable<Denonciation> results = dbSet.ToList();
        return Task.FromResult((results, results.Count()));
    }

	public Task<int> Update(int id, Denonciation T)
	{
		throw new NotImplementedException();
	}

	public async Task<Denonciation> GetOne(int id)
	{
		var denonciation = await _context.Denonciations.FirstAsync(denonciation => denonciation.Id == id);
		return denonciation.ToDomain();
	}
}