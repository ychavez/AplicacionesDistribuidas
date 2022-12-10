using Ordering.Domain.Common;
using System.Linq.Expressions;

namespace Ordering.Application.Contracts
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAllAsync(int offset, int limit, Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, params string[] includeStrings);
        Task<T> GetById(int id);
        Task UpdateAsync(T entity);
    }
}