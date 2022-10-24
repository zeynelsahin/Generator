using Generator.UI.WF.Models;

namespace Generator.UI.WF.Elements
{
    public class LoadNextPage : IElement
    {
        public string PageName { get; set; }

        public override string ToString()
        {
            var xml = "";
            xml += $"this.$View.LoadNextPage({PageName},";
            xml += "{\n});";
            return xml;
        }
    }
}