namespace Kendo.Mvc.UI.Fluent
{
    using System.Collections.Generic;
    using System.Collections;
    using System;
    using Kendo.Mvc.Extensions;

    /// <summary>
    /// Defines the fluent API for configuring the DiagramShapeRotationSettings settings.
    /// </summary>
    public class DiagramShapeRotationSettingsBuilder<TShapeModel, TConnectionModel> : IHideObjectMembers
        where TShapeModel : class
        where TConnectionModel : class
    {
        private readonly DiagramShapeRotationSettings container;

        public DiagramShapeRotationSettingsBuilder(DiagramShapeRotationSettings settings)
        {
            container = settings;
        }

        //>> Fields
        
        /// <summary>
        /// The rotation angle.
        /// </summary>
        /// <param name="value">The value that configures the angle.</param>
        public DiagramShapeRotationSettingsBuilder<TShapeModel,TConnectionModel> Angle(double value)
        {
            container.Angle = value;

            return this;
        }
        
        //<< Fields
    }
}

