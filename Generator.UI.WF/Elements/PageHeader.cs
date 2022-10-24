using System.Collections.Generic;
using System.Linq;
using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class PageHeader : IElement
    {
        public string Title { get; set; }
        public List<Button> Buttons { get; set; } = new List<Button>();

        public override string ToString()
        {
            var xml = "\n";
            xml += $"<page-header title=\"{Title}\">".Tab(1);
            if (Buttons.Count > 0) xml = Buttons.Aggregate(xml, (current, button) => current + button);
            xml += "\n";
            xml += "</page-header>".Tab(1);
            return xml;
        }
    }
}