using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System.Web.Routing;
using System;

namespace Kendo.Mvc.UI.Fluent
{
    /// <summary>
    /// Defines the fluent API for configuring the ImageBrowser.
    /// </summary>
    public class EditorImageBrowserSettingsBuilder : IHideObjectMembers
    {
        private readonly EditorImageBrowserSettings settings;
        private readonly ViewContext viewContext;
        private readonly IUrlGenerator urlGenerator;

        public EditorImageBrowserSettingsBuilder(EditorImageBrowserSettings settings, ViewContext viewContext, IUrlGenerator urlGenerator)
        {
            this.viewContext = viewContext;
            this.urlGenerator = urlGenerator;
            this.settings = settings;
        }

        public EditorImageBrowserSettingsBuilder Read(string actionName, string controllerName)
        {            
            return Read(actionName, controllerName, (object)null);
        }

        public EditorImageBrowserSettingsBuilder Read(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            settings.Read.Action(actionName, controllerName, routeValues);

            SetUrl(settings.Read);

            return this;
        }

        public EditorImageBrowserSettingsBuilder Read(string actionName, string controllerName, object routeValues)
        {
            settings.Read.Action(actionName, controllerName, routeValues);

            SetUrl(settings.Read);

            return this;
        }

        public EditorImageBrowserSettingsBuilder Read(Action<EditorImageBrowserOperationBuilder> configurator)
        {
            configurator(new EditorImageBrowserOperationBuilder(settings.Read, viewContext, urlGenerator));

            return this;
        }

        private void SetUrl(INavigatable operation)
        {
            operation.Url = operation.GenerateUrl(viewContext, urlGenerator);
        }

        public EditorImageBrowserSettingsBuilder Thumbnail(string actionName, string controllerName)
        {
            return Thumbnail(actionName, controllerName, (object)null);
        }

        public EditorImageBrowserSettingsBuilder Thumbnail(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            settings.Thumbnail.Action(actionName, controllerName, routeValues);

            SetUrl(settings.Thumbnail);

            return this;
        }

        public EditorImageBrowserSettingsBuilder Thumbnail(string actionName, string controllerName, object routeValues)
        {
            settings.Thumbnail.Action(actionName, controllerName, routeValues);

            SetUrl(settings.Thumbnail);

            return this;
        }

        public EditorImageBrowserSettingsBuilder Thumbnail(Action<EditorImageBrowserOperationBuilder> configurator)
        {
            configurator(new EditorImageBrowserOperationBuilder(settings.Thumbnail, viewContext, urlGenerator));

            return this;
        }

        public EditorImageBrowserSettingsBuilder Image(string actionName, string controllerName)
        {
            return Image(actionName, controllerName, (object)null);
        }

        public EditorImageBrowserSettingsBuilder Image(string url)
        {
            settings.Image.Url = urlGenerator.Generate(viewContext.RequestContext, url);
            return this;
        }

        public EditorImageBrowserSettingsBuilder Image(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            settings.Image.Action(actionName, controllerName, routeValues);
            SetUrl(settings.Image);
            return this;
        }

        public EditorImageBrowserSettingsBuilder Image(string actionName, string controllerName, object routeValues)
        {
            settings.Image.Action(actionName, controllerName, routeValues);
            SetUrl(settings.Image);
            return this;
        }

        public EditorImageBrowserSettingsBuilder Image(Action<EditorImageBrowserOperationBuilder> configurator)
        {
            configurator(new EditorImageBrowserOperationBuilder(settings.Image, viewContext, urlGenerator));

            return this;
        }

        public EditorImageBrowserSettingsBuilder Upload(string actionName, string controllerName)
        {
            return Upload(actionName, controllerName, (object)null);
        }

        public EditorImageBrowserSettingsBuilder Upload(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            settings.Upload.Action(actionName, controllerName, routeValues);

            SetUrl(settings.Upload);

            return this;
        }

        public EditorImageBrowserSettingsBuilder Upload(string actionName, string controllerName, object routeValues)
        {
            settings.Upload.Action(actionName, controllerName, routeValues);
            SetUrl(settings.Upload);
            return this;
        }

        public EditorImageBrowserSettingsBuilder Upload(Action<EditorImageBrowserOperationBuilder> configurator)
        {
            configurator(new EditorImageBrowserOperationBuilder(settings.Upload, viewContext, urlGenerator));

            return this;
        }

        public EditorImageBrowserSettingsBuilder Destroy(string actionName, string controllerName)
        {
            return Destroy(actionName, controllerName, (object)null);
        }

        public EditorImageBrowserSettingsBuilder Destroy(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            settings.Destroy.Action(actionName, controllerName, routeValues);
            SetUrl(settings.Destroy);
            return this;
        }

        public EditorImageBrowserSettingsBuilder Destroy(string actionName, string controllerName, object routeValues)
        {
            settings.Destroy.Action(actionName, controllerName, routeValues);
            SetUrl(settings.Destroy);
            return this;
        }

        public EditorImageBrowserSettingsBuilder Destroy(Action<EditorImageBrowserOperationBuilder> configurator)
        {
            configurator(new EditorImageBrowserOperationBuilder(settings.Destroy, viewContext, urlGenerator));

            return this;
        }

        public EditorImageBrowserSettingsBuilder Create(string actionName, string controllerName)
        {
            return Create(actionName, controllerName, (object)null);
        }

        public EditorImageBrowserSettingsBuilder Create(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            settings.Create.Action(actionName, controllerName, routeValues);
            SetUrl(settings.Create);
            return this;
        }

        public EditorImageBrowserSettingsBuilder Create(string actionName, string controllerName, object routeValues)
        {
            settings.Create.Action(actionName, controllerName, routeValues);
            SetUrl(settings.Create);
            return this;
        }

        public EditorImageBrowserSettingsBuilder Create(Action<EditorImageBrowserOperationBuilder> configurator)
        {
            configurator(new EditorImageBrowserOperationBuilder(settings.Create, viewContext, urlGenerator));

            return this;
        }

        public EditorImageBrowserSettingsBuilder FileTypes(string value)
        {
            settings.FileTypes = value;

            return this;
        }
    }
}
