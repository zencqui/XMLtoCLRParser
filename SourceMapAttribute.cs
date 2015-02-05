namespace XmlToPocoParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The <see cref="SourceMapAttribute"/> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property |
        AttributeTargets.Class)]
    public sealed class SourceMapAttribute : Attribute
    {
        #region Fields

        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="SourceMapAttribute"/> class.
        /// </summary>
        /// <param name="name">The name</param>
        public SourceMapAttribute(string name)
        {
            this.name = name;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        #endregion
    }
}
