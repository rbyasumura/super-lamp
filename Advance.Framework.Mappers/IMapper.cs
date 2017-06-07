namespace Advance.Framework.Mappers
{
    public interface IMapper
    {
        #region Public Methods

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        #endregion Public Methods
    }
}