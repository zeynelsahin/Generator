using Generator.UI.WF.Models;
using System.Collections.Generic;

namespace Generator.UI.WF.Elements
{
    public class PageHeader : IElement
    {
        public string Title { get; set; }
        public List<Button> Buttons { get; set; } = new List<Button>();

        public override string ToString()
        {
            string xml = "\n";
            xml += $"<page-header title=\"{Title}\">".Tab(1);
            if (Buttons.Count > 0)
            {
                foreach (var button in Buttons)
                {
                    xml += button.ToString();
                }
            }
            xml += "\n";
            xml += "</page-header>".Tab(1);
            return xml;
        }
    }
}