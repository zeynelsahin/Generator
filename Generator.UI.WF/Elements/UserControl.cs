using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class UserControl: BaseElement
    {
        public string ControlId { get; set; }
        public List<Parameter> Parameters { get; set; }

        string xml = "";
        public override string ToString()
        {
            Parameters.ForEach(parameter =>
            {
                xml += parameter.ToString();
            });
            return xml;
        }
    }
}
