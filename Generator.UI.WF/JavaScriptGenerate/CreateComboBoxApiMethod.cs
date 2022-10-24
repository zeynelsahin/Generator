﻿namespace Generator.UI.WF.JavaScriptGenerate
{
    public class CreateComboBoxApiMethod : ApiRequestMethod
    {
        public override string ToString()
        {
            var javaScript = base.ToString();
            javaScript += "if (results == null)".Tab(6);
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