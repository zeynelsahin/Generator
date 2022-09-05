namespace Generator.UI.WF.JavaScriptGenerate
{
    public class GetComboBoxApiMethod : ApiRequestMethod
    {
        public override string ToString()
        {
            var javaScript = base.ToString();
            javaScript += $"if(records.{ResultName}==null || records.{ResultName}.length < 1)";
            javaScript += "{\n";
            javaScript += $"this.$Prop.{PropName}.Fill(null);\n";
            javaScript += "}\nelse{\n";
            javaScript += $"this.$Prop.{PropName}.Fill(records.{ResultName});\n";
            javaScript += "}\n}\n});\n}";
            return javaScript;
        }
    }
}