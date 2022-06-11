using System.Linq.Expressions;
using COA_Api.Core.Services.Interfaces;
using COA_Api.Repositories.Interfaces;

namespace COA_Api.Core.Services;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
{
    private IGenericRepository<TEntity> _genericRepository;
    public GenericService(IGenericRepository<TEntity> genericRepository)
    {
        this._genericRepository = genericRepository;
    }
    public async Task Delete(int id)
    {
        await _genericRepository.Delete(id);        
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _genericRepository.Find(predicate);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _genericRepository.GetById(id);
    }

    public async Task<TEntity> Insert(TEntity entity)
    {
        return await _genericRepository.Insert(entity);
    }

    public Task<bool> SoftDelete(TEntity entity, int? id)
    {
        return _genericRepository.SoftDelete(entity,id);
    }

    public Task<TEntity> Update(TEntity entity)
    {
        return _genericRepository.Update(entity);
    }
}
