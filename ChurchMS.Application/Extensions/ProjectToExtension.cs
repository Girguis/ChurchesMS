using AutoMapper;

namespace ChurchMS.Application.Extensions;

public static class ProjectToExtension
{
    private static IMapper _mapper;

    public static void SetMapper(IMapper mapper)
    {
        _mapper ??= mapper;
    }

    public static IQueryable<TDestination> ProjectTo<TDestination>(this IQueryable source)
    {
        return _mapper.ProjectTo<TDestination>(source);
    }
}