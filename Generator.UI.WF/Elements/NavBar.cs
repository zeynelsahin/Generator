using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class NavBar
    {
        public string Title { get; set; }

        public override string ToString()
        {
            return "\n<navbar title=\"File Upload Status\"/>";
        }
    }
}