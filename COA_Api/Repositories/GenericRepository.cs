using System.Linq.Expressions;
using COA_Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace COA_Api.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected DbContext context;
    public GenericRepository(DbContext context)
    {
        this.context = context;   
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        context.Set<TEntity>().Remove(entity);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return context.Set<TEntity>().Where(predicate);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetById(int id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> Insert(TEntity entity)
    {     
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> SoftDelete(TEntity entity, int? id)
    {
 
        var value = await GetById(id!.Value);

        // var Ent = entity.IsDeleted = true;
        // return entity.IsDeleted = true;
        return true;

    }

    public async Task<TEntity> Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}
