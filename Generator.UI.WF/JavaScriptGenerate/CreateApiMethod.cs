namespace Generator.UI.WF.JavaScriptGenerate
{
    public class CreateApiMethod : ApiRequestMethod
    {
        public override string ToString()
        {
            var javaScript = base.ToString();
            javaScript += $"if(results == null)";
            javaScript += "{\n";
            javaScript += $"this.$View.AlertSuccess(\"Successfull add.\");\n";
            javaScript += "}\nelse{\n";
            javaScript += $"this.$View.AlertError(\"Failed add\");\n";
            javaScript += "}\n}\n});\n}";
            return javaScript;
        }
    }
}