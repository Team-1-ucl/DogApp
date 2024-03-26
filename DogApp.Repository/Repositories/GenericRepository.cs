
using DogApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DogApp.Repository;

public class GenericRepository<T>(DataContext context) : IGenericRepository<T> where T : class
{
	protected readonly DataContext _context = context;

    public async Task AddAsync(T entity)
	{
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.FindAsync<T>(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}