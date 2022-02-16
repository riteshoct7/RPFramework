using AutoMapper;

namespace Services.Helpers
{
    public class ObjectMapper
    {
        #region Properties

        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<CustomMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        #endregion

        #region Fields

        public static IMapper Mapper => Lazy.Value;

        #endregion
    }
}
