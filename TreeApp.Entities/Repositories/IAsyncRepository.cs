﻿using Ardalis.Specification;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TreeApp.Entities.Models;

namespace TreeApp.Entities.Repositories
{
    public interface IAsyncRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        Task<int> CountAsync(CancellationToken cancellationToken = default);

        Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    }
}
