using System.Linq.Expressions;

namespace COA_Api.Core.Services.Interfaces;

public interface IGenericService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> GetById(int id);
    Task<TEntity> Insert(TEntity entity);
    Task<TEntity> Update(TEntity entity);               
    
    // Hard Delete
    Task Delete(int id);

    // Soft Delete
    Task<bool> SoftDelete(TEntity entity, int? id);
}
