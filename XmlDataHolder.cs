namespace XmlToPocoParser
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Xml.Linq;

    /// <summary>
    /// XML Data holder class
    /// </summary>
    public class XmlDataHolder : IXmlDataHolder
    {
        /// <summary>
        /// xml document
        /// </summary>
        private XDocument xml = new XDocument();

        /// <summary>
        /// Gets elements by element name
        /// </summary>
        /// <param name="elementName">The element name.</param>
        /// <returns>Returns IEnumerable XElement.</returns>
        public IEnumerable<XElement> GetElementsByElementName(string elementName)
        {
            var qualifiedName = this.GetQualifiedElementName(elementName);
            var elements = from xRate in this.xml.Descendants(qualifiedName)
                           select xRate;

            return elements;
        }

        /// <summary>
        /// Gets XElement by element name.
        /// </summary>
        /// <param name="source">The source element.</param>
        /// <param name="elementName">The element name</param>
        /// <returns>Returns XML element</returns>
        public XElement GetElementByElementName(XElement source, string elementName)
        {
            var qualifiedName = this.GetQualifiedElementName(elementName);
            return source.Element(qualifiedName);
        }

        /// <summary>
        /// Load xml data using URL
        /// </summary>
        /// <param name="serviceUrl">URL source</param>
        /// <returns>Returns bool.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:Donotcatchgeneralexceptiontypes",
            Justification = "Just needed to determine if the Load method succeeded.")]
        public bool LoadFromWebService(Uri serviceUrl)
        {
            try
            {
                var path = System.Configuration.ConfigurationManager.AppSettings["CertificatePath"];
                X509Certificate cert = X509Certificate.CreateFromCertFile(path);

                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(serviceUrl);
                rq.Timeout = 60000;
                rq.ClientCertificates.Add(cert);
                rq.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse response = rq.GetResponse() as HttpWebResponse;

                using (Stream responseStream = response.GetResponseStream())
                {
                    this.xml = XDocument.Load(responseStream);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the qualified element name.
        /// </summary>
        /// <param name="elementName">The element name.</param>
        /// <returns>Returns XName.</returns>
        private XName GetQualifiedElementName(string elementName)
        {
            return XName.Get(elementName, this.xml.Root.Name.Namespace.ToString());
        }
    }
}
