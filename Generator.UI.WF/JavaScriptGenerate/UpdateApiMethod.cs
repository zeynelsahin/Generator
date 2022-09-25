namespace Generator.UI.WF.JavaScriptGenerate
{
    public class UpdateApiMethod : ApiRequestMethod
    {
        public override string ToString()
        {
            var javaScript = base.ToString();
            javaScript += $"if(results.rowsAffected>0)";
            javaScript += "{\n";
            javaScript += $"this.$View.AlertSuccess(\"Successfull upated.\");\n";
            javaScript += "}\nelse{\n";
            javaScript += $"this.$View.AlertError(\"Failed updated\");\n";
            javaScript += "}\n}\n});\n}";
            return javaScript;
        }
    }
}