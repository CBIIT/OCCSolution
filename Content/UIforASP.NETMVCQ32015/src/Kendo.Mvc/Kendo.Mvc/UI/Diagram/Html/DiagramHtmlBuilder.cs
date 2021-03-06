namespace Kendo.Mvc.UI
{
    using System;
    using System.Collections.Generic;
    using Kendo.Mvc.Extensions;

    public class DiagramHtmlBuilder<TShapeModel, TConnectionModel>
        where TShapeModel : class
        where TConnectionModel : class
    {
        private readonly Diagram<TShapeModel, TConnectionModel> component;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramHtmlBuilder" /> class.
        /// </summary>
        /// <param name="component">The Diagram component.</param>
        public DiagramHtmlBuilder(Diagram<TShapeModel, TConnectionModel> component)
        {
            this.component = component;
        }

        /// <summary>
        /// Builds the Diagram markup.
        /// </summary>
        /// <returns></returns>
        public IHtmlNode Build()
        {
            var html = CreateElement();
            html.Attribute("data-role", "diagram")
                .Attributes(component.HtmlAttributes)
                .Attribute("id", component.Id);

            return html;
        }

        protected virtual IHtmlNode CreateElement()
        {
            return new HtmlElement("div");
        }

        
    }
}

