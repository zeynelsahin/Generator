using System.Collections.Generic;

namespace Generator.UI.WF.Elements
{
    public class Model
    {
        public List<Field> Fields { get; set; }

        public override string ToString()
        {
            string xml = "";
            Fields.ForEach(field => { xml += field.ToString(); });
            return "\n<model>"+xml+"\n</model>";
        }
    }
}