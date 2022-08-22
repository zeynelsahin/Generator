namespace Generator.UI.WF.Elements
{
    public class Column : BaseElement //Grid Sütunu
    {
        public string FieldId { get; set; }
        public string Witdh { get; set; }
        public LinkButton LinkButton { get; set; }

        public override string ToString()
        {
            if (LinkButton == null)
                return $"<\ncol id=\"{Id}\"  field-id=\"{FieldId}\"  text=\"{Text}\" width=\"{Witdh}\"/>";
            return $"<\ncol id=\"{Id}\"  field-id=\"{FieldId}\"  text=\"{Text}\"  width=\"{Witdh}\">" + LinkButton.ToString() + "\n</col>";
        }
    }
}