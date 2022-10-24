using System.Collections.Generic;

namespace Generator.UI.WF.Elements
{
    public class UserControlElement : BaseElement
    {
        public string ControlId { get; set; }
        public List<Parameter> Parameters { get; set; } = new List<Parameter>();

        public override string ToString()
        {
            var xml = "\n";
            xml += $"<user-control id=\"{Id}\" control-id=\"{ControlId}\"".Tab(4);
            Parameters.ForEach(parameter => { xml += parameter.ToString(); });
            xml += "</user-control>".Tab(4);
            return xml;
        }
    }
}