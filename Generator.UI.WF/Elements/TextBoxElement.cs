namespace Generator.UI.WF.Elements
{
    public class TextBoxElement : BaseElement
    {
        public override string ToString()
        {
            return $"\n<textbox id=\"{Id}\" text=\"{Text}\" />";
        }
    }
}