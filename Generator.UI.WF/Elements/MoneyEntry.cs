using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class MoneyEntry : BaseElement
    {
        public override string ToString()
        {
            string xml = "\n";
            xml += $"<money-entry id=\"MinSourceAmount\" text=\"MinAmount\"/>";
            return xml;
        }
    }
}