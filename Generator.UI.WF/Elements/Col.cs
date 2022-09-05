using System;
using System.Collections.Generic;
using System.Text;
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
            var xml = $"\n<col size=\"{Size}\">";
            if (HelperCss != null) xml += $" helper-css=\"{HelperCss}\"";

            xml += Element.ToString() + "\n</col>";
            return xml;
        }
    }
}