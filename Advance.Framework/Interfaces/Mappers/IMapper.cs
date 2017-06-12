namespace Advance.Framework.Interfaces.Mappers
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
