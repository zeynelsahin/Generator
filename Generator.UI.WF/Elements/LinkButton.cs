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
            return $"\n<link-button action-code=\"{ActionCode}\"/>";
        }
    }
}