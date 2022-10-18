namespace Generator.UI.WF.Elements
{
    public class GridView : BaseElement
    {
        public string Height { get; set; }
        public string ShowStatus { get; set; }
        public string StatusColorFieldId { get; set; }
        public Model Model { get; set; }
        public RowTemplate RowTemplate { get; set; }
        public CommandBar CommandBar { get; set; }

        public override string ToString()
        {
            var xml = "\n";
            xml += "<content-block helper-css=\"box\">".Tab(1);
            xml += "\n";
            xml += "<row>".Tab(2);
            xml += "\n";
            xml += "<col size=\"12\" helper-css=\"col-layout-border\">".Tab(3);
            xml += "\n";
            xml += $"<grid-view id =\"{Id}\" show-status=\"{ShowStatus}\"".Tab(4);
            if (StatusColorFieldId != null)
            {
                xml += $" status-color-field-id=\"{StatusColorFieldId}\"";
            }
            xml += $" text=\"{Text}\" height=\"{Height}\">";
            if (CommandBar != null) xml += CommandBar.ToString();

            xml += Model.ToString();
            xml += RowTemplate.ToString();
            xml += "\n";
            xml += "</grid-view>".Tab(4);
            xml += "\n";
            xml += "</col>".Tab(3);
            xml += "\n";
            xml += "</row>".Tab(2);
            xml += "\n";
            xml += "</content-block>".Tab(1);
            return xml;
        }
    }
}