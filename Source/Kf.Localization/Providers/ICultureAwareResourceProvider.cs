using System.Globalization;

namespace Kf.Localization.Providers
{
    /// <summary>
    /// Defines a provider that is aware of "Culture" for a given type of resource.
    /// </summary>
    /// <typeparam name="TResource">Type of the resource.</typeparam>
    public interface ICultureAwareResourceProvider<TResource> : IResourceProvider<TResource>
    {
        /// <summary>
        /// Gets/sets the current culture for this provider.
        /// </summary>
        CultureInfo Culture { get; set; }        
    }
}
