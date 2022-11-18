using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class Col : IElement
    {
        public string Size { get; set; }
        public string HelperCss { get; set; }
        public IElement Element { get; set; }

        public override string ToString()
        {
            var xml = "\n";
            xml += $"<col size=\"{Size}\">".Tab(3);
            if (HelperCss != null) xml += $" helper-css=\"{HelperCss}\"";
            xml += Element.ToString();
            xml += "\n";
            xml += "</col>".Tab(3);
            
            return xml;
        }
    }
}