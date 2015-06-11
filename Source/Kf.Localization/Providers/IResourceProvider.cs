using System;

namespace Kf.Localization.Providers
{
    /// <summary>
    /// Defines a provider for a given type of resource.
    /// </summary>
    /// <typeparam name="TResource">Type of the resource.</typeparam>
    public interface IResourceProvider<TResource>
    {
        /// <summary>
        /// Gets a resource 
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="defaultValueProvider">Function the provides a default value when no value could be found.</param>
        /// <param name="throwOnException">Defines whether to throw when an exception occurs.</param>
        /// <returns>The resource, the default value or null.</returns>
        TResource Get(string name, Func<TResource> defaultValueProvider = null, bool throwOnException = false);
    }
}
