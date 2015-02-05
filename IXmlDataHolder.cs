namespace XmlToPocoParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// XML data holder interface
    /// </summary>
    public interface IXmlDataHolder
    {
        /// <summary>
        /// Gets elements by element name.
        /// </summary>
        /// <param name="elementName">The element name</param>
        /// <returns>Returns IEnumerable XElement</returns>
        IEnumerable<XElement> GetElementsByElementName(string elementName);

        /// <summary>
        /// Gets an XElement by element name
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="elementName">The element name</param>
        /// <returns>Returns XElement</returns>
        XElement GetElementByElementName(XElement source, string elementName);

        /// <summary>
        /// Gets and load XML data from URL
        /// </summary>
        /// <param name="serviceUrl">URL source</param>
        /// <returns>Returns bool.</returns>
        bool LoadFromWebService(Uri serviceUrl);
    }
}
