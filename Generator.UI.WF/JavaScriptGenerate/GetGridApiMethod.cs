namespace Generator.UI.WF.JavaScriptGenerate
{
    public class GetGridApiMethod : ApiRequestMethod
    {
        public override string ToString()
        {
            var javaScript = base.ToString();
            javaScript += $"if(results.{ResultName}==null || results.{ResultName}.length ==0)";
            javaScript += "{\n";
            javaScript += $"this.$Prop.{PropName}.SetValue(null);\n";
            javaScript += "}\nelse{\n";
            javaScript += $"this.$Prop.{PropName}.SetValue(results.{ResultName});\n";
            javaScript += "}\n}\n});\n}";
            return javaScript;
        }
    }
}