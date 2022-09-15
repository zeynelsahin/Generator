using System.Collections.Generic;
using Generator.UI.WF.Elements;

namespace Generator.UI.WF.JavaScriptGenerate
{
    public class EventHandler
    {
        public List<Event> Events { get; set; }
        public override string ToString()
        {
            string xml = "";
            xml += "EventHandler(eventName,arg1) {\n";
            xml += "switch(eventName) {\n";
            return xml;
            
        }
    }
}