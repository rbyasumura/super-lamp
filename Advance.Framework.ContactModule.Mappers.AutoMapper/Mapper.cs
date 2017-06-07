using AutoMapper;
using AFM = Advance.Framework.Mappers;

namespace Advance.Framework.ContactModule.Mappers.AutoMapper
{
    public class Mapper : AFM.IMapper
    {
        private IMapper mapper;

        public Mapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ContactModuleProfile>();
            });
            mapper = config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return mapper.Map(source, destination);
        }
    }
}