namespace XmlToPocoParser
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="IObjectMapper"/> interface.
    /// </summary>
    public interface IObjectMapper
    {
        /// <summary>
        /// Gets or sets xml data source.
        /// </summary>
        IXmlDataHolder DataSourceProvider { get; set; }

        /// <summary>
        /// Gets mapped collection of object.
        /// </summary>
        /// <typeparam name="T">The T.</typeparam>
        /// <returns>Returns IEnumerable T.</returns>
        IEnumerable<T> GetMappedObjectCollection<T>();
    }
}
