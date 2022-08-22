using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.UI.WF.Elements
{
    public class Combo: BaseElement
    {
        public string KeyField { get; set; }
        public string ValueField { get; set; }
        public override string ToString()
        {
            return $"\n<combo id=\"{Id}\" text=\"{Text}\" key-field=\"{KeyField}\" value-field=\"{ValueField}\"/>";
        }   
    }
}
