namespace ChurchMS.Application.Contracts.Mapper;

public interface IGMapper
{
    void Map<TSource, TDestination>(TSource source, TDestination destination);
    TDestination Map<TDestination>(object source);
}