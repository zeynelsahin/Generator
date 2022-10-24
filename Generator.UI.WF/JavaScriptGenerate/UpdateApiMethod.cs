namespace Generator.UI.WF.JavaScriptGenerate
{
    public class UpdateApiMethod : ApiRequestMethod
    {
        public override string ToString()
        {
            var javaScript = base.ToString();
            javaScript += "if (results.rowsAffected > 0)".Tab(6);
            javaScript += " {\n";
            javaScript += "this.$View.AlertSuccess(\"Successful update.\");\n".Tab(7);
            javaScript += "}\n".Tab(6);
            javaScript += "else {\n".Tab(6);
            javaScript += "this.$View.AlertError(\"Failed updated\");\n".Tab(7);
            javaScript += "}\n".Tab(6);
            javaScript += "}\n".Tab(5);
            javaScript += "});\n".Tab(4);
            javaScript += "}\n".Tab(2);
            return javaScript;
        }
    }
}