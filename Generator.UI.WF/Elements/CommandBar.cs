namespace Generator.UI.WF.Elements
{
    public class CommandBar
    {
        public string ShowSearchBox { get; set; }
        public string ExcelExport { get; set; }

        public override string ToString()
        {
            return $"<command-bar show-searchbox=\"{ShowSearchBox}\" excel-export=\"{ExcelExport}\"/>";
        }
    }
}