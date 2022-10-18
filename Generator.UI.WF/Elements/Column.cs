namespace Generator.UI.WF.Elements
{
    public class Column : BaseElement //Grid Sütunu
    {
        public string FieldId { get; set; }
        public string Witdh { get; set; }
        public LinkButton LinkButton { get; set; }

        public override string ToString()
        {
            string xml = "";
            if (LinkButton == null)
            {
                xml += "\n";
                xml += $"<col id=\"{Id}\" field-id=\"{FieldId}\" text=\"{Text}\" width=\"{Witdh}\"/>".Tab(6);
                return xml;
            }
            else
            {
                xml += "\n";
                xml += $"<col id=\"{Id}\" field-id=\"{FieldId}\" text=\"{Text}\" width=\"{Witdh}\">".Tab(6);
                xml += LinkButton.ToString();
                xml += "\n";
                xml += "</col>".Tab(6);
                return xml;
            }
        }
    }
}