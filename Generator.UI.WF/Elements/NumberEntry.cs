namespace Generator.UI.WF.Elements
{
    public class NumberEntry : BaseElement
    {
        public string MaxLenght { get; set; }
        public string Enable { get; set; }
        public string NoFormat { get; set; }

        public override string ToString()
        {
            string xml = "\n";
            xml += $"<number-entry id=\"{Id}\" text=\"{Text}\" enable=\"{Enable}\" no-format=\"{NoFormat}\" max-lenght=\"{MaxLenght}\"/>".Tab(4);
            return xml;
        }
    }
}