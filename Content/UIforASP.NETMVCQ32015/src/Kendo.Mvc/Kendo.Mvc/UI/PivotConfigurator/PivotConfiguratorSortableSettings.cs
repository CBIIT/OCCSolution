namespace Kendo.Mvc.UI
{
    using Kendo.Mvc.Resources;
    using System.Collections.Generic;

    public class PivotConfiguratorSortableSettings : JsonObject
    {
        public PivotConfiguratorSortableSettings()
        {
            AllowUnsort = true;
        }

        public bool Enabled
        {
            get;
            set;
        }

        public bool AllowUnsort
        {
            get;
            set;
        }

        protected override void Serialize(System.Collections.Generic.IDictionary<string, object> json)
        {
            if (!AllowUnsort)
            {
                json["allowUnsort"] = AllowUnsort;
            }
        }
    }
}
