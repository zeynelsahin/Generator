namespace Generator.UI.WF.Elements
{
    public class CheckBox: BaseElement
    {
        public string Checked { get; set; }
        public override string ToString()
        {
            return $"\n<checkbox id=\"{Id}\" text=\"{Text}\" checked=\"{Checked}\"/>";
        }
    }
}