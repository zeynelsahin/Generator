namespace Generator.UI.WF.JavaScriptGenerate
{
    public class ApiRequestMethod : JavaScriptMethod
    {
        public string ParameterName { get; set; } = "";
        public Parameter Parameter { get; set; } = new Parameter();
        public string ServiceName { get; set; } = "";

        public override string ToString()
        {
            var javaScript = "";
            javaScript += $"\n{MethodName}()";
                javaScript += "{";
            if (Parameter.Params.Count > 0)
            {
                javaScript += "let input = {";
                for (var i = 0; i < Parameter.Params.Count; i++)
                {
                    if (i == Parameter.Params.Count - 1)
                    {
                        javaScript += $"\n{Parameter.Params[i].Key}: this.$Prop.{Parameter.Params[i].Value}.GetValue()";
                        break;
                    }

                    javaScript += $"\n{Parameter.Params[i].Key}: this.$Prop.{Parameter.Params[i].Value}.GetValue(),";
                }
                javaScript += "\n};";
            }

            javaScript += $"\nthis.$Page.ExecuteQuery(\"{ServiceName}\",";
            javaScript += "\n{\n";
            if (Parameter.Params.Count > 0)
            {
                javaScript += "Params:[input],\n";
            }
            javaScript += "Done(results) {\n";
            return javaScript;
        }
    }
}