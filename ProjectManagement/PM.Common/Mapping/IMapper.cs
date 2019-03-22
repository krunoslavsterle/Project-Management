using System;

namespace PM.Common
{
    /// <summary>
    /// Mapper contract.
    /// </summary>
    public interface IMapper
    {
        #region Methods

        /// <summary>
        /// Execute a mapping from the source object to a new destination object. The source type is inferred from the
        /// source object.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>Mapped destination object.</returns>
        TDestination Map<TDestination>(object source);

        /// <summary>
        /// Execute a mapping from the source object to a new destination object.
        /// </summary>
        /// <typeparam name="TSource">The type of the source to use, regardless of the runtime type.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <returns>Mapped destination object.</returns>
        TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Execute a mapping from the source object to the existing destination object.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">Source object to map from.</param>
        /// <param name="destination">Destination object to map into.</param>
        /// <returns>The mapped destination object, same instance as the destination object.</returns>
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        /// <summary>
        /// Execute a mapping from the source object to a new destination object with explicit System.Type objects.
        /// </summary>
        /// <param name="source">Source object to map from.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="destinationType">Type of the destination.</param>
        /// <returns>Mapped destination object.</returns>
        object Map(object source, Type sourceType, Type destinationType);

        /// <summary>
        /// Execute a mapping from the source object to existing destination object with explicit System.Type objects.
        /// </summary>
        /// <param name="source">Source object to map from.</param>
        /// <param name="destination">Destination object to map into.</param>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="destinationType">Type of the destination.</param>
        /// <returns>Mapped destination object, same instance as the destination object.</returns>
        object Map(object source, object destination, Type sourceType, Type destinationType);

        #endregion Methods
    }
}
