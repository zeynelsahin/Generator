namespace Generator.UI.WF.JavaScriptGenerate
{
    public class StringStaticMethod : StaticMethod
    {
        public string StaticMethod { get; set; }

        public override string ToString()
        {
            var javaScript = "";
            javaScript += $"{MethodName}() ".Tab(2);
            javaScript += "{\n";
            javaScript += StaticMethod;
            javaScript += "\n";
            javaScript += "}".Tab(2);
            return javaScript;
        }
    }
}