namespace Generator.UI.WF.Elements
{
    public class DateTimeEntry : BaseElement
    {
        public override string ToString()
        {
            var xml = "\n";
            xml += $"<date-time-entry id=\"{Id}\" text=\"{Text}\"/>".Tab(4);
            return xml;
        }
    }
}