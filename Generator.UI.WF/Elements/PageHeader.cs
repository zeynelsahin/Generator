namespace Generator.UI.WF.Elements
{
    public class PageHeader
    {
        public string Title { get; set; }
        public string Childes { get; set; }
        public override string ToString()
        {
            return $"\n<page-header title=\"{Title}\">" +Childes+ "\n<page-header>";
        }
    }
}