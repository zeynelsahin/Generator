using System.Collections.Generic;

namespace Generator.UI.WF.JavaScriptGenerate
{
    public class KeyValueStaticMethod<TKeyType, TValueType> : StaticMethod
    {
        public List<TKeyType> KeyList { get; set; } = new List<TKeyType>();
        public List<TValueType> ValueList { get; set; } = new List<TValueType>();

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
            javaScript += $"{MethodName}List() ";
            javaScript += "{\n";
            javaScript += $"let {MethodName} = [";

            for (int i = 0; i < KeyList.Count; i++)
            {
                javaScript += "\n{";
                javaScript += $"{KeyName}: {GetValue(KeyList[i])}: {ValueName}: {GetValue(ValueList[i])}";
                if (KeyList.Count != KeyList.Count - 1)
                {
                    javaScript += "},";
                }
                else
                {
                    javaScript += "}";
                }
            }

            javaScript += "\n];";
            javaScript += "\n}";
            return javaScript;
        }
    }
}