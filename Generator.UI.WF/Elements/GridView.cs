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
            string xml = "";
            xml += $"\n<grid-view id =\"{Id}\" show-status=\"{ShowStatus}\" text=\"{Text}\" height=\"{Height}\">";
            if (CommandBar != null)
            {
                xml += CommandBar.ToString();
            }

            xml += RowTemplate.ToString();
            return xml;
        }
    }
}