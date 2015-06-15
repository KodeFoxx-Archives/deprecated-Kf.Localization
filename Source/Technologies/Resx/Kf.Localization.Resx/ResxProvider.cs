using System;
using System.Globalization;
using System.Resources;
using Kf.Localization.Exceptions;
using Kf.Localization.Providers;

namespace Kf.Localization.Resx
{
    /// <summary>
    /// Resx implementation for <see cref="IProvider"/>.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    public abstract class ResxProvider<TResource> : ICultureAwareResourceProvider<TResource>
    {
        /// <summary>
        /// Holds a reference to the resource manager.
        /// </summary>    
        protected ResourceManager ResourceManager { get { return _resourceManager; } }
        private readonly ResourceManager _resourceManager;

        /// <summary>
        /// Gets/sets the current culture.
        /// </summary>
        public CultureInfo Culture {
            get { return _culture; }
            set {
                if (value != null) {                    
                    _culture = value;
                }
            }
        }
        private CultureInfo _culture;

        /// <summary>
        /// Creates a new <see cref="ResxProvider"/>.
        /// </summary>
        /// <param name="resourceManager">The resource manager to use.</param>
        /// <param name="culture">The culture to use.</param>
        public ResxProvider(ResourceManager resourceManager, CultureInfo culture = null) {
            if (_resourceManager == null) {
                throw new ArgumentNullException(nameof(resourceManager));
            }

            _resourceManager = resourceManager;
            Culture = culture == null
                ? CultureInfo.CurrentUICulture
                : culture;
        }

        /// <summary>
        /// Gets a resource by it's name.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="defaultValueProvider">Function the provides a default value when no value could be found.</param>
        /// <param name="throwOnException">Defines whether to throw when an exception occurs.</param>
        /// <returns>The resource.</returns>
        public TResource Get(string name, Func<TResource> defaultValueProvider = null, bool throwOnException = false) {
            try {
                return GetResource(name);
            } catch (Exception ex) {
                var getResourceExceptionMessage = $"Exception '{ex.ToFriendlyNameOfType()}' occurred while trying to get resource with name '{name}'.";                    
                var getResourceException = new LocalizationException(getResourceExceptionMessage, ex);                

                if (defaultValueProvider == null && throwOnException) {
                    throw getResourceException;
                }
                if (defaultValueProvider == null) {
                    return default(TResource);
                } else {
                    try {
                        return defaultValueProvider();
                    } catch (Exception defaultValueEx) {
                        var getDefaultValueExceptionMessage = $"Exception '{defaultValueEx.ToFriendlyNameOfType()}' occurred while trying to get default value for resource with name '{name}.";                            
                        var getDefaultValueException = new LocalizationException(getDefaultValueExceptionMessage, defaultValueEx);                        

                        if (throwOnException) {
                            throw getDefaultValueException;
                        }

                        return default(TResource);
                    }
                }

            }
        }

        /// <summary>
        /// Gets a resource by it's name.
        /// This method is called by "Get()", which wraps it in a common try/catch mechanism.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <returns>The resource.</returns>
        protected abstract TResource GetResource(string name);
    }
}
