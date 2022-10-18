using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class LinkButton
    {
        public string ActionCode { get; set; }

        public override string ToString()
        {
            string xml = "\n";
            xml += $"<link-button action-code=\"{ActionCode}\"/>".Tab(7);
            return xml;
        }
    }
}