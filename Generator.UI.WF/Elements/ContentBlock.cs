using System.Collections.Generic;

namespace Generator.UI.WF.Elements
{
    public class ContentBlock
    {
        public string HelperCss { get; set; }
        public List<Row> Rows { get; set; } = new List<Row>();

        public override string ToString()
        {
            var xml = "";
            Rows.ForEach(row => { xml += row.ToString(); });
            return xml;
        }
    }
}