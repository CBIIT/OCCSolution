namespace Kendo.Mvc.UI
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Extensions;
    using Kendo.Mvc.Infrastructure;
    using Kendo.Mvc.Resources;
    using System.Reflection;
    using System.Text.RegularExpressions;
    //TODO: Implement GridBeginEditEvent option
    //public enum GridBeginEditEvent
    //{
    //    Auto,
    //    Click,
    //    DoubleClick
    //}

    public interface IGridEditingSettings
    {
        bool Enabled
        {
            get;
        }
    }

    public class GridEditableSettings<T> : JsonObject, IGridEditingSettings
        where T : class
    {
        private readonly IGrid grid;

        public GridEditableSettings(IGrid grid)
        {
            this.grid = grid;

            DisplayDeleteConfirmation = true;
            //TODO: Implement edit form attributes
            //  FormHtmlAttributes = new RouteValueDictionary();
            //TODO: Implement GridBeginEditEvent option
            //BeginEdit = GridBeginEditEvent.Auto;            

            DefaultDataItem = CreateDefaultItem;
            Confirmation = Messages.Grid_Confirmation;
            ConfirmDelete = Messages.Grid_ConfirmDelete;
            CancelDelete = Messages.Grid_CancelDelete;
            CreateAt = GridInsertRowPosition.Top;
        }

        //TODO: Implement GridBeginEditEvent option
        //public GridBeginEditEvent BeginEdit 
        //{ 
        //    get; 
        //    set; 
        //}

        public Window PopUp
        {
            get;
            set;
        }

        public string Confirmation
        {
            get;
            set;
        }

        public ClientHandlerDescriptor ConfirmationHandler
        {
            get;
            set;
        }

        public string ConfirmDelete
        {
            get;
            set;
        }

        public string CancelDelete
        {
            get;
            set;
        }

        public GridEditMode Mode
        {
            get;
            set;
        }

        public bool Enabled
        {
            get;
            set;
        }

        public bool DisplayDeleteConfirmation
        {
            get;
            set;
        }

        public Func<T> DefaultDataItem
        {
            get;
            set;
        }

        public string TemplateName
        {
            get;
            set;
        }

        public object AdditionalViewData
        {
            get;
            set;
        }

        public GridInsertRowPosition CreateAt
        {
            get;
            set;
        }
        //TODO: Implement edit form attributes
        ///// <summary>
        ///// Gets the HTML attributes of the form rendered during editing
        ///// </summary>
        ///// <value>The HTML attributes.</value>
        //public IDictionary<string, object> FormHtmlAttributes
        //{
        //    get; 
        //    private set; 
        //}        

        //private object SerializeDefaultDataItem()
        //{
        //    T dataItem = DefaultDataItem();
        //    if (!typeof(T).IsDataRow())
        //        return dataItem;

        //    if (typeof(T) == typeof(DataRow))
        //    {
        //        return (dataItem as DataRow).SerializeRow();
        //    }

        //    return (dataItem as DataRowView).SerializeRow();
        //}

        private T CreateDefaultItem()
        {
            if (typeof(T) == typeof(DataRowView))
            {
                return new DataTable().DefaultView.AddNew() as T;
            }

            if (typeof(T) == typeof(DataRow))
            {
                return new DataTable().NewRow() as T;
            }

            var instance = Activator.CreateInstance<T>();

            if (grid.DataSource.Schema.Model != null &&
                grid.DataSource.Schema.Model.Fields.Any())
            {
                grid.DataSource.Schema.Model.Fields.Each(f =>
                {
                    var property = typeof(T).GetProperty(f.Member, BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                    if (property != null && property.CanWrite)
                    {
                        if (f.DefaultValue == null || f.DefaultValue.GetType() != typeof(ClientHandlerDescriptor))
                        {
                            property.SetValue(instance, f.DefaultValue, null);
                        }
                    }
                });
            }

            return instance;
        }

        private IDictionary<string, object> SerializePopUp()
        {
            PopUp.Title = PopUp.Title ?? Messages.Grid_Edit;

            return PopUp.Serialize();
        }

        protected override void Serialize(IDictionary<string, object> json)
        {
            var editorHtml = grid.EditorHtml;

            if (editorHtml != null && IsClientBinding)
            {
                if (grid.IsInClientTemplate)
                {
                    editorHtml = Regex.Replace(editorHtml, "(&amp;)#([0-9]+;)", "$1\\\\#$2");
                }

                editorHtml = editorHtml.Trim()
                                .Replace("\r\n", string.Empty)
                                .Replace("</script>", "<\\/script>")
                                .Replace("jQuery(\"#", "jQuery(\"\\\\#")
                                .Replace("#", "\\#");
            }

            if (DisplayDeleteConfirmation)
            {
                if (ConfirmationHandler != null)
                {
                    json["confirmation"] = ConfirmationHandler;
                }
                else
                {
                    json["confirmation"] = Confirmation;
                }
            }

            FluentDictionary.For(json)
                .Add("confirmDelete", ConfirmDelete)
                .Add("cancelDelete", CancelDelete)
                .Add("mode", Mode.ToString().ToLowerInvariant())
                .Add("template", editorHtml, () => Mode != GridEditMode.InLine)
                //TODO: Implement GridBeginEditEvent option                
                //.Add("beginEdit", BeginEdit == GridBeginEditEvent.Click ? "click" : "dblclick", () => BeginEdit != GridBeginEditEvent.Auto)                               
                .Add("createAt", CreateAt.ToString().ToLower(), () => CreateAt != GridInsertRowPosition.Top)
                .Add("window", SerializePopUp(), () => Mode == GridEditMode.PopUp && IsClientBinding)
                .Add("create", IsClientBinding)
                .Add("update", IsClientBinding)
                .Add("destroy", IsClientBinding);
        }

        private bool IsClientBinding
        {
            get
            {
                return grid.DataSource.Type == DataSourceType.Ajax || grid.DataSource.Type == DataSourceType.WebApi || grid.DataSource.Type == DataSourceType.Custom;
            }
        }
    }

    public enum GridInsertRowPosition
    {
        Top,
        Bottom
    }
}
