using ChurchMS.Application.Common.Dtos.Request.Filters;
using ChurchMS.Application.Contracts.DataFiltering;
using ChurchMS.Domain.Common;
using ChurchMS.Domain.Common.Response;

namespace ChurchMS.Application.Contracts.Persistance;

public interface IGenericRepo<TEntity, IdType>
    where TEntity : BaseEntity<IdType>
    where IdType : struct
{
    Task<TEntity> Get(IdType id, List<string> includes = default);
    IQueryable<TEntity> Get(List<IdType> ids, List<string> includes = default);
    Task<PagedResult<TEntity>> Get<TFilter, TSort>(QueryDto queryDto)
        where TFilter : IFilter
        where TSort : ISorter;
    IQueryable<TEntity> GetAll(List<string> includes = default);
    Task<List<TDestination>> GetAllAsNoTracking<TDestination>();
    Task<List<TDestination>> GetAsNoTracking<TDestination>(List<IdType> ids);
    Task<PagedResult<TDestination>> GetAsNoTracking<TDestination, TFilter, TSort>(QueryDto queryDto)
        where TFilter : IFilter
        where TSort : ISorter;
    Task<TDestination> GetAsNoTracking<TDestination>(IdType id);
    Task Create(TEntity entity);
    Task Update(TEntity entity);
    Task Create(List<TEntity> entities);
    Task Update(List<TEntity> entities);
    Task Delete(TEntity entity);
    Task Delete(IdType id);
    Task Delete(List<TEntity> entities);
    Task Delete(List<IdType> ids);
}