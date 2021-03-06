namespace Kendo.Mvc.UI
{

    using System;
    using System.IO;
    using System.Linq;
    using System.Web.UI;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Collections.Generic;

    using Extensions;
    using Infrastructure;
    using Kendo.Mvc.Resources;

    public class Window : WidgetBase, IContentContainer, IAsyncContentContainer
    {
        private readonly IList<IWindowButton> defaultButtons = new List<IWindowButton> { new HeaderButton { Name = "Close", CssClass = UIPrimitives.Icons.Close } };

        private string loadContentFromUrl;

        public Window(ViewContext viewContext, IJavaScriptInitializer initializer)
            : base(viewContext, initializer)
        {
            Template = new HtmlTemplate();

            ResizingSettings = new WindowResizingSettings();
            PositionSettings = new WindowPositionSettings();

            Actions = new WindowButtons();
            defaultButtons.Each(button => Actions.Container.Add(button));

            Animation = new PopupAnimation();

            ContentHtmlAttributes = new RouteValueDictionary();

            Scrollable = true;

            Visible = true;

            AutoFocus = true;
        }

        public HtmlTemplate Template
        {
            get;
            private set;
        }

        public PopupAnimation Animation
        {
            get;
            set;
        }

        public string IconUrl
        {
            get;
            set;
        }

        public string IconAlternativeText
        {
            get;
            set;
        }

        public object Title
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public WindowPositionSettings PositionSettings
        {
            get;
            private set;
        }

        public bool Visible
        {
            get;
            set;
        }

        public bool Scrollable
        {
            get;
            set;
        }

        public bool Modal
        {
            get;
            set;
        }

        public bool Iframe
        {
            get;
            set;
        }

        public bool Draggable
        {
            get;
            set;
        }

        public bool Pinned
        {
            get;
            set;
        }

        public bool AutoFocus
        {
            get;
            set;
        }

        public WindowResizingSettings ResizingSettings
        {
            get;
            private set;
        }

        public WindowButtons Actions
        {
            get;
            private set;
        }

        public string Html
        {
            get
            {
                return Template.Html;
            }
            set
            {
                Template.Html = value;
            }
        }

        public string AppendTo
        {
            get;
            set;
        }

        public Action Content
        {
            get
            {
                return Template.Content;
            }
            set
            {
                Template.Content = value;

            }
        }

        public string ContentUrl
        {
            get
            {
                return loadContentFromUrl;
            }
            set
            {

                loadContentFromUrl = value;
                ContentHtmlAttributes.Clear();
                Content = null;
            }
        }

        public IDictionary<string, object> ContentHtmlAttributes
        {
            get;
            private set;
        }

        public Dictionary<string, object> Serialize()
        {
            var options = new Dictionary<string, object>(Events);

            var animation = Animation.ToJson();

            if (animation.Any())
            {
                if (animation["animation"] is bool)
                {
                    options["animation"] = false;
                }
                else
                {
                    options["animation"] = animation["animation"];
                }
            }

            // properties
            options.Add("modal", Modal);
            options.Add("iframe", Iframe);
            options.Add("draggable", Draggable);
            options.Add("scrollable", Scrollable);
            options.Add("pinned", Pinned);
            if (AutoFocus == false)
            {
                options.Add("autoFocus", AutoFocus);
            }
            options.Add("title", Title);
            if (!string.IsNullOrEmpty(AppendTo))
            {
                options.Add("appendTo", AppendTo);
            }
            options.Add("resizable", ResizingSettings.Enabled);
            options.Add("content", ContentUrl);
            if (Width != 0)
            {
                options.Add("width", Width);
            }
            if (Height != 0)
            {
                options.Add("height", Height);
            }
            options.Add("actions", Actions.Container.Select(item => item.Name));

            if (ResizingSettings.Enabled)
            {
                if (ResizingSettings.MinHeight != int.MinValue)
                {
                    options.Add("minHeight", ResizingSettings.MinHeight);
                }

                if (ResizingSettings.MinWidth != int.MinValue)
                {
                    options.Add("minWidth", ResizingSettings.MinWidth);
                }

                if (ResizingSettings.MaxHeight != int.MinValue)
                {
                    options.Add("maxHeight", ResizingSettings.MaxHeight);
                }

                if (ResizingSettings.MaxWidth != int.MinValue)
                {
                    options.Add("maxWidth", ResizingSettings.MaxWidth);
                }
            }

            if (PositionSettings.Left != int.MinValue || PositionSettings.Top != int.MinValue)
            {
                var topLeft = new Dictionary<string, int>();

                if (PositionSettings.Top != int.MinValue)
                {
                    topLeft.Add("top", PositionSettings.Top);
                }

                if (PositionSettings.Left != int.MinValue)
                {
                    topLeft.Add("left", PositionSettings.Left);
                }

                options.Add("position", topLeft);
            }

            return options;
        }

        public override void WriteInitializationScript(TextWriter writer)
        {
            writer.Write(Initializer.Initialize(Selector, "Window", Serialize()));

            base.WriteInitializationScript(writer);
        }

        protected override void WriteHtml(HtmlTextWriter writer)
        {

            var builder = new WindowHtmlBuilder(this);

            builder.WindowTag().WriteTo(writer);

            base.WriteHtml(writer);
        }

        public override void VerifySettings()
        {
            base.VerifySettings();

            if (ResizingSettings.MinWidth != int.MinValue &&
                ResizingSettings.MaxWidth != int.MinValue &&
                ResizingSettings.MinWidth > ResizingSettings.MaxWidth)
            {
                throw new ArgumentException(Exceptions.MinPropertyMustBeLessThenMaxProperty.FormatWith("MinWidth", "MaxWidth"));
            }

            if (ResizingSettings.MinHeight != int.MinValue &&
                ResizingSettings.MaxHeight != int.MinValue &&
                ResizingSettings.MinHeight > ResizingSettings.MaxHeight)
            {
                throw new ArgumentException(Exceptions.MinPropertyMustBeLessThenMaxProperty.FormatWith("MinHeight", "MaxHeight"));
            }
        }
    }
}
