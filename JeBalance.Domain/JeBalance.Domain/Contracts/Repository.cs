namespace JeBalance.Domain.Contracts;

public interface Repository<T> where T : Entity
{
    public Task<T> GetOne(int id);
    public Task<bool> Delete(int id);
}