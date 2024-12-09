// Courtesy of https://medium.com/@codebob75/repository-pattern-c-ultimate-guide-entity-framework-core-clean-architecture-dtos-dependency-6a8d8b444dcb

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGenerator.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardGenerator.Domain;

public class Repository<T> : IRepository<T> where T : DbEntry
{
    private readonly DeckContext _databaseContext;
    private readonly DbSet<T> _dbSet;

    public Repository(DeckContext context)
    {
        _databaseContext = context;
        _databaseContext.Database.EnsureCreated();
        _dbSet = context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
            await SaveAsync();
        }
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync(bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await SaveAsync();
    }

    public async Task AddOrUpdateAsync(T entity)
    {
        if (entity.Id == 0)
        {
            await _dbSet.AddAsync(entity);
        }
        else if (await _dbSet.FindAsync(entity.Id) is not null)
        {
            _dbSet.Update(entity);
        }
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _databaseContext.SaveChangesAsync();
    }
}
