namespace Generator.UI.WF.Elements
{
    public class NumberEntry : BaseElement
    {
        public string Enable { get; set; }
        public string NoFormat { get; set; }

        public override string ToString()
        {
            return $"\n<number-entry id=\"{Id}\" text=\"{Text}\" enable=\"{Enable}\" no-format=\"{NoFormat}\"/>";
        }
    }
}