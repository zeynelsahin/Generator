namespace Generator.UI.WF.JavaScriptGenerate
{
    public class Event
    {
        public string EventName { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            var javaScript = "";
            javaScript += $"case '{EventName}':".Tab(4);
            javaScript += "\n";
            javaScript += Content;
            javaScript += "break;\n".Tab(5);
            return javaScript;
        }
    }
}