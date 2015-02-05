namespace XmlToPocoParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// The <see cref="CurrencyRate"/> class.
    /// </summary>
    [SourceMapAttribute("rate")]
    public class FXCurrencyRate
    {
        #region Properties

        /// <summary>
        /// Gets or sets ClientId.
        /// </summary>
        [SourceMapAttribute("clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets PayCurrency.
        /// </summary>
        [SourceMapAttribute("payCurrency")]
        public string PayCurrency { get; set; }

        /// <summary>
        /// Gets or sets PayRateString.
        /// </summary>
        [SourceMapAttribute("payRate")]
        public string PayRateString { get; set; }

        /// <summary>
        /// Gets PayRate.
        /// </summary>
        public double PayRate
        {
            get
            {
                double output = 0;
                if (double.TryParse(this.PayRateString, out output))
                {
                    return output;
                }

                return output;
            }
        }

        /// <summary>
        /// Gets or sets RateId
        /// </summary>
        [SourceMapAttribute("rateId")]
        public string RateId { get; set; }

        /// <summary>
        /// Gets or sets ReceiveCurrency.
        /// </summary>
        [SourceMapAttribute("receiveCurrency")]
        public string ReceiveCurrency { get; set; }

        /// <summary>
        /// Gets or sets ReceiveCurrency.
        /// </summary>
        [SourceMapAttribute("receiveRate")]
        public string ReceiveRateString { get; set; }

        /// <summary>
        /// Gets the ReceiveRate.
        /// </summary>
        public double ReceiveRate
        {
            get
            {
                double output = 0;
                if (double.TryParse(this.ReceiveRateString, out output))
                {
                    return output;
                }

                return output;
            }
        }

        #endregion
    }
}
