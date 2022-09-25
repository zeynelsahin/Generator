using System.Collections.Generic;
using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class ContentBlock: IElement
    {
        public string HelperCss { get; set; } = "box";
        public List<Row> Rows { get; set; } = new List<Row>();

        public override string ToString()
        {
            var xml = $"<content-block helper-css=\"{HelperCss}\">\n";
            Rows.ForEach(row => { xml += row.ToString(); });
            xml += "\n</content-block>";
            return xml;
        }
    }
}