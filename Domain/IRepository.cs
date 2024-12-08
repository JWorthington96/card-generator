﻿// Courtesy of https://medium.com/@codebob75/repository-pattern-c-ultimate-guide-entity-framework-core-clean-architecture-dtos-dependency-6a8d8b444dcb

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinkingBuddy.Domain;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<List<T?>> GetAllAsync(bool tracked = true);
    Task UpdateAsync(T entity);
    Task DeleteByIdAsync(int id);
    Task SaveAsync();
}