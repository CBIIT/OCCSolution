namespace Kendo.Mvc.UI
{
    using Kendo.Mvc.Infrastructure;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class ListBase : WidgetBase
    {
        public ListBase(ViewContext viewContext, IJavaScriptInitializer initializer, ViewDataDictionary viewData, IUrlGenerator urlGenerator)
            : base(viewContext, initializer, viewData)
        {
            Animation = new PopupAnimation();

            DataSource = new DataSource();

            PopupSettings = new UI.PopupSettings();

            VirtualSettings = new UI.VirtualSettings();

            UrlGenerator = urlGenerator;
        }

        public PopupAnimation Animation
        {
            get;
            private set;
        }

        public DataSource DataSource
        {
            get;
            private set;
        }

        public string DataTextField
        {
            get;
            set;
        }

        public int? Delay
        {
            get;
            set;
        }

        public bool? Enabled
        {
            get;
            set;
        }

        public string Filter
        {
            get;
            set;
        }

        public string FixedGroupTemplate
        {
            get;
            set;
        }

        public string FixedGroupTemplateId
        {
            get;
            set;
        }

        public string GroupTemplate
        {
            get;
            set;
        }

        public string GroupTemplateId
        {
            get;
            set;
        }

        public bool? IgnoreCase
        {
            get;
            set;
        }

        public int? Height
        {
            get;
            set;
        }

        public string HeaderTemplate
        {
            get;
            set;
        }

        public string HeaderTemplateId
        {
            get;
            set;
        }

        public int? MinLength
        {
            get;
            set;
        }

        public PopupSettings PopupSettings
        {
            get;
            set;
        }

        public bool? ValuePrimitive
        {
            get;
            set;
        }

        public VirtualSettings VirtualSettings
        { 
            get; 
            set; 
        }
       
        public IUrlGenerator UrlGenerator
        {
            get;
            set;
        }

        protected virtual IDictionary<string, object> SeriailzeBaseOptions()
        {
            var options = new Dictionary<string, object>(Events);
            
            if (!string.IsNullOrEmpty(DataSource.Transport.Read.Url) || DataSource.Type == DataSourceType.Custom)
            {
                options["dataSource"] = DataSource.ToJson();
            }
            else if (DataSource.Data != null)
            {
                options["dataSource"] = DataSource.Data;
            }

            var animation = Animation.ToJson();

            if (animation.Keys.Any())
            {
                options["animation"] = animation["animation"];
            }

            if (!string.IsNullOrEmpty(DataTextField))
            {
                options["dataTextField"] = DataTextField;
            }

            if (Delay != null)
            {
                options["delay"] = Delay;
            }

            if (!string.IsNullOrEmpty(Filter))
            {
                options["filter"] = Filter;
            }

            if (IgnoreCase != null)
            {
                options["ignoreCase"] = IgnoreCase;
            }

            if (Height != null)
            {
                options["height"] = Height;
            }

            var idPrefix = "#";
            if (IsInClientTemplate)
            {
                idPrefix = "\\" + idPrefix;
            }

            if (!string.IsNullOrEmpty(FixedGroupTemplateId))
            {
                options["fixedGroupTemplateId"] = new ClientHandlerDescriptor { HandlerName = string.Format("jQuery('{0}{1}').html()", idPrefix, FixedGroupTemplateId) };
            }
            else if (!string.IsNullOrEmpty(FixedGroupTemplate))
            {
                options["fixedGroupTemplate"] = FixedGroupTemplate;
            }

            if (!string.IsNullOrEmpty(GroupTemplateId))
            {
                options["groupTemplateId"] = new ClientHandlerDescriptor { HandlerName = string.Format("jQuery('{0}{1}').html()", idPrefix, GroupTemplateId) };
            }
            else if (!string.IsNullOrEmpty(GroupTemplate))
            {
                options["groupTemplate"] = GroupTemplate;
            }

            if (!string.IsNullOrEmpty(HeaderTemplateId))
            {
                options["headerTemplate"] = new ClientHandlerDescriptor { HandlerName = string.Format("jQuery('{0}{1}').html()", idPrefix, HeaderTemplateId) };
            }
            else if (!string.IsNullOrEmpty(HeaderTemplate))
            {
                options["headerTemplate"] = HeaderTemplate;
            }

            if (MinLength != null)
            {
                options["minLength"] = MinLength;
            }

            var popupSettings = PopupSettings.SeriailzeOptions();

            if (popupSettings.Count > 0) {
                options["popup"] = popupSettings;
            }

            if (ValuePrimitive != null)
            {
                options["valuePrimitive"] = ValuePrimitive;
            }

            if (VirtualSettings.Enable)
            {
                if (VirtualSettings.ValueMapper != null)
                {
                    options["virtual"] = VirtualSettings.SeriailzeOptions();
                }
                else
                {
                    options["virtual"] = VirtualSettings.Enable;
                }
            }

            return options;
        }
    }
}
