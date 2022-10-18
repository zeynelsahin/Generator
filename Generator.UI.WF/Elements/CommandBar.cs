namespace Generator.UI.WF.Elements
{
    public class CommandBar
    {
        public string ShowSearchBox { get; set; }
        public string ExcelExport { get; set; }

        public override string ToString()
        {
            string xml = "\n";
            xml += $"<command-bar show-searchbox=\"{ShowSearchBox}\" excel-export=\"{ExcelExport}\"/>".Tab(5);
            return xml;
        }
    }
}