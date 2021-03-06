namespace Kendo.Mvc.UI
{
    using System;
    using System.Collections;
    using System.Linq.Expressions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.Resources;

    public class ChartBulletSeries<TModel, TValue, TCategory> : IChartBulletSeries where TModel : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartBulletSeries{TModel, TCurrent, TTarget}"/> class.
        /// </summary>
        /// <param name="targetExpression">The expression used to extract the point target from the chart model.</param>
        /// <param name="currentExpression">The expression used to extract the point current from the chart model.</param>
        /// <param name="colorExpression">The expression used to extract the point color from the chart model.</param>
        /// <param name="categoryExpression">The expression used to extract the point category from the chart model.</param>
        /// <param name="noteTextExpression">The expression used to extract the point note text from the chart model.</param>
        public ChartBulletSeries(
            Expression<Func<TModel, TValue>> currentExpression,
            Expression<Func<TModel, TValue>> targetExpression,
            Expression<Func<TModel, string>> colorExpression,
            Expression<Func<TModel, TCategory>> categoryExpression,
            Expression<Func<TModel, string>> noteTextExpression)
        {
            if (typeof(TModel).IsPlainType() && !currentExpression.IsBindable())
            {
                throw new InvalidOperationException(Exceptions.MemberExpressionRequired);
            }

            CurrentMember = currentExpression.MemberWithoutInstance();

            if (typeof(TModel).IsPlainType() && !targetExpression.IsBindable())
            {
                throw new InvalidOperationException(Exceptions.MemberExpressionRequired);
            }

            TargetMember = targetExpression.MemberWithoutInstance();

            if (colorExpression != null) {
                if (typeof(TModel).IsPlainType() && !colorExpression.IsBindable())
                {
                    throw new InvalidOperationException(Exceptions.MemberExpressionRequired);
                }

                ColorMember = colorExpression.MemberWithoutInstance();
            }

            if (categoryExpression != null)
            {
                if (typeof(TModel).IsPlainType() && !categoryExpression.IsBindable())
                {
                    throw new InvalidOperationException(Exceptions.MemberExpressionRequired);
                }

                Category = categoryExpression.Compile();
                CategoryMember = categoryExpression.MemberWithoutInstance();
            }

            if (noteTextExpression != null) {
                if (typeof(TModel).IsPlainType() && !noteTextExpression.IsBindable())
                {
                    throw new InvalidOperationException(Exceptions.MemberExpressionRequired);
                }

                NoteTextMember = noteTextExpression.MemberWithoutInstance();
            }

            if (string.IsNullOrEmpty(Name))
            {
                Name = CurrentMember.AsTitle();
            }

            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartBulletSeries{TModel, TCurrent, TTarget}"/> class.
        /// </summary>
        /// <param name="data">The data to bind to.</param>
        public ChartBulletSeries(IEnumerable data)
        {
            Data = data;
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartBarSeries{TModel, TValue}" /> class.
        /// </summary>
        public ChartBulletSeries()
        {
            Initialize();
        }

        /// <summary>
        /// Gets or sets the series opacity.
        /// </summary>
        /// <value>A value between 0 (transparent) and 1 (opaque).</value>
        public double? Opacity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the series base color.
        /// </summary>
        public string Color
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating if the series is visible
        /// </summary>
        public bool? Visible
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating if the series is visible in the legend
        /// </summary>
        public bool? VisibleInLegend
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the series color function
        /// </summary>
        public ClientHandlerDescriptor ColorHandler
        {
            get;
            set;
        }

        /// <summary>
        /// Aggregate function for date series.
        /// </summary>
        public ClientHandlerDescriptor AggregateHandler
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data point tooltip options.
        /// </summary>
        public ChartTooltip Tooltip
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data point target.
        /// </summary>
        public ChartBulletTarget Target
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the axis name to use for this series.
        /// </summary>
        /// <value>The axis name.</value>
        public string Axis
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the category axis name to use for this series.
        /// </summary>
        /// <value>The category axis name.</value>
        public string CategoryAxis
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title of the series.
        /// </summary>
        /// <value>The title.</value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The distance between category clusters.
        /// </summary>
        /// <value>
        /// A value of 1 means that there is a total of 1 column width / bar height between categories. 
        /// The distance is distributed evenly on each side.
        /// </value>
        public double? Gap
        {
            get;
            set;
        }

        /// <summary>
        /// Space between bars.
        /// </summary>
        /// <value>
        /// Value of 1 means that the distance between bars is equal to their width.
        /// </value>
        public double? Spacing
        {
            get;
            set;
        }

        /// <summary>
        /// The orientation of the bullets.
        /// </summary>
        /// <value>
        /// Can be either <see cref="ChartSeriesOrientation.Horizontal">horizontal</see>
        /// or <see cref="ChartSeriesOrientation.Vertical">vertical</see>.
        /// The default value is horizontal.
        /// </value>
        public ChartSeriesOrientation Orientation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the bullet border.
        /// </summary>
        public ChartElementBorder Border
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the effects overlay.
        /// </summary>
        public ChartBarSeriesOverlay Overlay
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model color member name.
        /// </summary>
        /// <value>The model color member name.</value>
        public string ColorMember
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model note text member name.
        /// </summary>
        /// <value>The model note text member name.</value>
        public string NoteTextMember
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model target member name.
        /// </summary>
        /// <value>The model target member name.</value>
        public string TargetMember
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model current member name.
        /// </summary>
        /// <value>The model current member name.</value>
        public string CurrentMember
        {
            get;
            set;
        }

        /// <summary>
        /// The data used for binding.
        /// </summary>
        public IEnumerable Data
        {
            get;
            set;
        }

        /// <summary>
        /// Name template for auto-generated series when binding to grouped data.
        /// </summary>
        public string GroupNameTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the series highlight options
        /// </summary>
        public ChartSeriesHighlight Highlight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the model data category member name.
        /// </summary>
        /// <value>The model data category member name.</value>
        public string CategoryMember
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a function which returns the category of the property to which the column is bound to.
        /// </summary>
        public Func<TModel, TCategory> Category
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the series notes options
        /// </summary>
        public ChartNote Notes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the series Z-Index.
        /// </summary>
        /// <value>A numeric value that will be compared with
        /// other series to determine stacking order.</value>
        public double? ZIndex
        {
            get;
            set;
        }

        public IChartSerializer CreateSerializer()
        {
            return new ChartBulletSeriesSerializer(this);
        }

        private void Initialize()
        {
            Orientation = ChartSeriesOrientation.Horizontal;
            Border = new ChartElementBorder();
            Tooltip = new ChartTooltip();
            Target = new ChartBulletTarget();
            Notes = new ChartNote();
        }
    }
}