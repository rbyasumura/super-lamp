using AutoMapper;
using AFM = Advance.Framework.Mappers;

namespace Advance.Framework.ContactModule.Mappers.AutoMapper
{
    public class Mapper : AFM.IMapper
    {
        #region Private Fields

        private IMapper mapper;

        #endregion Private Fields

        #region Public Constructors

        public Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContactModuleProfile>();
            });
            mapper = config.CreateMapper();
        }

        #endregion Public Constructors

        #region Public Methods

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return mapper.Map(source, destination);
        }

        #endregion Public Methods
    }
}