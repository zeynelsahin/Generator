namespace Generator.UI.WF.Elements
{
    public class Button : BaseElement
    {
        public string ActionCode { get; set; }
        public string TypeCss { get; set; }
        public string IconCss { get; set; }

        public override string ToString()
        {
            var xml = "\n";
            xml +=
                $"<button id=\"{Id}\" text=\"{Text}\" action-code=\"{ActionCode}\" type-css=\"{TypeCss}\" alignment=\"{Alignment}\" icon-css=\"{IconCss}\"/>"
                    .Tab(2);
            return xml;
        }
    }
}