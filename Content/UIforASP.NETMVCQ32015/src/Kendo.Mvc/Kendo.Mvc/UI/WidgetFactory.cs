namespace Kendo.Mvc.UI.Fluent
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using Kendo.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.Infrastructure;
    using Kendo.Mvc.UI.Html;
    using System.Collections;
    using System.Text;
    using System.Collections.Specialized;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Creates the fluent API builders of the Kendo UI widgets
    /// </summary>
    public class WidgetFactory : IHideObjectMembers
    {
        public WidgetFactory(HtmlHelper htmlHelper)
        {

            HtmlHelper = htmlHelper;
            Initializer = DI.Current.Resolve<IJavaScriptInitializer>();
            UrlGenerator = DI.Current.Resolve<IUrlGenerator>();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IJavaScriptInitializer Initializer
        {
            get;
            private set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IUrlGenerator UrlGenerator
        {
            get;
            private set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HtmlHelper HtmlHelper
        {
            get;
            set;
        }

        private ViewContext ViewContext
        {
            get
            {
                return HtmlHelper.ViewContext;
            }
        }

        private ViewDataDictionary ViewData
        {
            get
            {
                return HtmlHelper.ViewData;
            }
        }

        /// <summary>
        /// Creates a <see cref="Menu"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Menu()
        ///             .Name("Menu")
        ///             .Items(items => { /* add items here */ });
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MenuBuilder Menu()
        {
            return new MenuBuilder(new Menu(ViewContext, Initializer, UrlGenerator, DI.Current.Resolve<INavigationItemAuthorization>()));
        }

        /// <summary>
        /// Creates a <see cref="TreeList"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeList(Model)
        ///             .Name("TreeList")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TreeListBuilder<T> TreeList<T>(IEnumerable<T> dataSource) where T : class
        {
            var builder = new TreeListBuilder<T>(new TreeList<T>(ViewContext, Initializer, UrlGenerator));

            builder.Component.DataSource.Data = dataSource;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Grid{T}"/> bound to the specified data item type.
        /// </summary>
        /// <example>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Grid&lt;Order&gt;()
        ///             .Name("Grid")
        ///             .BindTo(Model)
        /// %&gt;
        /// </code>
        /// </example>      
        public virtual GridBuilder<T> Grid<T>() where T : class
        {
            return new GridBuilder<T>(new Grid<T>(ViewContext,
                Initializer,
                UrlGenerator,
                DI.Current.Resolve<IGridHtmlBuilderFactory>()));
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Grid{T}"/> bound to the specified data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Grid(Model)
        ///             .Name("Grid")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual GridBuilder<T> Grid<T>(IEnumerable<T> dataSource) where T : class
        {
            GridBuilder<T> builder = Grid<T>();

            builder.Component.DataSource.Data = dataSource;

            return builder;
        }        

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Grid{T}"/> bound to a DataTable.
        /// </summary>
        /// <param name="dataSource">DataTable from which the grid instance will be bound</param>
        public virtual GridBuilder<DataRowView> Grid(DataTable dataSource)
        {
            GridBuilder<DataRowView> builder = Grid<DataRowView>();
            
            builder.Component.DataSource.Data = dataSource.WrapAsEnumerable();

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Grid{T}"/> bound to a DataView.
        /// </summary>
        /// <param name="dataSource">DataView from which the grid instance will be bound</param>
        public virtual GridBuilder<DataRowView> Grid(DataView dataSource)
        {
            GridBuilder<DataRowView> builder = Grid<DataRowView>();

            builder.Component.DataSource.Data = dataSource.Table.WrapAsEnumerable();

            return builder;
        }   

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Grid{T}"/> bound an item in ViewData.
        /// </summary>
        /// <typeparam name="T">Type of the data item</typeparam>
        /// <param name="dataSourceViewDataKey">The data source view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Grid&lt;Order&gt;("orders")
        ///             .Name("Grid")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual GridBuilder<T> Grid<T>(string dataSourceViewDataKey) where T : class
        {
            GridBuilder<T> builder = Grid<T>();

            builder.Component.DataSource.Data = ViewContext.ViewData.Eval(dataSourceViewDataKey) as IEnumerable<T>;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.ListView{T}"/> bound to the specified data item type.
        /// </summary>
        /// <example>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ListView&lt;Order&gt;()
        ///             .Name("ListView")
        ///             .BindTo(Model)
        /// %&gt;
        /// </code>
        /// </example>        
        public virtual ListViewBuilder<T> ListView<T>() where T : class
        {
            return new ListViewBuilder<T>(new ListView<T>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.ListView{T}"/> bound to the specified data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ListView(Model)
        ///             .Name("ListView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ListViewBuilder<T> ListView<T>(IEnumerable<T> dataSource) where T : class
        {
            ListViewBuilder<T> builder = ListView<T>();

            builder.Component.DataSource.Data = dataSource;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.ListView{T}"/> bound an item in ViewData.
        /// </summary>
        /// <typeparam name="T">Type of the data item</typeparam>
        /// <param name="dataSourceViewDataKey">The data source view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ListView&lt;Order&gt;("orders")
        ///             .Name("ListView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ListViewBuilder<T> ListView<T>(string dataSourceViewDataKey) where T : class
        {
            ListViewBuilder<T> builder = ListView<T>();

            builder.Component.DataSource.Data = ViewContext.ViewData.Eval(dataSourceViewDataKey) as IEnumerable<T>;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.MobileListView{T}"/> bound to the specified data item type.
        /// </summary>
        /// <example>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileListView&lt;Order&gt;()
        ///             .Name("MobileListView")
        ///             .BindTo(Model)
        /// %&gt;
        /// </code>
        /// </example>        
        public virtual MobileListViewBuilder<T> MobileListView<T>() where T : class
        {
            return new MobileListViewBuilder<T>(new MobileListView<T>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="MobileListView"/>.
        /// </summary>
        /// <example>        
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileListView()
        ///             .Name("MobileListView")
        ///             .Items(items => 
        ///             {
        ///                 items.Add().Text("Item");
        ///                 items.AddLink().Text("Link Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example> 
        public virtual MobileListViewBuilder<object> MobileListView()
        {
            return new MobileListViewBuilder<object>(new MobileListView<object>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.MobileListView{T}"/> bound to the specified data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileListView(Model)
        ///             .Name("MobileListView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileListViewBuilder<T> MobileListView<T>(IEnumerable<T> dataSource) where T : class
        {
            MobileListViewBuilder<T> builder = MobileListView<T>();

            builder.Component.DataSource.Data = dataSource;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.MobileListView{T}"/> bound an item in ViewData.
        /// </summary>
        /// <typeparam name="T">Type of the data item</typeparam>
        /// <param name="dataSourceViewDataKey">The data source view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileListView&lt;Order&gt;("orders")
        ///             .Name("MobileListView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileListViewBuilder<T> MobileListView<T>(string dataSourceViewDataKey) where T : class
        {
            MobileListViewBuilder<T> builder = MobileListView<T>();

            builder.Component.DataSource.Data = ViewContext.ViewData.Eval(dataSourceViewDataKey) as IEnumerable<T>;

            return builder;
        }

        /// <summary>
        /// Creates a <see cref="Splitter"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Splitter()
        ///             .Name("Splitter");
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SplitterBuilder Splitter()
        {
            return new SplitterBuilder(new Splitter(ViewContext, Initializer));
        }

        /// <summary>
        /// Creates a new <see cref="TabStrip"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TabStrip()
        ///             .Name("TabStrip")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First");
        ///                 items.Add().Text("Second");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TabStripBuilder TabStrip()
        {
            return new TabStripBuilder(new TabStrip(ViewContext, Initializer, UrlGenerator, DI.Current.Resolve<INavigationItemAuthorization>()));
        }

        /// <summary>
        /// Creates a new <see cref="DateTimePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DateTimePicker()
        ///             .Name("DateTimePicker")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual DateTimePickerBuilder DateTimePicker()
        {
            return new DateTimePickerBuilder(new DateTimePicker(ViewContext, Initializer, ViewData));
        }


        /// <summary>
        /// Creates a new <see cref="DatePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DatePicker()
        ///             .Name("DatePicker")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual DatePickerBuilder DatePicker()
        {
            return new DatePickerBuilder(new DatePicker(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="TimePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TimePicker()
        ///             .Name("TimePicker")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TimePickerBuilder TimePicker()
        {
            return new TimePickerBuilder(new TimePicker(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="Barcode"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Barcode()
        ///             .For("Container")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual BarcodeBuilder Barcode()
        {
            return new BarcodeBuilder(new Barcode(ViewContext, Initializer));
        }

        /// <summary>
        /// Creates a new <see cref="Sortable"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Sortable()
        ///             .For("Container")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SortableBuilder Sortable()
        {
            return new SortableBuilder(new Sortable(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="Tooltip"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Tooltip()
        ///             .For("Container")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TooltipBuilder Tooltip()
        {
            return new TooltipBuilder(new Tooltip(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="ColorPalette"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ColorPalette()
        ///             .Name("ColorPalette")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ColorPaletteBuilder ColorPalette()
        {
            return new ColorPaletteBuilder(new ColorPalette(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="FlatColorPicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().FlatColorPicker()
        ///             .Name("FlatColorPicker")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual FlatColorPickerBuilder FlatColorPicker()
        {
            return new FlatColorPickerBuilder(new FlatColorPicker(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="Calendar"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Calendar()
        ///             .Name("Calendar")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual CalendarBuilder Calendar()
        {
            return new CalendarBuilder(new Calendar(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="PanelBar"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().PanelBar()
        ///             .Name("PanelBar")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First");
        ///                 items.Add().Text("Second");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual PanelBarBuilder PanelBar()
        {
            return new PanelBarBuilder(new PanelBar(ViewContext, Initializer, UrlGenerator, DI.Current.Resolve<INavigationItemAuthorization>()));
        }

        /// <summary>
        /// Creates a new <see cref="RecurrenceEditor"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().RecurrenceEditor()
        ///             .Name("recurrenceEditor")
        ///             .FirstWeekDay(0)
        ///             .Timezone("Etc/UTC")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual RecurrenceEditorBuilder RecurrenceEditor()
        {
            return new RecurrenceEditorBuilder(new RecurrenceEditor(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="TimezoneEditor"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TimezoneEditor()
        ///             .Name(&quot;timezoneEditor&quot;)
        ///             .Value("Etc/UTC")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TimezoneEditorBuilder TimezoneEditor()
        {
            return new TimezoneEditorBuilder(new TimezoneEditor(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="Scheduler{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Scheduler&lt;SchedulerEvent&gt;()
        ///             .Name("Scheduler")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SchedulerBuilder<T> Scheduler<T>() where T : class, ISchedulerEvent
        {
            return new SchedulerBuilder<T>(new Scheduler<T>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="PivotGrid{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().PivotGrid()
        ///             .Name("PivotGrid")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual PivotGridBuilder<object> PivotGrid()
        {
            return new PivotGridBuilder<object>(new PivotGrid<object>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="PivotGrid{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().PivotGrid&lt;EventData&gt;()
        ///             .Name("PivotGrid")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual PivotGridBuilder<T> PivotGrid<T>() where T : class
        {
            return new PivotGridBuilder<T>(new PivotGrid<T>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="PivotConfigurator"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().PivotConfigurator()
        ///             .Name("PivotConfigurator")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual PivotConfiguratorBuilder PivotConfigurator()
        {
            return new PivotConfiguratorBuilder(new PivotConfigurator(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().NumericTextBox()
        ///             .Name("NumericTextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<double> NumericTextBox()
        {
            return new NumericTextBoxBuilder<double>(new NumericTextBox<double>(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().NumericTextBox&lt;double&gt;()
        ///             .Name("NumericTextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<T> NumericTextBox<T>() where T: struct
        {
            return new NumericTextBoxBuilder<T>(new NumericTextBox<T>(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="CurrencyTextBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().CurrencyTextBox()
        ///             .Name("CurrencyTextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<decimal> CurrencyTextBox()
        {
            return NumericTextBox<decimal>().Format("c");
        }

        /// <summary>
        /// Creates a new <see cref="PercentTextBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().PercentTextBox()
        ///             .Name("PercentTextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<double> PercentTextBox()
        {
            return NumericTextBox().Format("p");
        }

        /// <summary>
        /// Creates a new <see cref="IntegerTextBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().IntegerTextBox()
        ///             .Name("IntegerTextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<int> IntegerTextBox()
        {
            return NumericTextBox<int>().Format("n0").Decimals(0);
        }

        /// <summary>
        /// Creates a new <see cref="MaskedTextBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MaskedTextBox()
        ///             .Name("MaskedTextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MaskedTextBoxBuilder MaskedTextBox()
        {
            return new MaskedTextBoxBuilder(new MaskedTextBox(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="CheckBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().CheckBox()
        ///             .Name("CheckBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual CheckBoxBuilder CheckBox()
        {
            return new CheckBoxBuilder(new CheckBox(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="RadioButton"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().RadioButton()
        ///             .Name("RadioButton")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual RadioButtonBuilder RadioButton()
        {
            return new RadioButtonBuilder(new RadioButton(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="TextBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TextBox()
        ///             .Name("TextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TextBoxBuilder<string> TextBox()
        {
            return new TextBoxBuilder<string>(new TextBox<string>(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="TextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TextBox&lt;double&gt;()
        ///             .Name("TextBox")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TextBoxBuilder<T> TextBox<T>()
        {
            return new TextBoxBuilder<T>(new TextBox<T>(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="Window"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Window()
        ///             .Name("Window")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual WindowBuilder Window()
        {
            return new WindowBuilder(new Window(ViewContext, Initializer));
        }

        /// <summary>
        /// Creates a new <see cref="LinearGauge"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().LinearGauge()
        ///            .Name("linearGauge")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual LinearGaugeBuilder LinearGauge()
        {
            return new LinearGaugeBuilder(new LinearGauge(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="RadialGauge"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().RadialGauge()
        ///            .Name("radialGauge")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual RadialGaugeBuilder RadialGauge()
        {
            return new RadialGaugeBuilder(new RadialGauge(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="DropDownList"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DropDownList()
        ///             .Name("DropDownList")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual DropDownListBuilder DropDownList()
        {
            return new DropDownListBuilder(new DropDownList(ViewContext, Initializer, ViewData, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="ComboBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ComboBox()
        ///             .Name("ComboBox")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ComboBoxBuilder ComboBox()
        {
            return new ComboBoxBuilder(new ComboBox(ViewContext, Initializer, ViewData, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="AutoComplete"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().AutoComplete()
        ///             .Name("AutoComplete")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual AutoCompleteBuilder AutoComplete()
        {
            return new AutoCompleteBuilder(new AutoComplete(ViewContext, Initializer, ViewData, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="MultiSelect"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MultiSelect()
        ///             .Name("MultiSelect")
        ///             .Items(items =>
        ///             {
        ///                 items.Add().Text("First Item");
        ///                 items.Add().Text("Second Item");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MultiSelectBuilder MultiSelect()
        {
            return new MultiSelectBuilder(new MultiSelect(ViewContext, Initializer, ViewData, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="Slider"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Slider()
        ///             .Name("Slider")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SliderBuilder<T> Slider<T>() where T: struct, IComparable
        {
            return new SliderBuilder<T>(new Slider<T>(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="Slider"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Slider()
        ///             .Name("Slider")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SliderBuilder<double> Slider()
        {
            return new SliderBuilder<double>(new Slider<double>(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="RangeSlider"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().RangeSlider()
        ///             .Name("RangeSlider")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual RangeSliderBuilder<T> RangeSlider<T>() where T : struct, IComparable
        {
            return new RangeSliderBuilder<T>(new RangeSlider<T>(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="RangeSlider"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().RangeSlider()
        ///             .Name("RangeSlider")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual RangeSliderBuilder<double> RangeSlider()
        {
            return new RangeSliderBuilder<double>(new RangeSlider<double>(ViewContext, Initializer, ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="ProgressBar"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ProgressBar()
        ///       .Name("progressBar")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ProgressBarBuilder ProgressBar()
        {
            return new ProgressBarBuilder(new ProgressBar(ViewContext, Initializer));
        }

        /// <summary>
        /// Creates a <see cref="Upload"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Upload()
        ///             .Name("Upload")
        ///             .Async(async => async
        ///                 .Save("ProcessAttachments", "Home")
        ///                 .Remove("RemoveAttachment", "Home")
        ///             )
        /// %&gt;
        /// </code>
        /// </example>
        public virtual UploadBuilder Upload()
        {
            return new UploadBuilder(
                new Upload(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a <see cref="Button"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Button()
        ///             .Name("Button1");
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ButtonBuilder Button()
        {
            return new ButtonBuilder(new Button(ViewContext, Initializer));
        }

        /// <summary>
        /// Creates a <see cref="Notification"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Notification()
        ///             .Name("Notification1");
        /// %&gt;
        /// </code>
        /// </example>
        public virtual NotificationBuilder Notification()
        {
            return new NotificationBuilder(new Notification(ViewContext, Initializer));
        }

        /// <summary>
        /// Creates a <see cref="Kendo.Mvc.UI.Chart{T}"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Chart()
        ///             .Name("Chart")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ChartBuilder<T> Chart<T>() where T : class
        {
            return new ChartBuilder<T>(new Chart<T>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Chart{T}"/> bound to the specified data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="data">The data source.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Chart(Model)
        ///             .Name("Chart")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ChartBuilder<T> Chart<T>(IEnumerable<T> data) where T : class
        {
            ChartBuilder<T> builder = Chart<T>();

            builder.Component.Data = data;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Chart{T}"/> bound an item in ViewData.
        /// </summary>
        /// <typeparam name="T">Type of the data item</typeparam>
        /// <param name="dataViewDataKey">The data source view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Chart&lt;SalesData&gt;("sales")
        ///             .Name("Chart")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ChartBuilder<T> Chart<T>(string dataViewDataKey) where T : class
        {
            ChartBuilder<T> builder = Chart<T>();

            builder.Component.Data = ViewContext.ViewData.Eval(dataViewDataKey) as IEnumerable<T>;

            return builder;
        }

        /// <summary>
        /// Creates a new unbound <see cref="Chart"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().Chart()
        ///             .Name("Chart")
        ///             .Series(series => {
        ///                 series.Bar(new int[] { 1, 2, 3 }).Name("Total Sales");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ChartBuilder<object> Chart()
        {
            ChartBuilder<object> builder = Chart<object>();

            return builder;
        }

        /// <summary>
        /// Creates a <see cref="Kendo.Mvc.UI.StockChart{T}"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().StockChart()
        ///             .Name("StockChart")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual StockChartBuilder<T> StockChart<T>() where T : class
        {
            return new StockChartBuilder<T>(new StockChart<T>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.StockChart{T}"/> bound to the specified data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="data">The data source.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().StockChart(Model)
        ///             .Name("StockChart")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual StockChartBuilder<T> StockChart<T>(IEnumerable<T> data) where T : class
        {
            StockChartBuilder<T> builder = StockChart<T>();

            builder.Component.Data = data;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.StockChart{T}"/> bound an item in ViewData.
        /// </summary>
        /// <typeparam name="T">Type of the data item</typeparam>
        /// <param name="dataViewDataKey">The data source view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().StockChart&lt;SalesData&gt;("sales")
        ///             .Name("StockChart")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual StockChartBuilder<T> StockChart<T>(string dataViewDataKey) where T : class
        {
            StockChartBuilder<T> builder = StockChart<T>();

            builder.Component.Data = ViewContext.ViewData.Eval(dataViewDataKey) as IEnumerable<T>;

            return builder;
        }

        /// <summary>
        /// Creates a new unbound <see cref="StockChart"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().StockChart()
        ///             .Name("StockChart")
        ///             .Series(series => {
        ///                 series.Bar(new int[] { 1, 2, 3 }).Name("Total Sales");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual StockChartBuilder<object> StockChart()
        {
            StockChartBuilder<object> builder = StockChart<object>();

            return builder;
        }

        /// <summary>
        /// Creates a <see cref="Kendo.Mvc.UI.Sparkline{T}"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Sparkline()
        ///             .Name("Sparkline")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SparklineBuilder<T> Sparkline<T>() where T : class
        {
            return new SparklineBuilder<T>(new Sparkline<T>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Sparkline{T}"/> bound to the specified data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="data">The data source.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Sparkline(Model)
        ///             .Name("Sparkline")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SparklineBuilder<T> Sparkline<T>(IEnumerable<T> data) where T : class
        {
            SparklineBuilder<T> builder = Sparkline<T>();

            builder.Component.Data = data;

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Sparkline{T}"/> bound an item in ViewData.
        /// </summary>
        /// <typeparam name="T">Type of the data item</typeparam>
        /// <param name="dataViewDataKey">The data source view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Sparkline&lt;SalesData&gt;("sales")
        ///             .Name("Sparkline")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SparklineBuilder<T> Sparkline<T>(string dataViewDataKey) where T : class
        {
            SparklineBuilder<T> builder = Sparkline<T>();

            builder.Component.Data = ViewContext.ViewData.Eval(dataViewDataKey) as IEnumerable<T>;

            return builder;
        }

        /// <summary>
        /// Creates a new unbound <see cref="Sparkline"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.Kendo().Sparkline()
        ///             .Name("Sparkline")
        ///             .Series(series => {
        ///                 series.Bar(new int[] { 1, 2, 3 }).Name("Total Sales");
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SparklineBuilder<object> Sparkline()
        {
            SparklineBuilder<object> builder = Sparkline<object>();

            return builder;
        }

        /// <summary>
        /// Creates a <see cref="QRCode"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().QRCode()
        ///             .Name("qrCode")
        ///             .Value("Hello World")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual QRCodeBuilder QRCode()
        {
            return new QRCodeBuilder(new QRCode(ViewContext, Initializer));
        }


        /// <summary>
        /// Returns the kendo culture script for the current .NET culture.
        /// </summary>
        /// <param name="renderScriptTags">Determines if the script should be rendered within a script tag</param>
        public virtual MvcHtmlString Culture(bool renderScriptTags = true)
        {
            return Culture(null, renderScriptTags);
        }

        /// <summary>
        /// Returns the kendo culture scripts for the specified .NET culture.
        /// </summary>
        /// <param name="name">The name of the culture.</param>
        /// <param name="renderScriptTags">Determines if the script should be rendered within a script tag</param>        
        public virtual MvcHtmlString Culture(string name, bool renderScriptTags = true)
        {
            var result = new StringBuilder();

            if (renderScriptTags)
            {
                result.Append("<script>");
            }

            result.Append(CultureGenerator.Generate(name));

            if (renderScriptTags)
            {
                result.Append("</script>");
            }

            return new MvcHtmlString(result.ToString());
        }

        /// <summary>
        /// Returns the initialization scripts for widgets set as deferred
        /// </summary>
        /// <param name="renderScriptTags">Determines if the script should be rendered within a script tag</param>
        /// <returns></returns>
        public virtual MvcHtmlString DeferredScripts(bool renderScriptTags = true)
        {
            var items = ViewContext.HttpContext.Items;

            if (items.Contains(WidgetBase.DeferredScriptsKey))
            {
                var scripts = (OrderedDictionary)items[WidgetBase.DeferredScriptsKey];

                return DeferredScripts(scripts.Values.Cast<string>(), renderScriptTags);
            }

            return MvcHtmlString.Empty;
        }

        private MvcHtmlString DeferredScripts(IEnumerable<string> scripts, bool renderScriptTags)
        {
            var result = new StringBuilder();

            if (renderScriptTags)
            {
                result.Append("<script>");
            }

            foreach (var script in scripts)
            {
                result.Append(script);
            }

            if (renderScriptTags)
            {
                result.Append("</script>");
            }

            return new MvcHtmlString(result.ToString());
        }

        /// <summary>
        /// Returns the initialization scripts for the specified widget.
        /// </summary>
        /// <param name="name">The name of the widget.</param>
        /// <param name="renderScriptTags">Determines if the script should be rendered within a script tag</param>
        /// <returns></returns>
        public virtual MvcHtmlString DeferredScriptsFor(string name, bool renderScriptTags = true)
        {
            var items = ViewContext.HttpContext.Items;

            if (items.Contains(WidgetBase.DeferredScriptsKey))
            {
                var scripts = (OrderedDictionary)items[WidgetBase.DeferredScriptsKey];

                if (scripts.Contains(name))
                {
                    return DeferredScripts(new [] { (string)scripts[name] }, renderScriptTags);
                }
            }

            return MvcHtmlString.Empty;
        }

        /// <summary>
        /// Creates a <see cref="Menu"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Menu()
        ///             .Name("Menu")
        ///             .Items(items => { /* add items here */ });
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ContextMenuBuilder ContextMenu()
        {
            return new ContextMenuBuilder(new ContextMenu(ViewContext, Initializer, UrlGenerator, DI.Current.Resolve<INavigationItemAuthorization>()));
        }

        //>> DataVizComponents 
        /// <summary>
        /// Creates a <see cref="ColorPicker"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ColorPicker()
        ///             .Name("ColorPicker")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ColorPickerBuilder ColorPicker()
        {
            return new ColorPickerBuilder(new ColorPicker(ViewContext, Initializer, ViewData));
        }
        
        /// <summary>
        /// Creates a <see cref="Editor"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Editor()
        ///             .Name("Editor")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual EditorBuilder Editor()
        {
            return new EditorBuilder(new Editor(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="Gantt"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Gantt()
        ///             .Name("Gantt")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual GanttBuilder<TTaskModel,TDependenciesModel> Gantt<TTaskModel,TDependenciesModel>() where TTaskModel : class, IGanttTask  where TDependenciesModel : class, IGanttDependency
        {
            return new GanttBuilder<TTaskModel,TDependenciesModel>(new Gantt<TTaskModel,TDependenciesModel>(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="Map"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Map()
        ///             .Name("Map")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MapBuilder Map()
        {
            return new MapBuilder(new Map(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="ResponsivePanel"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ResponsivePanel()
        ///             .Name("ResponsivePanel")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ResponsivePanelBuilder ResponsivePanel()
        {
            return new ResponsivePanelBuilder(new ResponsivePanel(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="Spreadsheet"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Spreadsheet()
        ///             .Name("Spreadsheet")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual SpreadsheetBuilder Spreadsheet()
        {
            return new SpreadsheetBuilder(new Spreadsheet(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="ToolBar"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ToolBar()
        ///             .Name("ToolBar")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ToolBarBuilder ToolBar()
        {
            return new ToolBarBuilder(new ToolBar(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="TreeList"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeList()
        ///             .Name("TreeList")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TreeListBuilder<T> TreeList<T>() where T : class
        {
            return new TreeListBuilder<T>(new TreeList<T>(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="TreeMap"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeMap()
        ///             .Name("TreeMap")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TreeMapBuilder TreeMap()
        {
            return new TreeMapBuilder(new TreeMap(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="TreeView"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeView()
        ///             .Name("TreeView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TreeViewBuilder TreeView()
        {
            return new TreeViewBuilder(new TreeView(ViewContext, Initializer, UrlGenerator, DI.Current.Resolve<INavigationItemAuthorization>()));
        }
        //<< DataVizComponents

        /// <summary>
        /// Creates a <see cref="Diagram"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Diagram()
        ///             .Name("Diagram")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual DiagramBuilder<object, object> Diagram()
        {
            return new DiagramBuilder<object, object>(new Diagram<object, object>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a <see cref="Diagram"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Diagram()
        ///             .Name("Diagram")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual DiagramBuilder<TShapeModel, TConnectionModel> Diagram<TShapeModel, TConnectionModel>()
            where TShapeModel : class
            where TConnectionModel : class
        {
            return new DiagramBuilder<TShapeModel, TConnectionModel>(new Diagram<TShapeModel, TConnectionModel>(ViewContext, Initializer, UrlGenerator));
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Gantt{T}"/> bound to the specified data source.
        /// </summary>
        /// <typeparam name="T">The type of the data item</typeparam>
        /// <param name="dataSource">The data source.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Gantt(ViewBag.Tasks)
        ///             .Name("Gantt")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual GanttBuilder<TTaskModel, TDependenciesModel> Gantt<TTaskModel, TDependenciesModel>(IEnumerable<TTaskModel> dataSource, IEnumerable<TDependenciesModel> dependenciesDataSource = null)
            where TTaskModel : class, IGanttTask
            where TDependenciesModel : class, IGanttDependency
        {
            GanttBuilder<TTaskModel, TDependenciesModel> builder = Gantt<TTaskModel, TDependenciesModel>();

            builder.Component.DataSource.Data = dataSource;

            if (dependenciesDataSource != null)
            {
                builder.Component.DependenciesDataSource.Data = dependenciesDataSource;
            }

            return builder;
        }

        /// <summary>
        /// Creates a new <see cref="Kendo.Mvc.UI.Gantt{T}"/> bound an item in ViewData.
        /// </summary>
        /// <typeparam name="T">Type of the data item</typeparam>
        /// <param name="dataSourceViewDataKey">The data source view data key.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().Gantt("tasks")
        ///             .Name("Gantt")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual GanttBuilder<TTaskModel, TDependenciesModel> Gantt<TTaskModel, TDependenciesModel>(string dataSourceViewDataKey, string dependenciesDataSourceViewDataKey = null)
            where TTaskModel : class, IGanttTask
            where TDependenciesModel : class, IGanttDependency
        {
            GanttBuilder<TTaskModel, TDependenciesModel> builder = Gantt<TTaskModel, TDependenciesModel>();

            builder.Component.DataSource.Data = ViewContext.ViewData.Eval(dataSourceViewDataKey) as IEnumerable<TTaskModel>;

            if (!string.IsNullOrWhiteSpace(dependenciesDataSourceViewDataKey))
            {
                builder.Component.DependenciesDataSource.Data = ViewContext.ViewData.Eval(dependenciesDataSourceViewDataKey) as IEnumerable<TDependenciesModel>;
            }

            return builder;
        }

        //>> MobileComponents 
        /// <summary>
        /// Creates a <see cref="MobileActionSheet"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileActionSheet()
        ///             .Name("MobileActionSheet")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileActionSheetBuilder MobileActionSheet()
        {
            return new MobileActionSheetBuilder(new MobileActionSheet(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileApplication"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileApplication()
        ///             .Name("MobileApplication")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileApplicationBuilder MobileApplication()
        {
            return new MobileApplicationBuilder(new MobileApplication(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileBackButton"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileBackButton()
        ///             .Name("MobileBackButton")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileBackButtonBuilder MobileBackButton()
        {
            return new MobileBackButtonBuilder(new MobileBackButton(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileButton"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileButton()
        ///             .Name("MobileButton")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileButtonBuilder MobileButton()
        {
            return new MobileButtonBuilder(new MobileButton(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileButtonGroup"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileButtonGroup()
        ///             .Name("MobileButtonGroup")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileButtonGroupBuilder MobileButtonGroup()
        {
            return new MobileButtonGroupBuilder(new MobileButtonGroup(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileCollapsible"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileCollapsible()
        ///             .Name("MobileCollapsible")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileCollapsibleBuilder MobileCollapsible()
        {
            return new MobileCollapsibleBuilder(new MobileCollapsible(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileDetailButton"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileDetailButton()
        ///             .Name("MobileDetailButton")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileDetailButtonBuilder MobileDetailButton()
        {
            return new MobileDetailButtonBuilder(new MobileDetailButton(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileDrawer"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileDrawer()
        ///             .Name("MobileDrawer")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileDrawerBuilder MobileDrawer()
        {
            return new MobileDrawerBuilder(new MobileDrawer(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileLayout"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileLayout()
        ///             .Name("MobileLayout")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileLayoutBuilder MobileLayout()
        {
            return new MobileLayoutBuilder(new MobileLayout(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileModalView"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileModalView()
        ///             .Name("MobileModalView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileModalViewBuilder MobileModalView()
        {
            return new MobileModalViewBuilder(new MobileModalView(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileNavBar"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileNavBar()
        ///             .Name("MobileNavBar")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileNavBarBuilder MobileNavBar()
        {
            return new MobileNavBarBuilder(new MobileNavBar(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobilePopOver"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobilePopOver()
        ///             .Name("MobilePopOver")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobilePopOverBuilder MobilePopOver()
        {
            return new MobilePopOverBuilder(new MobilePopOver(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileScrollView"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileScrollView()
        ///             .Name("MobileScrollView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileScrollViewBuilder MobileScrollView()
        {
            return new MobileScrollViewBuilder(new MobileScrollView(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileSplitView"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileSplitView()
        ///             .Name("MobileSplitView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileSplitViewBuilder MobileSplitView()
        {
            return new MobileSplitViewBuilder(new MobileSplitView(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileSwitch"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileSwitch()
        ///             .Name("MobileSwitch")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileSwitchBuilder MobileSwitch()
        {
            return new MobileSwitchBuilder(new MobileSwitch(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileTabStrip"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileTabStrip()
        ///             .Name("MobileTabStrip")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileTabStripBuilder MobileTabStrip()
        {
            return new MobileTabStripBuilder(new MobileTabStrip(ViewContext, Initializer, UrlGenerator));
        }
        
        /// <summary>
        /// Creates a <see cref="MobileView"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MobileView()
        ///             .Name("MobileView")
        /// %&gt;
        /// </code>
        /// </example>
        public virtual MobileViewBuilder MobileView()
        {
            return new MobileViewBuilder(new MobileView(ViewContext, Initializer, UrlGenerator));
        }
        //<< MobileComponents

    }

    public class WidgetFactory<TModel> : WidgetFactory
    {
        private static readonly Regex StringFormatExpression = new Regex(@"(?<=\{\d:)(.)*(?=\})", RegexOptions.Compiled);
        private readonly string minimumValidator;
        private readonly string maximumValidator;

        public WidgetFactory(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            this.HtmlHelper = htmlHelper;


            minimumValidator = "min";
            maximumValidator = "max";
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new HtmlHelper<TModel> HtmlHelper
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new <see cref="Editor" /> UI component.
        /// </summary>
        public virtual EditorBuilder EditorFor(Expression<Func<TModel, string>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);

            return Editor()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Value((string)metadata.Model);
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{TValue}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().NumericTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<TValue> NumericTextBoxFor<TValue>(Expression<Func<TModel, Nullable<TValue>>> expression)
            where TValue : struct
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);         

            return NumericTextBox<TValue>()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value((Nullable<TValue>)metadata.Model)
                    .Min(GetRangeValidationParameter<TValue>(validators, minimumValidator))
                    .Max(GetRangeValidationParameter<TValue>(validators, maximumValidator));
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().NumericTextBoxFor(m=>m.NullableProperty) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<TValue> NumericTextBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
            where TValue : struct
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            return NumericTextBox<TValue>()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value((Nullable<TValue>)ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData).Model)
                    .Min(GetRangeValidationParameter<TValue>(validators, minimumValidator))
                    .Max(GetRangeValidationParameter<TValue>(validators, maximumValidator));
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().IntegerTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<int> IntegerTextBoxFor(Expression<Func<TModel, Nullable<int>>> expression)
        {
            return NumericTextBoxFor<int>(expression).Format("n0").Decimals(0);
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().IntegerTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<short> IntegerTextBoxFor(Expression<Func<TModel, Nullable<short>>> expression)
        {
            return NumericTextBoxFor<short>(expression).Format("n0").Decimals(0);
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().IntegerTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<long> IntegerTextBoxFor(Expression<Func<TModel, Nullable<long>>> expression)
        {
            return NumericTextBoxFor<long>(expression).Format("n0").Decimals(0);
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().IntegerTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<int> IntegerTextBoxFor(Expression<Func<TModel, int>> expression)
        {
            return NumericTextBoxFor<int>(expression).Format("n0").Decimals(0);
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().CurrencyTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<decimal> CurrencyTextBoxFor(Expression<Func<TModel, Nullable<decimal>>> expression)
        {
            return NumericTextBoxFor<decimal>(expression).Format("c");
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().CurrencyTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<decimal> CurrencyTextBoxFor(Expression<Func<TModel, decimal>> expression)
        {
            return NumericTextBoxFor<decimal>(expression).Format("c");
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().PercentTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<double> PercentTextBoxFor(Expression<Func<TModel, Nullable<double>>> expression)
        {
            return NumericTextBoxFor<double>(expression).Format("p");
        }

        /// <summary>
        /// Creates a new <see cref="NumericTextBox{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().PercentTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual NumericTextBoxBuilder<double> PercentTextBoxFor(Expression<Func<TModel, double>> expression)
        {
            return NumericTextBoxFor<double>(expression).Format("p");
        }

        /// <summary>
        /// Creates a new <see cref="MaskedTextBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MaskedTextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual MaskedTextBoxBuilder MaskedTextBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return MaskedTextBox()
                        .Name(GetName(expression))
                        .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                        .Value(GetValue(expression));
        }

        /// <summary>
        /// Creates a new <see cref="CheckBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().CheckBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual CheckBoxBuilder CheckBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            bool checkedValue = false;
            object model = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData).Model;

            if (model != null && model.GetType().IsPredefinedType())
            {
                checkedValue = Convert.ToBoolean(model);
            }

            return CheckBox()
                        .Name(GetName(expression))
                        .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                        .Checked(checkedValue);
        }

        /// <summary>
        /// Creates a new <see cref="RadioButton"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().RadioButtonFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual RadioButtonBuilder RadioButtonFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            object model = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData).Model;

            return RadioButton()
                        .Name(GetName(expression))
                        .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData));
        }

        /// <summary>
        /// Creates a new <see cref="TextBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TextBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual TextBoxBuilder<TProperty> TextBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            object model = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData).Model;

            return TextBox<TProperty>()
                        .Name(GetName(expression))
                        .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                        .Value((TProperty)(model != null && model.GetType().IsPredefinedType() ? model : null));
        }

        /// <summary>
        /// Creates a new <see cref="DateTimePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DateTimePickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual DateTimePickerBuilder DateTimePickerFor(Expression<Func<TModel, Nullable<DateTime>>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            return DateTimePicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value(metadata.Model as DateTime?)
                    .Min(GetRangeValidationParameter<DateTime>(validators, minimumValidator) ?? Kendo.Mvc.UI.DateTimePicker.defaultMinDate)
                    .Max(GetRangeValidationParameter<DateTime>(validators, maximumValidator) ?? Kendo.Mvc.UI.DateTimePicker.defaultMaxDate);
        }

        /// <summary>
        /// Creates a new <see cref="DateTimePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DateTimePickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual DateTimePickerBuilder DateTimePickerFor(Expression<Func<TModel, DateTime>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            return DateTimePicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value(metadata.Model as DateTime?)
                    .Min(GetRangeValidationParameter<DateTime>(validators, minimumValidator) ?? Kendo.Mvc.UI.DateTimePicker.defaultMinDate)
                    .Max(GetRangeValidationParameter<DateTime>(validators, maximumValidator) ?? Kendo.Mvc.UI.DateTimePicker.defaultMaxDate);
        }

        /// <summary>
        /// Creates a new <see cref="ColorPicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ColorPickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual ColorPickerBuilder ColorPickerFor(Expression<Func<TModel, String>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            return ColorPicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Value(metadata.Model as String);
        }

        /// <summary>
        /// Creates a new <see cref="DatePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DatePickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual DatePickerBuilder DatePickerFor(Expression<Func<TModel, Nullable<DateTime>>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            return DatePicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value(metadata.Model as DateTime?)
                    .Min(GetRangeValidationParameter<DateTime>(validators, minimumValidator) ?? Kendo.Mvc.UI.DatePicker.defaultMinDate)
                    .Max(GetRangeValidationParameter<DateTime>(validators, maximumValidator) ?? Kendo.Mvc.UI.DatePicker.defaultMaxDate);
        }

        /// <summary>
        /// Creates a new <see cref="DatePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DatePickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual DatePickerBuilder DatePickerFor(Expression<Func<TModel, DateTime>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            return DatePicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value(metadata.Model as DateTime?)
                    .Min(GetRangeValidationParameter<DateTime>(validators, minimumValidator) ?? Kendo.Mvc.UI.DatePicker.defaultMinDate)
                    .Max(GetRangeValidationParameter<DateTime>(validators, maximumValidator) ?? Kendo.Mvc.UI.DatePicker.defaultMaxDate);
        }

        /// <summary>
        /// Creates a new <see cref="TimePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TimePickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual TimePickerBuilder TimePickerFor(Expression<Func<TModel, Nullable<DateTime>>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            return TimePicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value(metadata.Model as DateTime?)
                    .Min(GetRangeValidationParameter<DateTime>(validators, minimumValidator) ?? DateTime.Today)
                    .Max(GetRangeValidationParameter<DateTime>(validators, maximumValidator) ?? DateTime.Today);
        }

        /// <summary>
        /// Creates a new <see cref="TimePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TimePickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual TimePickerBuilder TimePickerFor(Expression<Func<TModel, DateTime>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            return TimePicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value(metadata.Model as DateTime?)
                    .Min(GetRangeValidationParameter<DateTime>(validators, minimumValidator) ?? DateTime.Today)
                    .Max(GetRangeValidationParameter<DateTime>(validators, maximumValidator) ?? DateTime.Today);
        }

        /// <summary>
        /// Creates a new <see cref="UI.TimePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TimePickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual TimePickerBuilder TimePickerFor(Expression<Func<TModel, Nullable<TimeSpan>>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            TimeSpan? minimum = GetRangeValidationParameter<TimeSpan>(validators, minimumValidator);
            TimeSpan? maximum = GetRangeValidationParameter<TimeSpan>(validators, maximumValidator);

            return TimePicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value(metadata.Model as TimeSpan?)
                    .Min(minimum.HasValue ? new DateTime(minimum.Value.Ticks) : DateTime.Today)
                    .Max(maximum.HasValue ? new DateTime(maximum.Value.Ticks) : DateTime.Today);
        }

        /// <summary>
        /// Creates a new <see cref="UI.TimePicker"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TimePickerFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual TimePickerBuilder TimePickerFor(Expression<Func<TModel, TimeSpan>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            TimeSpan? minimum = GetRangeValidationParameter<TimeSpan>(validators, minimumValidator);
            TimeSpan? maximum = GetRangeValidationParameter<TimeSpan>(validators, maximumValidator);

            return TimePicker()
                    .Name(GetName(expression))
                    .ModelMetadata(metadata)
                    .Format(ExtractEditFormat(metadata.EditFormatString))
                    .Value(metadata.Model as TimeSpan?)
                    .Min(minimum.HasValue ? new DateTime(minimum.Value.Ticks) : DateTime.Today)
                    .Max(maximum.HasValue ? new DateTime(maximum.Value.Ticks) : DateTime.Today);
        }

        /// <summary>
        /// Creates a new <see cref="DropDownList"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().DropDownListFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual DropDownListBuilder DropDownListFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return DropDownList().Name(GetName(expression))
                                 .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                                 .Value(GetValue(expression));
        }

        /// <summary>
        /// Creates a new <see cref="ComboBox"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().ComboBoxFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual ComboBoxBuilder ComboBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return ComboBox().Name(GetName(expression))
                             .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                             .Value(GetValue(expression));
        }

        /// <summary>
        /// Creates a new <see cref="AutoComplete"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().AutoCompleteFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual AutoCompleteBuilder AutoCompleteFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return AutoComplete().Name(GetName(expression))
                                 .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                                 .Value(GetValue(expression));
        }

        /// <summary>
        /// Creates a new <see cref="MultiSelect"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MultiSelectFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual MultiSelectBuilder MultiSelectFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return MultiSelect().Name(GetName(expression))
                                .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                                .Value(GetIEnumerableValues(expression));
        }

        /// <summary>
        /// Creates a new <see cref="UI.Slider{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().SliderFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual SliderBuilder<TValue> SliderFor<TValue>(Expression<Func<TModel, TValue>> expression)
            where TValue : struct, IComparable
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            TValue? minimum = GetRangeValidationParameter<TValue>(validators, minimumValidator);
            TValue? maximum = GetRangeValidationParameter<TValue>(validators, maximumValidator);

            var slider = Slider<TValue>()
                            .Name(GetName(expression))
                            .ModelMetadata(metadata)
                            .Value((Nullable<TValue>)metadata.Model);

            if (minimum.HasValue)
            {
                slider.Min(minimum.Value);
            }

            if (maximum.HasValue)
            {
                slider.Max(maximum.Value);
            }

            return slider;
        }

        /// <summary>
        /// Creates a new <see cref="SliderFor"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().SliderFor(m=>m.NullableProperty) %&gt;
        /// </code>
        /// </example>
        public virtual SliderBuilder<TValue> SliderFor<TValue>(Expression<Func<TModel, Nullable<TValue>>> expression)
            where TValue : struct, IComparable
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            TValue? minimum = GetRangeValidationParameter<TValue>(validators, minimumValidator);
            TValue? maximum = GetRangeValidationParameter<TValue>(validators, maximumValidator);

            var slider = Slider<TValue>()
                            .Name(GetName(expression))
                            .ModelMetadata(metadata)
                            .Value((Nullable<TValue>)metadata.Model);

            if (minimum.HasValue)
            {
                slider.Min(minimum.Value);
            }

            if (maximum.HasValue)
            {
                slider.Max(maximum.Value);
            }

            return slider;
        }

        /// <summary>
        /// Creates a new <see cref="SliderFor{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().SliderFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual SliderBuilder<double> SliderFor(Expression<Func<TModel, double>> expression)
        {
            return SliderFor<double>(expression);
        }

        /// <summary>
        /// Creates a new <see cref="SliderFor{T}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().SliderFor(m=>m.NullableProperty) %&gt;
        /// </code>
        /// </example>
        public virtual SliderBuilder<double> SliderFor(Expression<Func<TModel, Nullable<double>>> expression)
        {
            return SliderFor<double>(expression);
        }

        /// <summary>
        /// Creates a new <see cref="RangeSliderFor{TValue}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().RangeSliderFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual RangeSliderBuilder<TValue> RangeSliderFor<TValue>(Expression<Func<TModel, TValue[]>> expression)
            where TValue : struct, IComparable
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData);
            IEnumerable<ModelValidator> validators = metadata.GetValidators(HtmlHelper.ViewContext.Controller.ControllerContext);

            TValue? minimum = GetRangeValidationParameter<TValue>(validators, minimumValidator);
            TValue? maximum = GetRangeValidationParameter<TValue>(validators, maximumValidator);

            var rangeSlider = RangeSlider<TValue>()
                                .Name(GetName(expression))
                                .ModelMetadata(metadata)
                                .Values((TValue[])metadata.Model);

            if (minimum.HasValue)
            {
                rangeSlider.Min(minimum.Value);
            }

            if (maximum.HasValue)
            {
                rangeSlider.Max(maximum.Value);
            }

            return rangeSlider;
        }

        /// <summary>
        /// Creates a new <see cref="RangeSliderFor{TValue}"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().RangeSliderFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual RangeSliderBuilder<double> RangeSliderFor(Expression<Func<TModel, double[]>> expression)
        {
            return RangeSliderFor<double>(expression);
        }

        /// <summary>
        /// Creates a new <see cref="RecurrenceEditor"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().RecurrenceEditorFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual RecurrenceEditorBuilder RecurrenceEditorFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return RecurrenceEditor()
                    .Name(GetName(expression))
                    .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                    .Value(GetValue(expression));
        }

        /// <summary>
        /// Creates a new <see cref="TimezoneEditor"/>.
        /// </summary>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TimezoneEditorFor(m=>m.Property) %&gt;
        /// </code>
        /// </example>
        public virtual TimezoneEditorBuilder TimezoneEditorFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return TimezoneEditor()
                    .Name(GetName(expression))
                    .ModelMetadata(ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData))
                    .Value(GetValue(expression));
        }

        private string GetName(LambdaExpression expression)
        {
            return HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
        }

        private string GetValue<TValue>(Expression<Func<TModel, TValue>> expression) 
        {
            object model = ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData).Model;
            return model != null && model.GetType().IsPredefinedType() ? Convert.ToString(model) : null;
        }

        private IEnumerable GetIEnumerableValues<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return ModelMetadata.FromLambdaExpression(expression, HtmlHelper.ViewData).Model as IEnumerable;
        }

        private Nullable<TValue> GetRangeValidationParameter<TValue>(IEnumerable<ModelValidator> validators, string parameter) where TValue : struct
        {
            var rangeValidators = validators.OfType<RangeAttributeAdapter>().Cast<RangeAttributeAdapter>();

            object value = null;

            if (rangeValidators.Any())
            {
                var clientValidationsRules = rangeValidators.First()
                                                            .GetClientValidationRules()
                                                            .OfType<ModelClientValidationRangeRule>()
                                                            .Cast<ModelClientValidationRangeRule>();

                if (clientValidationsRules.Any() && clientValidationsRules.First().ValidationParameters.TryGetValue(parameter, out value))
                {
                    return (TValue)Convert.ChangeType(value, typeof(TValue));
                }
            }
            return null;
        }

        private string ExtractEditFormat(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return string.Empty;
            }
            
            return StringFormatExpression.Match(format).ToString();
        }
    }
}
