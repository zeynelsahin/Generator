namespace Generator.UI.WF.JavaScriptGenerate
{
    public class GetComboBoxApiMethod : ApiRequestMethod
    {
        public override string ToString()
        {
            var javaScript = base.ToString();
            if (ServiceName.ToLower().Contains("create"))
            {
                javaScript += $"if (results == null)".Tab(6);
            }
            else if (ServiceName.ToLower().Contains("get"))
            {
                javaScript += $"if (results.{ResultName} == null || results.{ResultName}.length < 1)".Tab(6);
            }
            else
            {
                javaScript += $"if (results == null)".Tab(6);
            }
            javaScript += " {\n";
            javaScript += $"this.$Prop.{PropName}.Fill(null);\n".Tab(7);
            javaScript += "}\n".Tab(6);
            javaScript += "else {\n".Tab(6);
            javaScript += $"this.$Prop.{PropName}.Fill(results.{ResultName});\n".Tab(7);
            javaScript += "}\n".Tab(6);
            javaScript += "}\n".Tab(5);
            javaScript += "});\n".Tab(4);
            javaScript += "}".Tab(2);
            return javaScript;
        }
    }
}