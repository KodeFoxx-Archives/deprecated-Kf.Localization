using System.Globalization;
using System.Resources;
using Kf.Localization.Providers;

namespace Kf.Localization.Resx
{
    /// <summary>
    /// <see cref="ResxProvider"/> that resolves string objects.
    /// </summary>
    public class ResxStringProvider : ResxProvider<string>, ICultureAwareStringProvider
    {
        /// <summary>
        /// Creates a new <see cref="ResxStringProvider"/>.
        /// </summary>
        /// <param name="resourceManager">The resource manager to use.</param>
        /// <param name="culture">The culture to use.</param>
        public ResxStringProvider(ResourceManager resourceManager, CultureInfo culture)
            : base(resourceManager, culture) {
        }

        /// <summary>
        /// Gets a resource by it's name.
        /// This method is called by "Get()", which wraps it in a common try/catch mechanism.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <returns>The resource.</returns>
        protected override string GetResource(string name) {
            return ResourceManager.GetString(name);
        }
    }
}
