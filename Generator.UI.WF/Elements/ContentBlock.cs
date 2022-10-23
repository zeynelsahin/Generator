using System.Collections.Generic;
using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class ContentBlock : IElement
    {
        public string HelperCss { get; set; } = "box";
        public List<Row> Rows { get; set; } = new List<Row>();

        public override string ToString()
        {
            var xml = "\n";
            xml += $"<content-block helper-css=\"{HelperCss}\">".Tab(1);

            Rows.ForEach(row => { xml += "\n";  xml += row.ToString(); });
            xml += "\n";
            xml += "</content-block>".Tab(1);
            return xml;
        }
    }
}