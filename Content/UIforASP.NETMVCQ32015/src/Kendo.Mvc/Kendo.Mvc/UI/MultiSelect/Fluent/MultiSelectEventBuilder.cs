namespace Kendo.Mvc.UI.Fluent
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The fluent API for subscribing to Kendo UI MultiSelect events.
    /// </summary>
    public class MultiSelectEventBuilder : EventBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiSelectEventBuilder"/> class.
        /// </summary>
        /// <param name="Events">The client events.</param>
        public MultiSelectEventBuilder(IDictionary<string, object> events)
            : base(events)
        {
        }

        /// <summary>
        /// Defines the inline handler of the Select client-side event
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag (Razor syntax).</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///            .Name("MultiSelect")
        ///            .Events(events => events.Select(
        ///                 @&lt;text&gt;
        ///                 function(e) {
        ///                     //event handling code
        ///                 }
        ///                 &lt;/text&gt;
        ///            ))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Select(Func<object, object> handler)
        {
            Handler("select", handler);

            return this;
        }

        /// <summary>
        ///  Defines the name of the JavaScript function that will handle the the Select client-side event.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the event.</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///             .Name("MultiSelect")
        ///             .Events(events => events.Select("select"))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Select(string handler)
        {
            Handler("select", handler);

            return this;
        }

        /// <summary>
        /// Defines the inline handler of the Change client-side event
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag (Razor syntax).</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///            .Name("MultiSelect")
        ///            .Events(events => events.Change(
        ///                 @&lt;text&gt;
        ///                 function(e) {
        ///                     //event handling code
        ///                 }
        ///                 &lt;/text&gt;
        ///            ))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Change(Func<object, object> handler)
        {
            Handler("change", handler);

            return this;
        }

        /// <summary>
        ///  Defines the name of the JavaScript function that will handle the the Change client-side event.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the event.</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///             .Name("MultiSelect")
        ///             .Events(events => events.Change("change"))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Change(string handler)
        {
            Handler("change", handler);

            return this;
        }

        /// <summary>
        /// Defines the inline handler of the DataBound client-side event
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag (Razor syntax).</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///            .Name("MultiSelect")
        ///            .Events(events => events.DataBound(
        ///                 @&lt;text&gt;
        ///                 function(e) {
        ///                     //event handling code
        ///                 }
        ///                 &lt;/text&gt;
        ///            ))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder DataBound(Func<object, object> handler)
        {
            Handler("dataBound", handler);

            return this;
        }

        /// <summary>
        /// Defines the name of the JavaScript function that will handle the the DataBound client-side event.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the event.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MultiSelect()
        ///             .Name("MultiSelect")
        ///             .Events(events => events.DataBound("dataBound"))
        /// %&gt;
        /// </code>
        /// </example>
        public MultiSelectEventBuilder DataBound(string handler)
        {
            Handler("dataBound", handler);

            return this;
        }

        /// <summary>
        /// Defines the inline handler of the Filtering client-side event
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag (Razor syntax).</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///            .Name("MultiSelect")
        ///            .Events(events => events.Filtering(
        ///                 @&lt;text&gt;
        ///                 function(e) {
        ///                     //event handling code
        ///                 }
        ///                 &lt;/text&gt;
        ///            ))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Filtering(Func<object, object> handler)
        {
            Handler("filtering", handler);

            return this;
        }

        /// <summary>
        /// Defines the name of the JavaScript function that will handle the the Filtering client-side event.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the event.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().MultiSelect()
        ///             .Name("MultiSelect")
        ///             .Events(events => events.Filtering("filtering"))
        /// %&gt;
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Filtering(string handler)
        {
            Handler("filtering", handler);

            return this;
        }

        /// <summary>
        ///  Defines the name of the JavaScript function that will handle the the Open client-side event.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the event.</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///             .Name("MultiSelect")
        ///             .Events(events => events.Open("open"))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Open(string handler)
        {
            Handler("open", handler);

            return this;
        }

        /// <summary>
        /// Defines the inline handler of the Open client-side event
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag (Razor syntax).</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///            .Name("MultiSelect")
        ///            .Events(events => events.Open(
        ///                 @&lt;text&gt;
        ///                 function(e) {
        ///                     //event handling code
        ///                 }
        ///                 &lt;/text&gt;
        ///            ))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Open(Func<object, object> handler)
        {
            Handler("open", handler);

            return this;
        }

        /// <summary>
        /// Defines the inline handler of the Close client-side event
        /// </summary>
        /// <param name="handler">The handler code wrapped in a text tag (Razor syntax).</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///            .Name("MultiSelect")
        ///            .Events(events => events.Close(
        ///                 @&lt;text&gt;
        ///                 function(e) {
        ///                     //event handling code
        ///                 }
        ///                 &lt;/text&gt;
        ///            ))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Close(Func<object, object> handler)
        {
            Handler("close", handler);

            return this;
        }

        /// <summary>
        ///  Defines the name of the JavaScript function that will handle the the Close client-side event.
        /// </summary>
        /// <param name="handler">The name of the JavaScript function that will handle the event.</param>
        /// <example>
        /// <code lang="CS">
        ///  @(Html.Kendo().MultiSelect()
        ///             .Name("MultiSelect")
        ///             .Events(events => events.Close("close"))
        /// )
        /// </code>
        /// </example>
        public MultiSelectEventBuilder Close(string handler)
        {
            Handler("close", handler);

            return this;
        }
    }
}
