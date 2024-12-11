// Courtesy of https://medium.com/@codebob75/repository-pattern-c-ultimate-guide-entity-framework-core-clean-architecture-dtos-dependency-6a8d8b444dcb

using System.Collections.Generic;
using System.Threading.Tasks;
using CardGenerator.Entities;

namespace CardGenerator.Domain;

/// <summary>
/// A generic repository responsible for interacting with the database.
/// </summary>
/// <typeparam name="T"> Generic DbEntity. </typeparam>
public interface IRepository<T> where T : DbEntity
{
    /// <summary>
    /// Adds an entity to the database.
    /// </summary>
    /// <param name="entity"> The entity to add. </param>
    Task AddAsync(T entity);

    /// <summary>
    /// Gets an entity from the database.
    /// </summary>
    /// <param name="id"> The id of the entity to get. </param>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Gets all entities from the database.
    /// </summary>
    /// <param name="tracked"> (Optional) True if wanting to track changes to the entities, false if not. </param>
    Task<List<T>> GetAllAsync(bool tracked = true);

    /// <summary>
    /// Updates an entity in the database.
    /// </summary>
    /// <param name="entity"> The entity to update with the changes. </param>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Deletes an entity from the database.
    /// </summary>
    /// <param name="id"> The id of the entity to delete. </param>
    Task DeleteByIdAsync(int id);

    /// <summary>
    /// Adds or updates the given entity, depending on whether or not it exists in the database.
    /// </summary>
    /// <param name="entity"> The entity to add or update. </param>
    Task AddOrUpdateAsync(T entity);

    /// <summary>
    /// Saves (or commits) the current changes to the db context to the database.
    /// </summary>
    Task SaveAsync();
}