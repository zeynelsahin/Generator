using System.Collections.Generic;

namespace Generator.UI.WF.Elements
{
    public class Model
    {
        public List<Field> Fields { get; set; } = new List<Field>();

        public override string ToString()
        {
            var xml = "\n";
            xml += "<model>".Tab(5);
            Fields.ForEach(field => { xml += field.ToString(); });
            xml += "\n";
            xml += "</model>".Tab(5);
            return xml;
        }
    }
}