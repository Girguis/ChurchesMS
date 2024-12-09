using AutoMapper;
using ChurchMS.Application.Contracts.Mapper;

namespace ChurchMS.Infrastructure.Mappers;

public class GMapper(IMapper mapper) : IGMapper
{
    private readonly IMapper _mapper = mapper;

    public void Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        _mapper.Map(source, destination);
    }

    public TDestination Map<TDestination>(object source)
    {
        return _mapper.Map<TDestination>(source);
    }
}