namespace Generator.UI.WF.Models
{
    public class PageXml
    {
        public IElement Header { get; set; }
        public IElement Content { get; set; }
        public IElement  GridContent { get; set; }
        public override string ToString()
        {
            string xml = "<ux-page>";
            xml += Header.ToString();
            xml += Content.ToString();
            xml += GridContent.ToString();
            xml += "</ux-page>";
            return xml;
        }
    }
}