using System.Collections.Generic;

namespace Generator.UI.WF.Elements
{
    public class RowTemplate
    {
        public List<Column> Columns { get; set; } = new List<Column>();

        public override string ToString()
        {
            var xml = "\n";
            xml += "<row-template>".Tab(5);
            Columns.ForEach(p => { xml += p.ToString(); });
            xml += "\n";
            xml += "</row-template>".Tab(5);
            return xml;
        }
    }
}