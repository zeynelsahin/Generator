using System.Collections.Generic;
using System.Linq;

namespace Generator.UI.WF.JavaScriptGenerate
{
    public class EventHandler
    {
        public List<Event> Events { get; set; }

        public override string ToString()
        {
            var javaScript = "";
            javaScript += "EventHandler(eventName,arg1) {\n".Tab(2);
            javaScript += "var recordInfo = arg1;\n".Tab(3);
            javaScript += "switch(eventName) {\n";
            javaScript = Events.Aggregate(javaScript, (current, method) => current + method);
            return javaScript;
        }
    }
}