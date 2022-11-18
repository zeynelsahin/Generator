namespace Generator.UI.WF.JavaScriptGenerate
{
    public class CreateApiMethod : ApiRequestMethod
    {
        public override string ToString()
        {
            var javaScript = base.ToString();
            if (ObjectType == "CUSTOM_SQL")
                javaScript += $"if (results.{ResultName} != null || results.{ResultName} != \"\")".Tab(6);
            else if (ObjectType == "TABLE")
                javaScript += $"if (results == null || results == \"\")".Tab(6);
            javaScript += " {\n";
            javaScript += "this.$View.AlertSuccess(\"Successful add.\");\n".Tab(7);
            javaScript += "}\n".Tab(6);
            javaScript += "else {\n".Tab(6);
            javaScript += "this.$View.AlertError(\"Failed add\");\n".Tab(7);
            javaScript += "}\n".Tab(6);
            javaScript += "}\n".Tab(5);
            javaScript += "});\n".Tab(4);
            javaScript += "}".Tab(2);
            return javaScript;
        }
    }
}