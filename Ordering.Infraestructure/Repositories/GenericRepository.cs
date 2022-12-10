using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts;
using Ordering.Domain.Common;
using Ordering.Infraestructure.Persistence;
using System.Linq.Expressions;

namespace Ordering.Infraestructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
{
    private readonly OrderContext _orderContext;


    public GenericRepository(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    /// <summary>
    /// Nos trae toda la tabla completa
    /// </summary>
    /// <returns></returns>
    public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _orderContext.Set<T>().ToListAsync();

    /// <summary>
    /// Nos trae toda la tabla haciendo un filtrado en el parametro Predicate
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
     => await _orderContext.Set<T>().Where(predicate).ToListAsync();


    public async Task<IReadOnlyList<T>> GetAllAsync(int offset, int limit, Expression<Func<T, bool>>? predicate,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, params string[] includeStrings)
    {
        IQueryable<T> query = _orderContext.Set<T>();

        query = query.Skip(offset).Take(limit);

        query = includeStrings.Aggregate(query, (current, itemInclude) => current.Include(itemInclude));

        if (predicate is not null)
            query = query.Where(predicate);

        if (orderBy is not null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _orderContext.Set<T>().AddAsync(entity);
        await _orderContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _orderContext.Entry(entity).State = EntityState.Modified;
        await _orderContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _orderContext.Set<T>().Remove(entity);
        await _orderContext.SaveChangesAsync();
    }

    public async Task<T> GetById(int id)
         => await _orderContext.Set<T>().SingleAsync(x => x.Id == id);
}

