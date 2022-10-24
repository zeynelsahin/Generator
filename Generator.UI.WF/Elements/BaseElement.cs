using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class BaseElement : IElement
    {
        // public string Enable { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Alignment { get; set; }
    }
}