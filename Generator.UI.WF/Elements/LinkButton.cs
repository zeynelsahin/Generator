namespace Generator.UI.WF.Elements
{
    public class LinkButton
    {
        public string ActionCode { get; set; }

        public override string ToString()
        {
            var xml = "\n";
            xml += $"<link-button action-code=\"{ActionCode}\"/>".Tab(7);
            return xml;
        }
    }
}