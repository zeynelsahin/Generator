using System.Collections.Generic;
using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class Row
    {
        public List<IElement> Elements { get; set; } = new List<IElement>();

        public override string ToString()
        {
            var xml = "<row>".Tab(2);
            Elements.ForEach(element => { xml += element.ToString(); });
            xml += "\n";
            xml += "</row>".Tab(2);
            return xml;
        }
    }
}