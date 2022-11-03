namespace Generator.UI.WF.Elements
{
    public class DateEntry : BaseElement
    {
        public override string ToString()
        {
            var xml = "\n";
            xml += $"<date-entry id=\"{Id}\" text=\"{Text}\"/>".Tab(4);
            return xml;
        }
    }
}