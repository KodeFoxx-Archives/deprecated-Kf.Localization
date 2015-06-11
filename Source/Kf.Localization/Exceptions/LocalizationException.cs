using System;

namespace Kf.Localization.Exceptions
{
    /// <summary>
    /// Defines a Localization exception.
    /// </summary>    
    public class LocalizationException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="LocalizationException"/>.
        /// </summary>
        /// <param name="message">The message describing the error.</param>
        /// <param name="innerException">The exception that triggered this exception.</param>
        public LocalizationException(string message, Exception innerException = null)
            : base(message, innerException) { }
    }
}
