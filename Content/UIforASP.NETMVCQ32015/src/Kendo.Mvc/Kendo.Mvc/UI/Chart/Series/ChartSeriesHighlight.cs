namespace Kendo.Mvc.UI
{
    public class ChartSeriesHighlight
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartSeriesHighlight" /> class.
        /// </summary>
        public ChartSeriesHighlight()
        {
            Border = new ChartElementBorder();
            Line = new ChartAreaLine();
            Markers = new ChartMarkers();
        }

        /// <summary>
        /// Gets or sets the highlight opacity
        /// </summary>
        public double? Opacity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the highlight opacity
        /// </summary>
        public string Color
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the highlight border.
        /// </summary>
        public ChartElementBorder Border
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the highlight line configuration
        /// </summary>
        public ChartAreaLine Line
        {
            get;
            set;
        }

        /// <summary>
        /// The highlight markers configuration.
        /// </summary>
        public ChartMarkers Markers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating if the highlight is visible
        /// </summary>
        public bool? Visible
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the highlight toggle handler.
        /// </summary>
        /// <value>
        /// The highlight toggle handler.
        /// </value>
        public ClientHandlerDescriptor Toggle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the highlight visual handler.
        /// </summary>
        /// <value>
        /// The highlight visual handler.
        /// </value>
        public ClientHandlerDescriptor Visual
        {
            get;
            set;
        }

        public IChartSerializer CreateSerializer()
        {
            return new ChartSeriesHighlightSerializer(this);
        }
    }
}