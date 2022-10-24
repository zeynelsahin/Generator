namespace Generator.UI.WF.Elements
{
    public class CheckBoxElement : BaseElement
    {
        public string Checked { get; set; }

        public override string ToString()
        {
            var xml = "\n";
            xml += $"<checkbox id=\"{Id}\" text=\"{Text}\" checked=\"{Checked}\"/>".Tab(4);
            return xml;
        }
    }
}