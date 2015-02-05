namespace XmlToPocoParser
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// The ObjectMapper.
    /// </summary>
    public class ObjectMapper : IObjectMapper
    {
        #region Fields
        /// <summary>
        /// The xml data source.
        /// </summary>
        private IXmlDataHolder xmlDataSource;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="ObjectMapper"/> class.
        /// </summary>
        public ObjectMapper()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets xml data source.
        /// </summary>
        public IXmlDataHolder DataSourceProvider
        {
            get { return this.xmlDataSource; }
            set { this.xmlDataSource = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets mapped collection of object.
        /// </summary>
        /// <typeparam name="T">The T.</typeparam>
        /// <returns>Returns IEnumerable T.</returns>
        public IEnumerable<T> GetMappedObjectCollection<T>()
        {
            string warningMessage = "CURRENCY CALCULATOR GetMappedObjectCollection<T>():";
            List<T> mappedCollection = new List<T>();

            if (this.xmlDataSource == null)
            {
                return mappedCollection;
            }

            var elementName = string.Empty;
            var attrName = (SourceMapAttribute)typeof(T).GetCustomAttributes(typeof(SourceMapAttribute), false).First();

            if (attrName != null)
            {
                elementName = attrName.Name;
            }

            var rates = this.xmlDataSource.GetElementsByElementName(elementName);

            mappedCollection.AddRange(rates.Select(this.Map<T>));

            return mappedCollection;
        }

        /// <summary>
        /// Map a XML element to T object
        /// </summary>
        /// <typeparam name="T">The type T</typeparam>
        /// <param name="element">The XML element</param>
        /// <returns>Returns type T.</returns>
        private T Map<T>(XElement element)
        {
            var objInstance = Activator.CreateInstance<T>();
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                var sourceId = (SourceMapAttribute)prop.GetCustomAttributes(typeof(SourceMapAttribute), false).FirstOrDefault();

                if (sourceId == null)
                {
                    continue;
                }

                prop.SetValue(objInstance, this.xmlDataSource.GetElementByElementName(element, sourceId.Name).Value, null);
            }

            return objInstance;
        }

        #endregion
    }
}
