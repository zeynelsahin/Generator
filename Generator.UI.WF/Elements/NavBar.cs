namespace Generator.UI.WF.Elements
{
    public class NavBar
    {
        public string Title { get; set; }

        public override string ToString()
        {
            var xml = "\n";
            xml += $"<navbar title=\"{Title}\"/";
            return xml;
        }
    }
}