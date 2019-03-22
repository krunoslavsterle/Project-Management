using System;

namespace PM.Common
{
    /// <summary>
    /// Mapper.
    /// </summary>
    public class Mapper : IMapper
    {
        #region Fields

        private AutoMapper.MapperConfiguration mapperConfiguration;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Mapper" /> class.
        /// </summary>
        /// <param name="profiles">The profiles.</param>
        public Mapper(AutoMapper.Profile[] profiles)
        {
            mapperConfiguration = new AutoMapper.MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });
            MappingEngine = mapperConfiguration.CreateMapper();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the mapping engine.
        /// </summary>
        /// <value>The mapping engine.</value>
        private AutoMapper.IMapper MappingEngine { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Execute a mapping from the source object to a new destination object. The source type is inferred from the
        /// source object.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>Mapped destination object.</returns>
        public TDestination Map<TDestination>(object source)
        {
            return MappingEngine.Map<TDestination>(source);
        }

        /// <summary>
        /// Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <typeparam name="TSource">The type of the source to use, regardless of the runtime type.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>Mapped destination object.</returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return MappingEngine.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <param name="destination">Destination object to map into.</param>
        /// <returns>The mapped destination object, same instance as the destination object.</returns>
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return MappingEngine.Map<TSource, TDestination>(source, destination);
        }

        /// <summary>
        /// Execute a mapping from the source object to a new destination object with explicit System.Type objects.
        /// </summary>
        /// <param name="source">Source object to map from.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="destinationType">Type of the destination.</param>
        /// <returns>Mapped destination object.</returns>
        public object Map(object source, Type sourceType, Type destinationType)
        {
            return MappingEngine.Map(source, sourceType, destinationType);
        }

        /// <summary>
        /// Execute a mapping from the source object to existing destination object with explicit System.Type objects.
        /// </summary>
        /// <param name="source">Source object to map from.</param>
        /// <param name="destination">Destination object to map into.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="destinationType">Type of the destination.</param>
        /// <returns>Mapped destination object, same instance as the destination object.</returns>
        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return MappingEngine.Map(source, destination, sourceType, destinationType);
        }

        #endregion Methods
    }
}
