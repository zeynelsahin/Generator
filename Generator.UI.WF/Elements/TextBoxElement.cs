namespace Generator.UI.WF.Elements
{
    public class TextBoxElement : BaseElement
    {
        public override string ToString()
        {
            var xml = "\n";
            xml += $"<textbox id=\"{Id}\" text=\"{Text}\" />".Tab(4);
            return xml;
        }
    }
}