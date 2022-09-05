using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Security.Principal;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class UserControlElement : BaseElement
    {
        public string ControlId { get; set; }
        public List<Parameter> Parameters { get; set; }= new List<Parameter>();


        public override string ToString()
        {
            string xml=$"<user-control id=\"{Id}\" control-id=\"{ControlId}\"\n";
            Parameters.ForEach(parameter => { xml += parameter.ToString()+"\n"; });
            xml += "</user-control>";
            return xml;
        }
    }
}