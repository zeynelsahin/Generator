﻿namespace Generator.UI.WF.Elements
{
    public class ComboBoxElement : BaseElement
    {
        public string KeyField { get; set; }
        public string ValueField { get; set; }

        public override string ToString()
        {
            var xml = "\n";
            xml += $"<combo id=\"{Id}\" text=\"{Text}\" key-field=\"{KeyField}\" value-field=\"{ValueField}\"/>".Tab(4);
            return xml;
        }
    }
}