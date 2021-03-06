namespace Kendo.Mvc.UI.Fluent
{
    using System;
    using System.Collections.Generic;
    using Kendo.Mvc.Infrastructure;

    public class EditorToolFactory : IHideObjectMembers
    {
        private readonly EditorToolGroup group;

        public EditorToolFactory(EditorToolGroup group)
        {
            this.group = group;
        }

        public EditorToolFactory CustomTemplate(Action<EditorCustomTemplateToolBuilder> configurator)
        {
            var tool = new EditorCustomTemplateTool();
            configurator(new EditorCustomTemplateToolBuilder(tool));
            group.Tools.Add(tool);
            
            return this;
        }

        public EditorToolFactory CustomButton(Action<EditorCustomButtonToolBuilder> configurator)
        {
            var tool = new EditorCustomButtonTool();
            configurator(new EditorCustomButtonToolBuilder(tool));
            group.Tools.Add(tool);

            return this;
        }

        public EditorToolFactory Clear()
        {
            group.Tools.Clear();

            return this;
        }

        public EditorToolFactory Bold()
        {
            return Button("bold");
        }

        public EditorToolFactory Italic()
        {
            return Button("italic");
        }

        public EditorToolFactory Underline()
        {
            return Button("underline");
        }

        public EditorToolFactory Strikethrough()
        {
            return Button("strikethrough");
        }

        public EditorToolFactory JustifyLeft()
        {
            return Button("justifyLeft");
        }

        public EditorToolFactory JustifyRight()
        {
            return Button("justifyRight");
        }

        public EditorToolFactory JustifyCenter()
        {
            return Button("justifyCenter");
        }

        public EditorToolFactory JustifyFull()
        {
            return Button("justifyFull");
        }

        public EditorToolFactory InsertUnorderedList()
        {
            return Button("insertUnorderedList");
        }

        public EditorToolFactory Indent()
        {
            return Button("indent");
        }

        public EditorToolFactory Pdf()
        {
            return Button("pdf");
        }

        public EditorToolFactory Outdent()
        {
            return Button("outdent");
        }

        public EditorToolFactory InsertOrderedList()
        {
            return Button("insertOrderedList");
        }
        
        public EditorToolFactory InsertImage()
        {
            return Button("insertImage");
        }

        public EditorToolFactory InsertFile()
        {
            return Button("insertFile");
        }

        public EditorToolFactory CreateLink()
        {
            return Button("createLink");
        }

        public EditorToolFactory Unlink()
        {
            return Button("unlink");
        }

        public EditorToolFactory SubScript()
        {
            return Button("subscript");
        }

        public EditorToolFactory SuperScript()
        {
            return Button("superscript");
        }

        public EditorToolFactory ViewHtml()
        {
            return Button("viewHtml");
        }

        public EditorToolFactory Print()
        {
            return Button("print");
        }

        public EditorToolFactory FontName()
        {
            return ComboBox("fontName", null);
        }

        public EditorToolFactory FontName(Action<EditorDropDownItemBuilder> configurator)
        {
            var items = new List<DropDownListItem>();
            var builder = new EditorDropDownItemBuilder(items);

            configurator(builder);

            return ComboBox("fontName", items);
        }

        public EditorToolFactory FontSize()
        {
            return ComboBox("fontSize", null);
        }

        public EditorToolFactory FontSize(Action<EditorDropDownItemBuilder> configurator)
        {
            var items = new List<DropDownListItem>();
            var builder = new EditorDropDownItemBuilder(items);

            configurator(builder);

            return ComboBox("fontSize", items);
        }

        public EditorToolFactory Formatting()
        {
            return SelectBox("formatting", null);
        }

        public EditorToolFactory Formatting(Action<EditorDropDownItemBuilder> configurator)
        {
            var items = new List<DropDownListItem>();
            var builder = new EditorDropDownItemBuilder(items);

            configurator(builder);

            return SelectBox("formatting", items);
        }

        [Obsolete("The FormatBlock tool is deprecated, please use the Formatting tool instead. For more information, visit http://docs.telerik.com/kendo-ui/getting-started/changes-and-backward-compatibility")]
        public EditorToolFactory FormatBlock()
        {
            return SelectBox("formatBlock", null);
        }

        [Obsolete("The FormatBlock tool is deprecated, please use the Formatting tool instead. For more information, visit http://docs.telerik.com/kendo-ui/getting-started/changes-and-backward-compatibility")]
        public EditorToolFactory FormatBlock(Action<EditorDropDownItemBuilder> configurator)
        {
            var items = new List<DropDownListItem>();
            var builder = new EditorDropDownItemBuilder(items);

            configurator(builder);

            return SelectBox("formatBlock", items);
        }

        public EditorToolFactory Snippets(Action<EditorSnippetBuilder> configurator)
        {
            var items = new List<DropDownListItem>();
            
            var builder = new EditorSnippetBuilder(items, DI.Current.Resolve<IVirtualPathProvider>());

            configurator(builder);

            return SelectBox("insertHtml", items);
        }

        [Obsolete("The Styles tool is deprecated, please use the Formatting tool instead. For more information, visit http://docs.telerik.com/kendo-ui/getting-started/changes-and-backward-compatibility")]
        public EditorToolFactory Styles(Action<EditorDropDownItemBuilder> configurator)
        {
            var items = new List<DropDownListItem>();

            var builder = new EditorDropDownItemBuilder(items);

            configurator(builder);

            return SelectBox("style", items);
        }

        public EditorToolFactory FontColor()
        {
            return ColorPicker("foreColor");
        }

        public EditorToolFactory FontColor(Action<EditorColorPickerToolBuilder> configurator)
        {
            return ColorPicker("foreColor", configurator);
        }

        public EditorToolFactory BackColor()
        {
            return ColorPicker("backColor");
        }

        public EditorToolFactory BackColor(Action<EditorColorPickerToolBuilder> configurator)
        {
            return ColorPicker("backColor", configurator);
        }

        public EditorToolFactory TableEditing()
        {
            Button("createTable");
            Button("addColumnLeft");
            Button("addColumnRight");
            Button("addRowAbove");
            Button("addRowBelow");
            Button("deleteRow");
            Button("deleteColumn");

            return this;
        }

        public EditorToolFactory Separator()
        {
            group.Tools.Add(new EditorTool(("separator")));

            return this;
        }

        public EditorToolFactory CleanFormatting()
        {
            return Button("cleanFormatting");
        }
        
        private EditorToolFactory Button(string text)
        {
            group.Tools.Add(new EditorTool(text));

            return this;
        }

        private EditorToolFactory ComboBox(string identifier, IList<DropDownListItem> items)
        {
            group.Tools.Add(new EditorListTool(identifier, items));

            return this;
        }

        private EditorToolFactory SelectBox(string identifier, IList<DropDownListItem> items)
        {
            group.Tools.Add(new EditorListTool(identifier, items));

            return this;
        }

        private EditorToolFactory ColorPicker(string identifier)
        {
            group.Tools.Add(new EditorTool(identifier));

            return this;
        }

        private EditorToolFactory ColorPicker(string identifier, Action<EditorColorPickerToolBuilder> configurator)
        {
            var tool = new EditorColorPickerTool(identifier);

            configurator(new EditorColorPickerToolBuilder(tool));

            group.Tools.Add(tool);

            return this;
        }
    }
}