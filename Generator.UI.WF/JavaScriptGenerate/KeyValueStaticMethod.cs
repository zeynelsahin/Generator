using System.Collections.Generic;

namespace Generator.UI.WF.JavaScriptGenerate
{
    public class KeyValueStaticMethod : StaticMethod
    {
        public Dictionary<string, string> StaticList { get; set; } = new Dictionary<string, string>();
        public string Key { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            var javaScript = "";
            javaScript += $"{MethodName}() ";
            javaScript += "{\n";
            javaScript += $"let {ResultName} = [";

            foreach (var item in StaticList)
            {
                javaScript += "\n{";
                javaScript += $"{Key}:{item.Key}, {Value}:\"{item.Value}\"";
                javaScript += "}";
            }

            javaScript += "\n];";

            javaScript += $"this.$Prop.{PropName}.Fill(results.{ResultName});\n";
            javaScript += "}\n}\n});\n}";
            return javaScript;
        }
    }
}