namespace Advance.Framework.Mappers
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
