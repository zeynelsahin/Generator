using System.Collections.Generic;
using Generator.Entities;

namespace Generator.UI.WF.JavaScriptGenerate
{
    public class KeyValueStaticMethod : StaticMethod
    {
        public List<object> KeyList { get; set; } = new List<object>();
        public List<object> ValueList { get; set; } = null;
        public string JsonString { get; set; }

        public string GetValue(object value)
        {
            if (value.GetType() == typeof(string))
            {
                return $"\"{value}\"";

            }
            else if (value.GetType() == typeof(int))
            {
                return $"{value}";
            }
            else
            {
                return "Type is null";
            }
        }
        public override string ToString()
        {
            var javaScript = "";
            javaScript += ($"{MethodName}List() ").Tab(2);
            javaScript += "{\n";
            javaScript += ($"let {MethodName} = [").Tab(3);
            if (ValueList != null)
            {
                for (int i = 0; i < KeyList.Count - 1; i++)
                {
                    javaScript += "\n";
                    javaScript += ("{ ").Tab(4);
                    javaScript += ($"{KeyName}: {KeyList[i]}, {ValueName}: {(ValueList[i])}");
                    javaScript += " },";
                }
                javaScript += "\n";
                javaScript += "{ ".Tab(4);
                javaScript += $"{KeyName}: {(KeyList[^1])}, {ValueName}: {(ValueList[^1])}";
                javaScript += " }\n";
                javaScript += "];".Tab(3);

            }
            else
            {
                for (int i = 0; i < KeyList.Count - 1; i++)
                {
                    javaScript += "{".Tab(4);
                    javaScript += $"{KeyName}: {(KeyList[i])}".Tab(4);
                    javaScript += "},".Tab(4);
                }
                javaScript += "{";
                javaScript += $"{KeyName}: {(KeyList[^1])}".Tab(4);
                javaScript += "}\n".Tab(4);
                javaScript += "];".Tab(3);
            }
            javaScript += "\n";
            javaScript += $"this.$Prop.{PropName}.Fill({MethodName});\n".Tab(3);
            javaScript += "}\n".Tab(2);

            return javaScript;
        }
    }
}