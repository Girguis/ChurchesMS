using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Application.Contracts.Persistance;
using ChurchMS.Application.Extensions;
using ChurchMS.Domain.Common;
using ChurchMS.Domain.Common.Response;
using ChurchMS.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace ChurchMS.Persistence.Repositories;

public class GenericRepo<TEntity, IdType>(ChurchMSContext dbContext) : IGenericRepo<TEntity, IdType>
    where TEntity : BaseEntity<IdType>
    where IdType : struct
{
    public async Task<TEntity> Get(IdType id, List<string> includes = null)
    {
        var entites = dbContext
                        .Set<TEntity>()
                        .AsQueryable();

        if (includes != null && includes.Count > 0)
            foreach (var include in includes)
                entites = entites.Include(include);

        return await entites.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public IQueryable<TEntity> Get(List<IdType> ids, List<string> includes = default)
    {
        var entites = dbContext
                        .Set<TEntity>()
                        .AsQueryable();

        if (includes != null && includes.Count > 0)
            foreach (var include in includes)
                entites = entites.Include(include);

        return entites.Where(x => ids.Contains(x.Id));
    }

    public async Task<PagedResult<TEntity>> Get<TFilter, TSort>(QueryDto queryDto)
        where TFilter : IFilter
        where TSort : ISorter
    {
        var data = dbContext
                    .Set<TEntity>()
                    .AsQueryable();

        data = data.Filter<TEntity, TFilter>(queryDto.Filters);
        data = data.Sort<TEntity, TSort>(queryDto.Sort);
        int totalCount = data.Count();
        data = data.Paginate(queryDto.Pagination, totalCount);

        return new PagedResult<TEntity>(await data.ToListAsync(),
                                        queryDto.Pagination.PageNumber,
                                        queryDto.Pagination.PageSize,
                                        totalCount);
    }

    public IQueryable<TEntity> GetAll(List<string> includes = null)
    {
        var entites = dbContext
                        .Set<TEntity>()
                        .AsQueryable();

        if (includes != null && includes.Count > 0)
            foreach (var include in includes)
                entites = entites.Include(include);

        return entites;
    }

    public async Task<List<TDestination>> GetAllAsNoTracking<TDestination>()
    => await dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .ProjectTo<TDestination>()
                .ToListAsync();

    public async Task<TDestination> GetAsNoTracking<TDestination>(IdType id)
    => await dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(x => x.Id.Equals(id))
                .ProjectTo<TDestination>()
                .FirstOrDefaultAsync();

    public async Task<List<TDestination>> GetAsNoTracking<TDestination>(List<IdType> ids)
    => await dbContext
                .Set<TEntity>()
                .AsNoTracking()
                .Where(x => ids.Contains(x.Id))
                .ProjectTo<TDestination>()
                .ToListAsync();

    public async Task<PagedResult<TDestination>> GetAsNoTracking<TDestination, TFilter, TSort>(QueryDto queryDto)
        where TFilter : IFilter
        where TSort : ISorter
    {
        var data = dbContext
                    .Set<TEntity>()
                    .AsNoTracking()
                    .ProjectTo<TDestination>();

        data = data.Filter<TDestination, TFilter>(queryDto.Filters);
        data = data.Sort<TDestination, TSort>(queryDto.Sort);
        int totalCount = data.Count();
        data = data.Paginate(queryDto.Pagination, totalCount);

        return new PagedResult<TDestination>(data,
                                             queryDto.Pagination.PageNumber,
                                             queryDto.Pagination.PageSize,
                                             totalCount);
    }

    public async Task Create(TEntity entity)
    {
        await dbContext
                .Set<TEntity>()
                .AddAsync(entity);

        await dbContext.SaveChangesAsync();
    }

    public async Task Create(List<TEntity> entities)
    {
        await dbContext
                .Set<TEntity>()
                .AddRangeAsync(entities);

        await dbContext.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        dbContext.Update(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(List<TEntity> entities)
    {
        dbContext.UpdateRange(entities);
        dbContext.Entry(entities).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(TEntity entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(IdType id)
    {
        var entity = Get(id);
        if (entity != null)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task Delete(List<TEntity> entities)
    {
        dbContext.RemoveRange(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(List<IdType> ids)
    {
        var entites = GetAll()
                        .Where(x => ids.Contains(x.Id));

        dbContext.RemoveRange(entites);
        await dbContext.SaveChangesAsync();
    }
}