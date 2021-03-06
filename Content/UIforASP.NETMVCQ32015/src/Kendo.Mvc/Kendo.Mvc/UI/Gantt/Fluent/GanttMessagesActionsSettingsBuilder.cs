namespace Kendo.Mvc.UI.Fluent
{
    using System.Collections.Generic;
    using System.Collections;
    using System;
    using Kendo.Mvc.Extensions;

    /// <summary>
    /// Defines the fluent API for configuring the GanttMessagesActionsSettings settings.
    /// </summary>
    public class GanttMessagesActionsSettingsBuilder: IHideObjectMembers
    {
        private readonly GanttMessagesActionsSettings container;

        public GanttMessagesActionsSettingsBuilder(GanttMessagesActionsSettings settings)
        {
            container = settings;
        }

        //>> Fields
        
        /// <summary>
        /// The text similar to "Add child" displayed as Gantt "add child" buttons.
        /// </summary>
        /// <param name="value">The value that configures the addchild.</param>
        public GanttMessagesActionsSettingsBuilder AddChild(string value)
        {
            container.AddChild = value;

            return this;
        }
        
        /// <summary>
        /// The text similar to "Append" displayed as Gantt "append" buttons.
        /// </summary>
        /// <param name="value">The value that configures the append.</param>
        public GanttMessagesActionsSettingsBuilder Append(string value)
        {
            container.Append = value;

            return this;
        }
        
        /// <summary>
        /// The text similar to "Add below" displayed as Gantt "add below" buttons.
        /// </summary>
        /// <param name="value">The value that configures the insertafter.</param>
        public GanttMessagesActionsSettingsBuilder InsertAfter(string value)
        {
            container.InsertAfter = value;

            return this;
        }
        
        /// <summary>
        /// The text similar to "Add above" displayed as Gantt "add above" buttons.
        /// </summary>
        /// <param name="value">The value that configures the insertbefore.</param>
        public GanttMessagesActionsSettingsBuilder InsertBefore(string value)
        {
            container.InsertBefore = value;

            return this;
        }
        
        /// <summary>
        /// The text of "Export to PDF" button of the Gantt toolbar.
        /// </summary>
        /// <param name="value">The value that configures the pdf.</param>
        public GanttMessagesActionsSettingsBuilder Pdf(string value)
        {
            container.Pdf = value;

            return this;
        }
        
        //<< Fields
    }
}

