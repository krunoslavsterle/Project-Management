using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace PM.Common.Cache
{
    /// <summary>
    /// Memory cache provider class.
    /// </summary>
    public class MemoryCacheProvider : ICacheProvider
    {
        #region Fields
        
        private const string cacheName = "MemoryCache";
        private MemoryCache cache;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryCacheProvider"/> class.
        /// </summary>
        public MemoryCacheProvider() 
        {
            this.DefaultCacheExpirationPeriod = TimeSpan.FromMinutes(20);
            this.cache = new MemoryCache(cacheName);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the default cache expiration period.
        /// </summary>
        /// <value>
        /// The default cache expiration period.
        /// </value>
        public TimeSpan DefaultCacheExpirationPeriod { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Inserts a cache entry into the cache without overwriting any existing cache entry.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert.</param>
        /// <param name="absoluteExpiration">The fixed date and time at which the cache entry will expire.</param>
        /// <param name="regionName">Optional. A named region in the cache to which the cache entry can be added, if regions are implemented.
        /// Because regions are not implemented in .NET Framework 4, the default value is null.</param>
        /// <returns>
        /// true if insertion succeeded, or false if there is an already an entry in the cache that has the same key as
        /// <paramref name="key" /> .
        /// </returns>
        public virtual bool Add(string key, object value, DateTimeOffset absoluteExpiration, string regionName = null)
        {
            return this.cache.Add(key, value, absoluteExpiration, regionName);
        }

        /// <summary>
        /// Inserts a cache entry into the cache without overwriting any existing cache entry, uses the <see cref="DefaultCacheExpirationPeriod"/> for absoluteExpiration.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert.</param>
        /// <param name="regionName">Optional. A named region in the cache to which the cache entry can be added, if regions are implemented.
        /// Because regions are not implemented in .NET Framework 4, the default value is null.</param>
        /// <returns>
        /// true if insertion succeeded, or false if there is an already an entry in the cache that has the same key as
        /// <paramref name="key" /> .
        /// </returns>
        public virtual bool Add(string key, object value, string regionName = null)
        {
            DateTimeOffset absoluteExpiration = new DateTimeOffset(DateTime.UtcNow, DefaultCacheExpirationPeriod);
            return this.cache.Add(key, value, absoluteExpiration, regionName);
        }

        /// <summary>
        /// Checks whether the cache entry already exists in the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="regionName">Optional. A named region in the cache where the cache can be found, if regions are implemented. The default
        /// value for the optional parameter is null.</param>
        /// <returns>
        /// true if the cache contains a cache entry with the same key value as <paramref name="key" /> ; otherwise, false.
        /// </returns>
        public virtual bool Contains(string key, string regionName = null)
        {
            return this.cache.Contains(key, regionName);
        }

        /// <summary>
        /// Gets the specified cache entry from the cache as an object.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry to get.</param>
        /// <param name="regionName">
        /// Optional. A named region in the cache to which the cache entry was added, if regions are implemented. The
        /// default value for the optional parameter is null.
        /// </param>
        /// <returns>The cache entry that is identified by <paramref name="key"/> .</returns>
        public virtual object Get(string key, string regionName = null)
        {
            return this.cache.Get(key, regionName);
        }

        /// <summary>
        /// Gets the specified cache entry from the cache as an <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">Cahce item type.</typeparam>
        /// <param name="key">A unique identifier for the cache entry to get.</param>
        /// <param name="regionName">
        /// Optional. A named region in the cache to which the cache entry was added, if regions are implemented. The
        /// default value for the optional parameter is null.
        /// </param>
        /// <returns>The cache entry that is identified by <paramref name="key"/> .</returns>
        public virtual T Get<T>(string key, string regionName = null)
        {
            var value = this.Get(key, regionName);
            if (value != null)
                return (T)value;

            return default(T);
        }

        /// <summary>
        /// Inserts a cache entry into the cache, by using a key, an object for the cache entry, an absolute expiration value, and an optional region to add the cache into.
        /// </summary>
        /// <returns>If a cache entry with the same key exists, the specified cache entry's value; otherwise, null.</returns>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <param name="absoluteExpiration">The fixed date and time at which the cache entry will expire.</param>
        /// <param name="regionName">
        /// Optional. A named region in the cache to which the cache entry can be added, if regions are implemented. The
        /// default value for the optional parameter is null.
        /// </param>
        public virtual T GetOrAdd<T>(string key, Func<string, T> valueFactory, DateTimeOffset absoluteExpiration, string regionName = null)
        {
            object result = this.Get<object>(key, regionName);
            if (result == null)
            {
                result = valueFactory.Invoke(key);
                if (result != null)
                {
                    this.Add(key, result, absoluteExpiration, regionName);
                }
            }
            return (T)result;
        }

        /// <summary>
        /// Inserts a cache entry into the cache async, by using a key, an object for the cache entry, an absolute expiration value, and an optional region to add the cache into.
        /// </summary>
        /// <returns>If a cache entry with the same key exists, the specified cache entry's value; otherwise, null.</returns>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <param name="absoluteExpiration">The fixed date and time at which the cache entry will expire.</param>
        /// <param name="regionName">
        /// Optional. A named region in the cache to which the cache entry can be added, if regions are implemented. The
        /// default value for the optional parameter is null.
        /// </param>
        public virtual Task<T> GetOrAddAsync<T>(string key, Func<string, T> valueFactory, DateTimeOffset absoluteExpiration, string regionName = null)
        {
            object result = this.Get<object>(key, regionName);
            if (result == null)
            {
                result = valueFactory.Invoke(key);
                if (result != null)
                {
                    this.Add(key, result, absoluteExpiration, regionName);
                }
            }
            return Task.FromResult((T)result);
        }

        /// <summary>
        /// Gets a set of cache entries that correspond to the specified keys.
        /// </summary>
        /// <returns>A dictionary of key/value pairs that represent cache entries.</returns>
        /// <param name="regionName">
        /// Optional. A named region in the cache to which the cache entry or entries were added, if regions are
        /// implemented. Because regions are not implemented in .NET Framework 4, the default is null.
        /// </param>
        /// <param name="keys">A collection of unique identifiers for the cache entries to get.</param>
        public virtual IDictionary<string, object> GetValues(IEnumerable<string> keys, string regionName = null)
        {
            return this.cache.GetValues(keys, regionName);
        }

        /// <summary>
        /// Removes the cache entry from the cache.
        /// </summary>
        /// <returns>
        /// An object that represents the value of the removed cache entry that was specified by the key, or null if the
        /// specified entry was not found.
        /// </returns>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="regionName">
        /// Optional. A named region in the cache to which the cache entry was added, if regions are implemented. The
        /// default value for the optional parameter is null.
        /// </param>
        public virtual object Remove(string key, string regionName = null)
        {
            return this.cache.Remove(key, regionName);
        }

        /// <summary>
        /// Removes the cache region entries from the cache.
        /// </summary>
        /// <param name="regionName">
        /// A named region in the cache to which the cache entry was added, if regions are implemented.
        /// </param>
        public virtual bool RemoveRegion(string regionName)
        {
            var values = this.cache.GetValues(regionName);
            foreach(var item in values)
            {
                this.cache.Remove(item.Key, regionName);
            }
            return true;
        }

        #endregion Methods
    }
} 