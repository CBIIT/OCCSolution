namespace Kendo.Mvc.UI.Fluent
{
    using System.Collections.Generic;
    using System.Collections;
    using System;
    using Kendo.Mvc.Extensions;

    /// <summary>
    /// Defines the fluent API for configuring the DiagramConnectionFromSettings settings.
    /// </summary>
    public class DiagramConnectionFromSettingsBuilder<TShapeModel, TConnectionModel> : IHideObjectMembers
        where TShapeModel : class
        where TConnectionModel : class
    {
        private readonly DiagramConnectionFromSettings container;

        public DiagramConnectionFromSettingsBuilder(DiagramConnectionFromSettings settings)
        {
            container = settings;
        }

        //>> Fields
        
        /// <summary>
        /// Defines the x-coordinate of the connection source.
        /// </summary>
        /// <param name="value">The value that configures the x.</param>
        public DiagramConnectionFromSettingsBuilder<TShapeModel,TConnectionModel> X(double value)
        {
            container.X = value;

            return this;
        }
        
        /// <summary>
        /// Defines the y-coordinate of the connection source.
        /// </summary>
        /// <param name="value">The value that configures the y.</param>
        public DiagramConnectionFromSettingsBuilder<TShapeModel,TConnectionModel> Y(double value)
        {
            container.Y = value;

            return this;
        }


        /// <summary>
        /// Defines the source shape Id.
        /// </summary>
        /// <param name="value">The value that configures the source shape id.</param>
        public DiagramConnectionFromSettingsBuilder<TShapeModel, TConnectionModel> Id(object value)
        {
            container.Id = value;

            return this;
        }

        /// <summary>
        /// Defines the name of the source shape connector.
        /// </summary>
        /// <param name="value">The value that configures the source shape connector name.</param>
        public DiagramConnectionFromSettingsBuilder<TShapeModel, TConnectionModel> Connector(string value)
        {
            container.Connector = value;

            return this;
        }
        
        //<< Fields
    }
}

