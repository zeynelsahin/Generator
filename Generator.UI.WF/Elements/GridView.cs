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
            var xml = "";
            xml += $"\n<grid-view id =\"{Id}\" show-status=\"{ShowStatus}\"";
            if (StatusColorFieldId!=null)
            {
                xml += $" status-color-field-id=\"{StatusColorFieldId}\"";
            }
            xml += $" text=\"{Text}\" height=\"{Height}\">";
            if (CommandBar != null) xml += CommandBar.ToString();

            xml += Model.ToString();
            xml += RowTemplate.ToString();
            xml+=$"\n</grid-view>";
            return xml;
        }
    }
}