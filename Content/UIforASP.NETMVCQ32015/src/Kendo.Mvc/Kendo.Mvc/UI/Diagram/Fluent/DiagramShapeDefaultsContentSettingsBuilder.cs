namespace Kendo.Mvc.UI.Fluent
{
    using System.Collections.Generic;
    using System.Collections;
    using System;
    using Kendo.Mvc.Extensions;

    /// <summary>
    /// Defines the fluent API for configuring the DiagramShapeDefaultsContentSettings settings.
    /// </summary>
    public class DiagramShapeDefaultsContentSettingsBuilder<TShapeModel, TConnectionModel> : IHideObjectMembers
        where TShapeModel : class
        where TConnectionModel : class
    {
        private readonly DiagramShapeDefaultsContentSettings container;

        public DiagramShapeDefaultsContentSettingsBuilder(DiagramShapeDefaultsContentSettings settings)
        {
            container = settings;
        }

        //>> Fields
        
        /// <summary>
        /// The alignment of the text inside the shape.
        /// </summary>
        /// <param name="value">The value that configures the align.</param>
        public DiagramShapeDefaultsContentSettingsBuilder<TShapeModel,TConnectionModel> Align(string value)
        {
            container.Align = value;

            return this;
        }
        
        /// <summary>
        /// The color of the shape content text.
        /// </summary>
        /// <param name="value">The value that configures the color.</param>
        public DiagramShapeDefaultsContentSettingsBuilder<TShapeModel,TConnectionModel> Color(string value)
        {
            container.Color = value;

            return this;
        }
        
        /// <summary>
        /// The font family of the shape content text.
        /// </summary>
        /// <param name="value">The value that configures the fontfamily.</param>
        public DiagramShapeDefaultsContentSettingsBuilder<TShapeModel,TConnectionModel> FontFamily(string value)
        {
            container.FontFamily = value;

            return this;
        }
        
        /// <summary>
        /// The font size of the shape content text.
        /// </summary>
        /// <param name="value">The value that configures the fontsize.</param>
        public DiagramShapeDefaultsContentSettingsBuilder<TShapeModel,TConnectionModel> FontSize(double value)
        {
            container.FontSize = value;

            return this;
        }
        
        /// <summary>
        /// The template which renders the labels.The fields which can be used in the template are:
        /// </summary>
        /// <param name="value">The value that configures the template.</param>
        public DiagramShapeDefaultsContentSettingsBuilder<TShapeModel,TConnectionModel> Template(string value)
        {
            container.Template = value;

            return this;
        }

        /// <summary>
        /// The template which renders the labels.The fields which can be used in the template are:
        /// </summary>
        /// <param name="value">The value that configures the template.</param>
        public DiagramShapeDefaultsContentSettingsBuilder<TShapeModel,TConnectionModel> TemplateId(string value)
        {
            container.TemplateId = value;

            return this;
        }
        
        /// <summary>
        /// The text displayed in the shape.
        /// </summary>
        /// <param name="value">The value that configures the text.</param>
        public DiagramShapeDefaultsContentSettingsBuilder<TShapeModel,TConnectionModel> Text(string value)
        {
            container.Text = value;

            return this;
        }
        
        //<< Fields
    }
}

