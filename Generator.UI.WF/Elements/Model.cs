using System.Collections.Generic;

namespace Generator.UI.WF.Elements
{
    public class Model
    {
        public List<Field> Fields { get; set; } = new List<Field>();

        public override string ToString()
        {
            var xml = "";
            Fields.ForEach(field => { xml += field.ToString(); });
            return "\n<model>" + xml + "\n</model>";
        }
    }
}