// Courtesy of https://medium.com/@codebob75/repository-pattern-c-ultimate-guide-entity-framework-core-clean-architecture-dtos-dependency-6a8d8b444dcb

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardGenerator.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardGenerator.Domain;

/// <summary>
///     A generic repository responsible for manipulating the database for the given entity type.
/// </summary>
/// <typeparam name="T"> A db entity, base class for all database objects. </typeparam>
public class Repository<T> : IRepository<T> where T : DbEntity
{
    private readonly DeckContext _databaseContext;
    private readonly DbSet<T> _dbSet;

    /// <summary>
    ///     Constructor for a generic repository.
    /// </summary>
    /// <param name="context"> The db context. </param>
    public Repository(DeckContext context)
    {
        _databaseContext = context;
        _databaseContext.Database.EnsureCreated();
        _dbSet = context.Set<T>();
    }

    /// <inheritdoc />
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    /// <inheritdoc />
    public async Task DeleteByIdAsync(int id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);

        if (entityToDelete != null)
        {
            _dbSet.Remove(entityToDelete);
            await SaveAsync();
        }
    }

    /// <inheritdoc />
    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    /// <inheritdoc />
    public async Task<List<T>> GetAllAsync(bool tracked = true)
    {
        IQueryable<T> query = _dbSet;

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await SaveAsync();
    }

    /// <inheritdoc />
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

    /// <inheritdoc />
    public async Task SaveAsync()
    {
        await _databaseContext.SaveChangesAsync();
    }
}
