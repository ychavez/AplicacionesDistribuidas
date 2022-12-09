using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Infraestructure.Persistence;

namespace Ordering.Infraestructure.Repositories;

public class GenericRepository<T> where T : EntityBase
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

    }


}

