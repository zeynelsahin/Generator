namespace Generator.UI.WF.JavaScriptGenerate
{
    public class ApiRequestMethod : JavaScriptMethod
    {
        public string ParameterName { get; set; } = "";
        public Parameter Parameter { get; set; } = new Parameter();
        public string ServiceName { get; set; } = "";
        public string ProfileId { get; set; } //for action option 
        public string ServiceId { get; set; }
        public string ObjectType { get; set; }

        public override string ToString()
        {
            var javaScript = "\n";
            javaScript += $"{MethodName}()".Tab(2);
            javaScript += " {";
            if (Parameter.Params.Count > 0)
            {
                var tab = 4;
                javaScript += "\n";
                javaScript += "let input = {\n".Tab(3);
                if (!string.IsNullOrWhiteSpace(ParameterName))
                {
                    javaScript += $"{ParameterName}: ".Tab(4);
                    javaScript += "{";
                    javaScript += "\n";
                    tab = 5;
                }

                for (var i = 0; i < Parameter.Params.Count; i++)
                {
                    if (i == Parameter.Params.Count - 1)
                    {
                        javaScript += $"{Parameter.Params[i].Key}: this.$Prop.{Parameter.Params[i].Value}.GetValue()\n"
                            .Tab(tab);
                        break;
                    }

                    javaScript +=
                        $"{Parameter.Params[i].Key}: this.$Prop.{Parameter.Params[i].Value}.GetValue(),\n".Tab(tab);
                }

                if (!string.IsNullOrWhiteSpace(ParameterName)) javaScript += "}\n".Tab(4);

                javaScript += "};".Tab(3);
            }

            javaScript += "\n";
            javaScript += $"this.$Page.ExecuteQuery(\"{ServiceName}\",\n".Tab(3);
            javaScript += "{\n".Tab(4);
            if (Parameter.Params.Count > 0) javaScript += "Params: [input],\n".Tab(5);

            javaScript += "Done(results) {\n".Tab(5);
            return javaScript;
        }
    }
}