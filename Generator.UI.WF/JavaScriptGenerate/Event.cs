namespace Generator.UI.WF.JavaScriptGenerate
{
    public class Event
    {
        public string EventName { get; set; }
        public string Content { get; set; }
        public override string ToString()
        {
            string javaScript = "";
            javaScript += $"case '{EventName}:";
            javaScript += Content;
            return javaScript;
        }
    }
}