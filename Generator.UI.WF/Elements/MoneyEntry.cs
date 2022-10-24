namespace Generator.UI.WF.Elements
{
    public class MoneyEntry : BaseElement
    {
        public override string ToString()
        {
            var xml = "\n";
            xml += "<money-entry id=\"MinSourceAmount\" text=\"MinAmount\"/>";
            return xml;
        }
    }
}